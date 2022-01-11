using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class LavaTopBlockState : IBlockState
    {

        private LavaTopBlock lavaTopBlock;
        private ISprite lavaTopBlockSprite;
        private bool toDestroy;

        public LavaTopBlockState(LavaTopBlock block)
        {
            lavaTopBlock = block;
            lavaTopBlockSprite = BlockSpriteFactory.Instance.CreateLavaTopBlockSprite();
            toDestroy = false;
        }

        public void React()
        {

        }

        public void Update()
        {
            lavaTopBlockSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            lavaTopBlockSprite.Draw(spriteBatch, camera.AdjustPosition(lavaTopBlock.position));
        }

        public int GetWidth()
        {
            return lavaTopBlockSprite.GetWidth();
        }

        public int GetHeight()
        {
            return lavaTopBlockSprite.GetHeight();
        }

        public bool RemoveCheck()
        {
            return toDestroy;
        }
    }
}
