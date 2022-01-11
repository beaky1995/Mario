using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class UnbreakableBlockState : IBlockState
    {

        private UnbreakableBlock unbreakableBlock;
        private ISprite unbreakableBlockSprite;
        private bool toDestroy;

        public UnbreakableBlockState(UnbreakableBlock block)
        {
            unbreakableBlock = block;
            unbreakableBlockSprite = BlockSpriteFactory.Instance.CreateBlockUnbreakableSprite();
            toDestroy = false;
        }

        public void React()
        {

        }

        public void Update()
        {
            unbreakableBlockSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            unbreakableBlockSprite.Draw(spriteBatch, camera.AdjustPosition(unbreakableBlock.position));
        }

        public int GetWidth()
        {
            return unbreakableBlockSprite.GetWidth();
        }

        public int GetHeight()
        {
            return unbreakableBlockSprite.GetHeight();
        }

        public bool RemoveCheck()
        {
            return toDestroy;
        }
    }
}
