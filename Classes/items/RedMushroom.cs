using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class RedMushroom: IItem
    {
        private bool isCollidable { get; set; }
        private Vector2 position;
        private ISprite redMushroomSprite;
        private bool movingRight;
        private bool toDestroy;
        private bool appears;
        private bool isCollision;
        private float originalPosition;
        private bool collide;
        private int delayCounter;
        private bool reacted;
        public RedMushroom(int x, int y)
        {
            reacted = false;
            IsCollidable = false;
            movingRight = true;
            position.X = x;
            position.Y = y;
            redMushroomSprite = ItemSpriteFactory.Instance.CreateLevelUpRedMushroomSprite();
            toDestroy = false;
            appears = false;
            isCollision = false;
            originalPosition = position.Y;
            collide = false;
            delayCounter = ItemUtil.redShroomDelay;
        }

        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, redMushroomSprite.GetWidth(), redMushroomSprite.GetHeight());
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
                delayCounter++;
                if (delayCounter == ItemUtil.redShroomDelayFinal)
                {
                    IsCollidable = true;
                }
                if (isCollision)
                {
                    if (position.Y > originalPosition - ItemUtil.redShroomMaxY)
                    {
                        position.Y -= ItemUtil.redShroomSpeedY;
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
                    position.Y += ItemUtil.redShroomGravity;
                }
            }
            redMushroomSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            //comment to appear
            if(appears)
            {
                redMushroomSprite.Draw(spriteBatch, camera.AdjustPosition(position));
            }
        }

        public Vector2 GetPosition()
        {
            return position;
        }

        public void React()
        {
            if (!reacted)
            {
                reacted = true;
                toDestroy = true;
            }

        }

        public bool RemoveCheck()
        {
            return toDestroy;
        }
        public void Appears()
        {
            
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
