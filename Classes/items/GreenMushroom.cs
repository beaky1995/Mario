using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class GreenMushroom: IItem
    {
       private bool isCollidable { get; set; }
        private Vector2 position;
        private ISprite greenMushroomSprite;
        private bool toDestroy;
        private bool movingRight;
        private bool appears;
        private bool isCollision;
        private float originalPosition;
        private bool collide;
        public GreenMushroom(int x, int y)
        {
            IsCollidable = false;
            movingRight = true;
            position.X = x;
            position.Y = y;
            greenMushroomSprite = ItemSpriteFactory.Instance.CreateExtraLifeGreenMushroomSprite();
            toDestroy = false;
            appears = false;
            isCollision = false;
            originalPosition = position.Y;
            collide = false;
        }
        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, greenMushroomSprite.GetWidth(), greenMushroomSprite.GetHeight());
            }

        }
        public void ReverseDirection()
        {
            if (movingRight)
            {
                movingRight = false;
            }
            else
            {
                movingRight = true;
            }
        }

        public void Update()
        {

            if (appears)
            {
                if (isCollision)
                {
                    if (position.Y > originalPosition - ItemUtil.greenShroomMaxY)
                    {
                        position.Y -= ItemUtil.greenShroomSpeedY;
                    }
                    else
                    {
                        isCollision = false;
                        collide = true;
                    }
                }
                else
                {
                    if (movingRight)
                    {
                        position.X++;
                    }
                    else if (!movingRight)
                        position.X--;
                    position.Y += ItemUtil.greenShroomGravity;
                }
            }
            greenMushroomSprite.Update();
            
        }


        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            //comment to appear
            if(appears)
            greenMushroomSprite.Draw(spriteBatch, camera.AdjustPosition(position));
        }

        public Vector2 GetPosition()
        {
            return position;
        }


        public void React()
        {
            toDestroy = true;
        }

        public Boolean RemoveCheck()
        {
            return toDestroy;
        }
        public void Appears()
        {
            IsCollidable = true;
            appears = true;
            isCollision = true;
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

