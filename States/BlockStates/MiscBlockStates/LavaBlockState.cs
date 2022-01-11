using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class LavaBlockState : IBlockState
    {

        private LavaBlock lavaBlock;
        private ISprite lavaBlockSprite;
        private bool toDestroy;

        public LavaBlockState(LavaBlock block)
        {
            lavaBlock = block;
            lavaBlockSprite = BlockSpriteFactory.Instance.CreateLavaBlockSprite();
            toDestroy = false;
        }

        public void React()
        {

        }

        public void Update()
        {
            lavaBlockSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            lavaBlockSprite.Draw(spriteBatch, camera.AdjustPosition(lavaBlock.position));
        }

        public int GetWidth()
        {
            return lavaBlockSprite.GetWidth();
        }

        public int GetHeight()
        {
            return lavaBlockSprite.GetHeight();
        }

        public bool RemoveCheck()
        {
            return toDestroy;
        }
    }
}
