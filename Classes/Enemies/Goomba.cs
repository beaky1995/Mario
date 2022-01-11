using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class Goomba: IEnemy
    {
        public IGoombaState state;
        public Vector2 position;
        private bool toDestroy;
        private bool move;
        private bool isCollidable { get; set; }
        private bool isMovingUp { get; set; }
        private float previousY;
        private bool isStomped { get; set; }
        
        private bool isLethal { get; set; }

        public Goomba(int x, int y)
        {
            position.X = x;
            position.Y = y;
            previousY = y;
            isStomped = false;
            state = new RunningInPlaceGoombaState(this);
            IsCollidable = true;
            IsMovingUp = false;
            toDestroy = false;
            move = false;

            IsLethal = true;
        }

        public void MoveLeft()
        {
            state.MoveLeft();
        }

        public void MoveRight()
        {
            state.MoveRight();
            position.X += GoombaUtil.xSpeed;
        }
    
        public void BeStomped()
        {
            if (!IsStomped)
            {
                state.BeStomped();
                IsStomped = true;
                SoundManager.Instance.Stomp();
                Singleton.Instance.AddStompPoints(GoombaUtil.score, this);
                IsCollidable = false;
            }
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
            
            state.BeFlipped();
            IsCollidable = false;
            SoundManager.Instance.Flip();

            //Singleton.Instance.AddPoints(GoombaUtil.score, this);
        }

        public bool IsMovingUp
        {
            get
            {
                return isMovingUp;
            }
            set => isMovingUp = value;
        }

        //We do not need a BeKilled method.
        public void BeKilled()
        {
            state.BeKilled();
            IsCollidable = false;
        }

        public void Update()
        {
            state.Update();
            position.Y += GoombaUtil.gravity;
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            Vector2 value = camera.AdjustPosition(position);
            if (!move && value.X < GoombaUtil.startMoving)
            {
                move = true;
                state = new LeftMovingGoombaState(this);
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
