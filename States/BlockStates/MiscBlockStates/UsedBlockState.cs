using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    class UsedBlockState: IBlockState
    {

        private UsedBlock usedBlock;
        private ISprite usedBlockSprite;
        private bool toDestroy;

        public UsedBlockState(UsedBlock block)
        {
            usedBlock = block;
            usedBlockSprite = BlockSpriteFactory.Instance.CreateUsedBlockSprite();
            toDestroy = false;
        }

        public void React()
        {

        }

        public void Update()
        {
            usedBlockSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            usedBlockSprite.Draw(spriteBatch, camera.AdjustPosition(usedBlock.position));
        }

        public int GetWidth()
        {
            return usedBlockSprite.GetWidth();
        }

        public int GetHeight()
        {
            return usedBlockSprite.GetHeight();
        }

        public bool RemoveCheck()
        {
            return toDestroy;
        }


    }
}
