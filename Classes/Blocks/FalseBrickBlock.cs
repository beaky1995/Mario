using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class FalseBrickBlock : IBlock
    {
        
        private IBlockState state { get; set; }  
        private bool isCollidable { get; set; }
        public Vector2 position;        
        private bool toDestroy;
        private bool moveUpAndDown;
        private float originalPositionY;
        private bool toTheOriginal;
        private bool toUsed;
        private IItem item;

        private bool isBumped { get; set; }
         

        public FalseBrickBlock(int x, int y)
        {
            position.X = x;
            position.Y = y;
            State = new FalseBrickBlockState(this);
            IsCollidable = true;
            toDestroy = false;
            moveUpAndDown = false;
            toTheOriginal = false;
            originalPositionY = position.Y;
            toUsed = false;
            item = new Coin((int)position.X, (int)position.Y);
            IsBumped = false;

        }

        public bool IsBumped
        {
            get
            {
                return isBumped;
            }
            set => isBumped = value;

        }

        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, state.GetWidth(), state.GetHeight());
            }

        }
        public void React(int a)
        {
            if (!toUsed)
            {
                item.Appears();
                state.React();
            }
        }

        public void Update()
        {
            if (moveUpAndDown && !toUsed)
            {
                if (!toTheOriginal)
                {
                    if (position.Y > originalPositionY - BlockMoveUtil.maxY)
                    {
                        position.Y -= BlockMoveUtil.speedY;
                    }
                    else
                    {
                        toTheOriginal = true;
                    }
                }
                else
                {
                    if (position.Y <= originalPositionY)
                        position.Y += BlockMoveUtil.speedY;
                    else
                    {
                        IsBumped = false;
                        moveUpAndDown = false;
                        position.Y = originalPositionY;
                        toUsed = true;
                    }
                }

            }
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            state.Draw(spriteBatch, camera);
        }

        public bool RemoveCheck()
        {
            return toDestroy;
        }

        public IBlockState State
        {
            get
            {
                return state;
            }
            set => state = value;
        }

        public bool IsCollidable 
        {
            get
            {
                return isCollidable;
            }
            set => isCollidable = value;
        }

        public void NonDestroy()
        {
            moveUpAndDown = true;
            toTheOriginal = false;
            SoundManager.Instance.Bump();

        }
        public void SetItem(IItem item)
        {
            this.item = item;
        }

        public string GetBlockType()
        {
            return "FalseBrickBlock";
        }
    }
}
