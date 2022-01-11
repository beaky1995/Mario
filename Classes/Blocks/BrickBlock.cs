using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class BrickBlock : IBlock
    {

        //ALL BLOCKS HAVE A NORMAL/ BUMPED STATE ENUM.


        private IBlockState state { get; set; }
        private bool isCollidable { get; set; }
        public Vector2 position;
        private bool toDestroy;
        private bool moveUpAndDown;
        private float originalPositionY;
        private bool toTheOriginal;


        private bool isBumped { get; set; }
      

        public BrickBlock(int x, int y)
        {
            position.X = x;
            position.Y = y;
            State = new BrickBlockState(this);
            IsCollidable = true;
            toDestroy = false;
            moveUpAndDown = false;
            toTheOriginal = false;
            originalPositionY = position.Y;
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
            toDestroy = true;
            SoundManager.Instance.BreakBlock();

        }

        public bool RemoveCheck()
        {
            return toDestroy;
        }

        public void Update()
        {
            if (moveUpAndDown)
            {
             if (!toTheOriginal)
                {
                    if (position.Y > originalPositionY - BlockMoveUtil.maxY )
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
                    if (position.Y <= originalPositionY )
                        position.Y += BlockMoveUtil.speedY;
                    else
                    {
                        IsBumped = false;
                        moveUpAndDown = false;
                        position.Y = originalPositionY;
                    }
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            state.Draw(spriteBatch, camera);
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
        }

        public string GetBlockType()
        {
            return "BrickBlock";
        }

    }
}
