using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class DrawbridgeChainBlock: IBlock
    {
        private ISprite drawbridgeChainSprite;
        private IBlockState state { get; set; }
        private bool isCollidable { get; set; }
        public Vector2 position;

        private bool isBumped { get; set; }

        public DrawbridgeChainBlock(int x, int y)
        {
            position.X = x;
            position.Y = y;
            drawbridgeChainSprite = BlockSpriteFactory.Instance.CreateDrawbridgeChainSprite();
            IsCollidable = false;
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
                return new Rectangle((int)position.X, (int)position.Y, drawbridgeChainSprite.GetWidth(), drawbridgeChainSprite.GetHeight());
            }

        }
        public void React(int a)
        {
            //No action
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            drawbridgeChainSprite.Draw(spriteBatch, camera.AdjustPosition(position));
        }

        public bool RemoveCheck()
        {
            return false; //Change later to have drawbridge disappear with Axe obtained
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
            set => isCollidable = value;
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
            return "DrawbridgeChainBlock";
        }
    }
}
