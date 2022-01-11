using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class Bowser : IEnemy
    {
        public IBowserState state;
        public Vector2 position;
        private bool toDestroy;
        private bool move;
        private bool isCollidable { get; set; }
        private bool isMovingUp { get; set; }
        private bool isStomped { get; set; }

        private bool isLethal { get; set; }
        private int health;
        private int jumpTimer;
        Random rand;

        public Bowser(int x, int y)
        {
            position.X = x;
            position.Y = y;
            isStomped = false;
            IsCollidable = true;
            IsMovingUp = false;
            toDestroy = false;
            move = false;
            state = new ClosedMouthBowserState(this);
            IsLethal = true;
            health = BowserUtil.health;
            jumpTimer = BowserUtil.timer;
            rand = new Random();
        }

        public void MoveLeft()
        {
            //state.MoveLeft();
            position.X -= BowserUtil.xSpeed;
        }

        public void MoveRight()
        {
            //state.MoveRight();
            position.X += BowserUtil.xSpeed;
        }

        public void BeStomped()
        {
            /*
            if (!IsStomped)
            {
                //state.TakeDamage();
                IsStomped = true;
                SoundManager.Instance.Stomp();
                Singleton.Instance.AddStompPoints(BowserUtil.score, this);
                IsCollidable = false;
            }
            */
        }

        public bool IsStomped
        {
            get
            {
                return isStomped;
            }
            set => isStomped = value;
        }

        public void BeFlipped()
        {
            if(health > 0)
            {
                health--;
                SoundManager.Instance.Flip();
            } else
            {
                state.BeKilled();
                IsCollidable = false;
                Singleton.Instance.AddStompPoints(BowserUtil.score, this);
                SoundManager.Instance.Flip();
            }
            
        }

        public bool IsMovingUp
        {
            get
            {
                return isMovingUp;
            }
            set => isMovingUp = value;
        }
        
        public void BeKilled()
        {
            state.BeKilled();
            IsCollidable = false;
        }

        public void Update()
        {
            state.Update();
            position.Y += BowserUtil.gravity;
            jumpTimer--;
            if(jumpTimer == 0)
            {
                switch (rand.Next(3))
                {
                    case 0:
                        // Jump left
                        state = new JumpLeftBowserState(this);
                        break;
                    case 1:
                        // Jump right
                        state = new JumpRightBowserState(this);
                        break;
                    case 2:
                        // Shoot
                        break;
                }
                jumpTimer = BowserUtil.timer;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            Vector2 value = camera.AdjustPosition(position);
            if (!move && value.X < BowserUtil.startMoving)
            {
                move = true;
                state = new ClosedMouthBowserState(this);
            }
            state.Draw(spriteBatch, camera);
        }

        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, state.GetWidth(), state.GetHeight());
            }
        }

        public bool IsCollidable
        {
            get
            {
                return isCollidable;
            }
            set => isCollidable = value;
        }

        public void React()
        {
            toDestroy = true;
        }

        public Boolean RemoveCheck()
        {
            return toDestroy;
        }

        public ref Vector2 GetPositionRef()
        {
            return ref position;
        }

        public bool IsLethal
        {
            get
            {
                return isLethal;
            }
            set => isLethal = value;
        }
    }
}
