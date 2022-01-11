using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class UnbreakableBlock : IBlock
    {
        public ISprite unbreakableBlockSprite;
        private IBlockState state { get; set; }
        private bool isCollidable { get; set; }
        public Vector2 position;


        private bool isBumped { get; set;  }
        
        public UnbreakableBlock(int x, int y)
        {
            position.X = x;
            position.Y = y;
            unbreakableBlockSprite = BlockSpriteFactory.Instance.CreateBlockUnbreakableSprite();
            State = new UnbreakableBlockState(this);
            IsCollidable = true;
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
            //NO OP
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            unbreakableBlockSprite.Draw(spriteBatch, camera.AdjustPosition(position));
        }

        public bool RemoveCheck()
        {
            return false ;
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
            set { }
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
            return "UnbreakableBlock";
        }
    }
}
