using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class UsedHiddenBlockState: IBlockState
    {

        private HiddenBlock usedBlock;
        private ISprite usedHiddenBlockSprite;
        private bool toDestroy;

        public UsedHiddenBlockState(HiddenBlock block)
        {
            usedBlock = block;
            
            usedHiddenBlockSprite = BlockSpriteFactory.Instance.CreateUsedBlockSprite();
            toDestroy = false;
        }

       public void React()
        {

        }

        public void Update()
        {
            usedHiddenBlockSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            usedHiddenBlockSprite.Draw(spriteBatch, camera.AdjustPosition(usedBlock.position));
        }

        public int GetWidth()
        {
            return usedHiddenBlockSprite.GetWidth();
        }

        public int GetHeight()
        {
            return usedHiddenBlockSprite.GetHeight();
        }

        public bool RemoveCheck()
        {
            return toDestroy;
        }
    }
}
