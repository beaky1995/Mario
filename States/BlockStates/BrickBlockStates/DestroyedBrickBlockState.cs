using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class DestroyedBrickBlockState : IBlockState
    {
        private BrickBlock destroyedBlock;
        private ISprite destroyedBlockSprite;
        private bool toDestroy;

        public DestroyedBrickBlockState(BrickBlock block)
        {
            destroyedBlock = block;
            destroyedBlockSprite = BlockSpriteFactory.Instance.CreateDestroyedSprite();
            toDestroy = false;
        }

        public void React()
        {
            toDestroy = true;
        }

        public void Update()
        {
            destroyedBlockSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
           destroyedBlockSprite.Draw(spriteBatch, camera.AdjustPosition(destroyedBlock.position));
        }

        public int GetWidth()
        {
            return destroyedBlockSprite.GetWidth();
        }

        public int GetHeight()
        {
            return destroyedBlockSprite.GetHeight();
        }

        public bool RemoveCheck()
        {
            return toDestroy;
        }
    }
}