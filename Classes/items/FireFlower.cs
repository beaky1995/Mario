using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class FireFlower: IItem 
    {
        private bool isCollidable { get; set; }
        private Vector2 position;
        private ISprite fireFlowerSprite;
        private Boolean toDestroy;
        private bool appears;
        private float originalPosition;
        private bool collide;
        private bool reacted;
        public FireFlower(int x, int y) 
        {
            reacted = false;
            IsCollidable = false;
            position.X = x - ItemUtil.fireXBuffer;
            position.Y = y - ItemUtil.fireYBuffer;
            fireFlowerSprite = ItemSpriteFactory.Instance.CreateFireFlowerSprite();
            toDestroy = false;
            appears = false;
            collide = false;
            originalPosition = position.Y;
        }

        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, fireFlowerSprite.GetWidth(), fireFlowerSprite.GetHeight());
            }

        }
        public void ReverseDirection()
        {
            //NO OP
        }

        public void Update()
        {
            if (appears)
            {
                if(position.Y > originalPosition - ItemUtil.fireMaxY)
                {
                    position.Y -= ItemUtil.fireSpeedY;
                }
                else
                {
                    collide = true;
                }
                
                fireFlowerSprite.Update();
            }
            
        }


        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            //comment to appear
            if(appears)
            fireFlowerSprite.Draw(spriteBatch, camera.AdjustPosition(position));
        }
        public Vector2 GetPosition()
        {
            return position;
        }

        public void React()
        {
            if (appears && !reacted)
            {
                reacted = true;
                Singleton.Instance.AddPoints(ItemUtil.fireScore, this);
                toDestroy = true;
            }
        }

        public Boolean RemoveCheck()
        {
            return toDestroy;
        }
        public void Appears()
        {
            IsCollidable = true;
            appears = true;
            SoundManager.Instance.PowerUpAppears();
            
        }

        public bool IsCollidable
        {
            get
            {
                return isCollidable;
            }
            set => isCollidable = value;
        }
        public ref Vector2 GetPositionRef()
        {
            return ref position;
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
        }
        public bool IsActivated()
        {
            return collide;
        }
    }
}
