using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class Koopa : IEnemy
    {
        public IKoopaState state;
        private bool isCollidable { get; set; }
        private bool isMovingUp { get; set; }
        public Vector2 position;
        private bool toDestroy;
        private bool move;
        private float previousY;
        private bool isStomped { get; set; } 


        private bool isLethal { get; set; }

        public Koopa(int x, int y)
        {
            IsStomped = false;
            position.X = x;
            position.Y = y;
            previousY = y;
            state = new RunningInPlaceKoopaState(this);
            IsMovingUp = false;
            IsCollidable = true;
            move = false;
            toDestroy = false;

            IsLethal = true;
        }

        public void MoveLeft()
        {
            state.MoveLeft();
        }

        public void MoveRight()
        {
            state.MoveRight();
        }

        public void BeStomped()
        {
            if (!IsStomped)
            {
                IsStomped = true;
                state.BeStomped();
                SoundManager.Instance.Stomp();
                Singleton.Instance.score += KoopaUtil.score;
                isLethal = false;
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
            //Singleton.Instance.AddPoints(KoopaUtil.score, this);
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
            position.Y += KoopaUtil.gravity;
            if(position.Y > previousY + KoopaUtil.yMotion)
            {
                IsMovingUp = true;
            }
            else
            {
                IsMovingUp = false;
            }
            previousY = position.Y;
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            Vector2 value = camera.AdjustPosition(position);
            if (!move && value.X < KoopaUtil.startMoving)
            {
                move = true;
                state = new LeftMovingKoopaState(this);
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


        public bool IsLethal
        {
            get
            {
                return isLethal;

            }
            set => isLethal= value;
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
    }
}
