using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Spaghetti
{
    public class FirePickupMario : IPlayer
    {
        private IPlayer decoratedMario;
        int timer = MarioUtil.fireTimer;
        Game1 myGame;
        private bool isDead;
        private bool isCollidable { get; set; }
        public Rectangle CollisionBox { get => decoratedMario.CollisionBox; }
        public IMarioState State { get => decoratedMario.State; set => decoratedMario.State = value; }

        public FirePickupMario(IPlayer _decoratedMario, Game1 currentGame)
        {
            IsCollidable = true;
            decoratedMario = _decoratedMario;
            isDead = false;
            myGame = currentGame;
        }

        public void ThrowFireball(Game1 game)
        {

        }

        public void Jump()
        {
            decoratedMario.Jump();
        }

        public void Crouch()
        {
            decoratedMario.Crouch();
        }

        public void Sprint()
        {
            decoratedMario.Sprint();
        }

        public void MoveLeft()
        {
            decoratedMario.MoveLeft();
        }

        public void MoveRight()
        {
            decoratedMario.MoveRight();
        }

        public void GoIdle()
        {
            decoratedMario.GoIdle();
        }

        public void ChangeToSmall()
        {
            // already taking damage so won't need to change to small
        }

        public void ChangeToBig()
        {
            decoratedMario.ChangeToBig();
        }

        public void ChangeToFire()
        {
            decoratedMario.ChangeToFire();
        }

        public void Die()
        {
            decoratedMario.Die();
            isDead = true;
        }

        public void Update()
        {
            timer--;
            if (decoratedMario.IsSmall() || decoratedMario.IsBig())
            {
                decoratedMario.ChangeToFire();
            }
            if (timer == 0)
            {
                RemoveIFrame();
            }
            decoratedMario.Update();
        }

        void RemoveIFrame()
        {
            myGame.PlayerList[MarioUtil.marioPlayerPos] = decoratedMario;
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            if (timer % 10 <= 5)
            {
                decoratedMario.Draw(spriteBatch, camera);
            }
            else
            {
                decoratedMario.StarDraw(spriteBatch, camera);
            }
        }

        public void StarDraw(SpriteBatch spriteBatch, Camera camera)
        {
            decoratedMario.StarDraw(spriteBatch, camera);
        }

        public ref Vector2 GetPositionRef()
        {
            return ref decoratedMario.GetPositionRef();
        }

        //public ref Vector2 GetGravityRef()
        //{
        //    return ref decoratedMario.GetGravityRef();
        // }

        public bool IsBig()
        {
            return decoratedMario.IsBig();
        }
        public bool IsSmall()
        {
            return decoratedMario.IsSmall();
        }
        public bool IsStar()
        {
            return decoratedMario.IsStar();
        }

        public bool IsFire()
        {
            return decoratedMario.IsFire();
        }

        public bool IsDead()
        {
            return isDead;
        }
        public bool IsMovingUp()
        {
            return decoratedMario.IsMovingUp();
        }

        public bool IsCrouching()
        {
            return decoratedMario.IsCrouching();
        }

        public bool CanTakeDamage()
        {
            return false;
        }

        //public ref Vector2 GetVelocityRef()
        // {
        //    return ref decoratedMario.GetVelocityRef();
        // }

        public MarioPhysics GetMarioPhysicsObject()
        {
            return decoratedMario.GetMarioPhysicsObject();
        }

        public void SetMarioYVelocityToZero()
        {
            decoratedMario.SetMarioYVelocityToZero();
        }

        public void SetMarioXVelocityToZero()
        {
            decoratedMario.SetMarioXVelocityToZero();
        }

        public void SetIsGrounded(bool value)
        {
            decoratedMario.SetIsGrounded(value);
        }
        public bool IsGrounded()
        {
            return decoratedMario.IsGrounded();
        }

        public void SetIsFalling(bool value)
        {
            decoratedMario.SetIsFalling(value);
        }

        public bool IsFalling()
        {
            return decoratedMario.IsFalling();
        }

        public bool IsCollidable
        {
            get
            {
                return isCollidable;
            }
            set => isCollidable = value;
        }
        public void WinAnimation()
        {
            //marioPhysics.WinAnimation();
        }
        public void getAxes()
        {
        }
        public bool isFinish()
        {
            return false;
        }
    }
}
