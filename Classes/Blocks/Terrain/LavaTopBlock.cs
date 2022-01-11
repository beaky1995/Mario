using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class LavaTopBlock : IBlock
    {
        private ISprite lavaTopBlockSprite;
        private IBlockState state { get; set; }
        private bool isCollidable { get; set; }
        public Vector2 position;

        private bool isBumped { get; set;  }
        
        public LavaTopBlock(int x, int y)
        {
            position.X = x;
            position.Y = y;
            lavaTopBlockSprite = BlockSpriteFactory.Instance.CreateLavaTopBlockSprite();
            State = new LavaTopBlockState(this);
            IsCollidable = true;
            IsBumped = true;
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
            //No action
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            lavaTopBlockSprite.Draw(spriteBatch, camera.AdjustPosition(position));
        }

        public bool RemoveCheck()
        {
            return false; //may be able to change with later implementation of floor-block states
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
            SoundManager.Instance.Bump();

        }
        public void SetItem(IItem item)
        {

        }

        public string GetBlockType()
        {
            return "LavaTopBlock";
        }
    }
}
