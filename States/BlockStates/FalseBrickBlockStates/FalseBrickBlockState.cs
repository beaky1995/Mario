using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class FalseBrickBlockState: IBlockState
    {
        
        private FalseBrickBlock falseBrickBlock;
        private ISprite falseBrickBlockSprite;
        private bool toDestroy;
        public FalseBrickBlockState(FalseBrickBlock block)
        {
            falseBrickBlock = block;
            falseBrickBlockSprite = BlockSpriteFactory.Instance.CreateBrickBlockSprite();
            toDestroy = false;
        }

        public void React()
        {
            falseBrickBlock.State = new UsedFalseBrickBlockState(falseBrickBlock);
        }

        public void Update()
        {
            falseBrickBlockSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            falseBrickBlockSprite.Draw(spriteBatch, camera.AdjustPosition(falseBrickBlock.position));
        }

        public int GetWidth()
        {
            return falseBrickBlockSprite.GetWidth();
        }

        public int GetHeight()
        {
            return falseBrickBlockSprite.GetHeight();
        }

        public bool RemoveCheck()
        {
            return toDestroy;
        }
    }
}
