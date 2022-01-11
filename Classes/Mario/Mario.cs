using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;


namespace Spaghetti
{
    public class Mario : IPlayer
    {
        private IMarioState state;
        private bool isDead;
        private bool isFalling;
        private bool isGrounded;
        private bool isCollidable { get; set; }
        private bool winAction;
        private bool adjustPositions;
        private bool appears;
        private bool getAxe;
        private int count;
        private bool isFinished;

        public Vector2 position;
        public MarioPhysics marioPhysics;

        public Mario(int x, int y)
        {
            IsCollidable = true;
            position.X = x;
            position.Y = y;
            State = new MarioRightSmallIdleState(this);
            isDead = false;
            isFalling = false;
            isGrounded = true;
            winAction = false ;
            adjustPositions = false;
            appears = true;
            getAxe = false;
            count = 0;
            isFinished = false;
            
            marioPhysics = new MarioPhysics(this);
        }


    

        public Rectangle CollisionBox
        {
            get
            { 
                return new Rectangle((int)position.X, (int)position.Y, state.GetWidth(), state.GetHeight());
            }

        }

        public IMarioState State
        {
            get
            {
                return state;
            }
            set => state = value;
        }

        public void ThrowFireball(Game1 game)
        {
            if (state.IsFire() && (game.FireballList.Count < MarioUtil.marioMaxFireballs))
            {
                state.ThrowFireball(game);
                SoundManager.Instance.ThrowFireball();
            }
        }

        public void Jump()
        {
            if (!IsFalling())
            {
                if (isGrounded)
                {
                    isGrounded = false;
                    SoundManager.Instance.Jump();
                }
                state.Jump();
                marioPhysics.Jump();
            }
        }

        public void SetIsGrounded(bool value)
        {
            isGrounded = value;
        }
        public bool IsGrounded()
        {
            return isGrounded;
        }

        public void Crouch()
        {
            state.Crouch();
        }

        public void MoveLeft()
        {
            if (IsGrounded())
            {
                state.MoveLeft();
                marioPhysics.MoveLeft();
            }
            else 
            { 
                marioPhysics.JumpingMoveLeft();
            }
        

        }

        public void MoveRight()
        {
            if (IsGrounded())
            {
                state.MoveRight();
                marioPhysics.MoveRight();
            }
          else
            {
                marioPhysics.JumpingMoveRight();
            }
        }

        public void Sprint()
        {
            if (IsGrounded())
            {
                marioPhysics.Sprint();
            }
        }

        public void GoIdle()
        {
            state.GoIdle();
        }

        public void ChangeToSmall()
        {
            state.ChangeToSmall();
        }

        public void ChangeToBig()
        {
            state.ChangeToBig();
        }

        public void ChangeToFire()
        {
            state.ChangeToFire();
        }

        public void Die()
        {
            if (!isDead)
            {
                state.Die();
                isDead = true;
                SoundManager.Instance.PlayMarioDieMusic();
            }
        }

     
        public void Update()
        {
            state.Update();
            if(!winAction && !getAxe)
                marioPhysics.Update();
            if(winAction)
            {
                
                if (position.Y < MarioUtil.flagBottom)
                {
                   state.GoIdle();
                   position.Y++;
                }
                else if(position.X < MarioUtil.maxMarioPosition)
                {
                    state.MoveRight();
                    position.X ++;
                }
                else
                {
                    appears = false;
                }
                if(position.X > MarioUtil.marioAdjustBottom)
                {
                    MarioUtil.marioPhysicsTimer += 1;
                    if(MarioUtil.marioPhysicsTimer < 10)
                    {
                        marioPhysics.Update();
                    }
                    if (!adjustPositions)
                    {
                        position.X += MarioUtil.marioAdjustBottomX;
                        //position.Y += MarioUtil.marioAdjustBottomY;
                        adjustPositions = true;
                    }
                }
                
            }
            if (getAxe)
            {
                if(count <= 3)
                {
                    marioPhysics.Update();
                    count++;
                }
                else if(position.X <= MarioUtil.marioLFMovingPositionX)
                {
                    state.MoveRight();
                    position.X++;
                }
                else if(position.Y <= MarioUtil.marioLFMovingPositionY)
                {
                    position.Y+=2;
                }
                else if(position.X <= MarioUtil.marioLFMovingPositionXX)
                {
                    position.X += 1;
                }
                else
                {
                    state.GoIdle();
                    isFinished = true;

                }
            }
        }

        public ref Vector2 GetPositionRef()
        {
            return ref position;
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            if(appears)
            state.Draw(spriteBatch, camera);
        }

        public void StarDraw(SpriteBatch spriteBatch, Camera camera)
        {
            state.StarDraw(spriteBatch, camera);
        }

        public bool IsBig()
        {
            return state.IsBig();
        }

        public bool IsSmall()
        {
            return state.IsSmall();
        }

        public bool IsStar()
        {
            return false;
        }

        public bool IsFire()
        {
            return state.IsFire();
        }

        public bool IsDead()
        {
            return isDead;
        }

        public bool IsMovingUp()
        {
            return state.IsMovingUp();
        }

        public bool CanTakeDamage()
        {
            return true;
        }

        public MarioPhysics GetMarioPhysicsObject()
        {
            return marioPhysics;
        }

        public void SetMarioYVelocityToZero()
        {
            marioPhysics.SetYVelocityToZero();
        }

        public void SetMarioXVelocityToZero()
        {
            marioPhysics.SetXVelocityToZero();
        }

        public void SetIsFalling(bool value)
        {
            isFalling = value;
        }

        public bool IsFalling()
        {
            return isFalling;
        }
        public bool IsCrouching()
        {
            return state.IsCrouching();
        }


        public Vector2 CalculateFireballOriginCoordinates()
        {
            Rectangle marioRectangle = CollisionBox;
            int xOffset = marioRectangle.Center.X + (marioRectangle.Width / 4);
            int x = marioRectangle.X;
            int y = marioRectangle.Y + (marioRectangle.Height / 2);
            return new Vector2((int)x, (int)y);
        }
        public void WinAnimation()
        {
            winAction = true;
            Singleton.Instance.winAction = true;
            state.MoveLeft();
        }
        public void getAxes()
        {
            getAxe = true;
        }

        public bool IsCollidable
        {
            get
            {
                return isCollidable;
            }
            set => isCollidable = value;
        }
        public bool isFinish()
        {
            return isFinished;
        }
    }
}
