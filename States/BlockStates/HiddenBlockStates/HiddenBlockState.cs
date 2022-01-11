using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class HiddenBlockState: IBlockState
    {
        
        private HiddenBlock hiddenBlock;
        private ISprite hiddenBlockSprite;
        private bool toDestroy;
        public HiddenBlockState(HiddenBlock block)
        {
            hiddenBlock = block;
            hiddenBlockSprite = BlockSpriteFactory.Instance.CreateHiddenBlockSprite();
            toDestroy = false;
        }

        public void React()
        {
            hiddenBlock.State = new UsedHiddenBlockState(hiddenBlock);
        }

        public void Update()
        {
            hiddenBlockSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            hiddenBlockSprite.Draw(spriteBatch, camera.AdjustPosition(hiddenBlock.position));
        }

        public int GetWidth()
        {
            return hiddenBlockSprite.GetWidth();
        }

        public int GetHeight()
        {
            return hiddenBlockSprite.GetHeight();
        }

        public bool RemoveCheck()
        {
            return toDestroy;
        }

    }
}
