using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class BrickBlockState : IBlockState
    {
        private BrickBlock brickBlock;
        private ISprite brickBlockSprite;
        private bool toDestroy;
        public BrickBlockState(BrickBlock block)
        {
            brickBlock = block;
            brickBlockSprite = BlockSpriteFactory.Instance.CreateBrickBlockSprite();
            toDestroy = false;
        }

        public void React()
        {
            brickBlock.State = new DestroyedBrickBlockState(brickBlock);
        }


        public void Update()
        {
            brickBlockSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            brickBlockSprite.Draw(spriteBatch, camera.AdjustPosition(brickBlock.position));
        }

        public int GetWidth()
        {
           return brickBlockSprite.GetWidth();
        }

       public int GetHeight()
        {
           return brickBlockSprite.GetHeight();
        }

        public bool RemoveCheck()
        {
            return toDestroy;
        }

    }
}