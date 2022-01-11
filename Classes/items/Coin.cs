using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class Coin : IItem
    {

        private bool isCollidable {get;set;}
        private Vector2 position;
        private ISprite coinSprite;
        private bool toDestroy;
        private bool appears;
        private int minHeight;
        private bool moveUpAndDown;
        private bool toTheOriginal;
        private bool reacted;

     
        public Coin(int x, int y)
        {
            reacted = false;
            IsCollidable = false;
            position.X = x + ItemUtil.coinXBuffer;
            position.Y = y - ItemUtil.coinYBuffer;
            coinSprite = ItemSpriteFactory.Instance.CreateCoinSprite();
            toDestroy = false;
            appears = false;
            minHeight = (int)position.Y;
            moveUpAndDown = false;
            toTheOriginal = false;
        }

        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, coinSprite.GetWidth(), coinSprite.GetHeight());
            }

        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
        }
        public void ReverseDirection()
        {
            //NO OP
        }
        public void Update()
        {
            if (appears)
            {
                if (moveUpAndDown)
                {
                    if (!toTheOriginal)
                    {
                        if (position.Y > minHeight - ItemUtil.coinMaxY)
                        {
                            position.Y -= ItemUtil.coinSpeedY;
                        }
                        else
                        {
                            toTheOriginal = true;
                        }
                    }
                    else
                    {
                        if (position.Y <= minHeight - ItemUtil.coinMinY)
                            position.Y += ItemUtil.coinSpeedY;
                        else
                        {
                            moveUpAndDown = false;
                            position.Y = minHeight;
                            toDestroy = true;

                        }
                    }
                    coinSprite.Update();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            //commented to appear
            if(appears)
            coinSprite.Draw(spriteBatch, camera.AdjustPosition(position));
        }

        public Vector2 GetPosition()
        {
            return position;
        }

        public void React()
        {  
                toDestroy = true;
        }

        public bool RemoveCheck()
        {
            return toDestroy;
        }

        public bool IsCollidable
        {
            get
            {
                return isCollidable;
            }
            set => isCollidable = value;
        }
        public void Appears()
        {
            CoinCounter.Instance.Increment();
            SoundManager.Instance.Coin();
            IsCollidable = true;
            appears = true;
            moveUpAndDown = true;
            toTheOriginal = false;
            if (!reacted)
            {
                reacted = true;
                Singleton.Instance.AddPoints(ItemUtil.coinScore, this);
            }
        }

        public ref Vector2 GetPositionRef()
        {
            return ref position;
        }
        public bool IsActivated()
        {
            return appears;
        }
    }
}
