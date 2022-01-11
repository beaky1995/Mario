using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class Star:IItem
    {
        private bool isCollidable { get; set; }
        private Vector2 position;
        private ISprite starSprite;
        private bool movingRight;
        private bool toDestroy;
        private bool appears;
        private bool isCollision;
        private float originalPosition;
        private bool collide;
        private bool isBouncing;
        private bool reacted;
        public Star(int x, int y)
        {
            reacted = false;
            IsCollidable = false;
            movingRight = true;
            position.X = x- ItemUtil.starXBuffer;
            position.Y = y- ItemUtil.starYBuffer;
            starSprite = ItemSpriteFactory.Instance.CreateStarSprite();
            toDestroy = false;
            appears = false;
            isCollision = false;
            originalPosition = position.Y;
            collide = false;
            isBouncing = false;
        }

        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, starSprite.GetWidth(), starSprite.GetHeight());
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
            if(appears){
                if (appears)
                {
                    if (movingRight)
                    {
                        position.X += ItemUtil.starSpeedX;
                    }
                    else
                    {
                        position.X -= ItemUtil.starSpeedX;
                    }

                    if (isCollision)
                    {
                        if (position.Y > originalPosition - ItemUtil.starMaxY)
                        {
                            position.Y -= ItemUtil.starSpeedY;
                        }
                        else
                        {
                            isCollision = false;
                            collide = true;
                            originalPosition = position.Y;
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
                        if (!isBouncing)
                        {
                            position.Y += 1;
                            if(position.Y  > originalPosition + ItemUtil.starMaxBounceY)
                            {
                                isBouncing = true;
                            }
                        }
                        else
                        {
                            position.Y -= 1;
                            if(position.Y < originalPosition + ItemUtil.starMinBounceY)
                            {
                                isBouncing = false;
                            }
                        }

                        
                    }
                }
                starSprite.Update();
            }
        }


        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            //comment to appear
            if(appears)
            starSprite.Draw(spriteBatch, camera.AdjustPosition(position));
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
