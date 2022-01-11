using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class DrawbridgeBlock: IBlock
    {
        private ISprite drawbridgeBlockSprite;
        private IBlockState state { get; set; }
        private bool isCollidable { get; set; }
        public Vector2 position;
        private bool isActive;

        private bool isBumped { get; set; }

        public DrawbridgeBlock(int x, int y)
        {
            position.X = x;
            position.Y = y;
            drawbridgeBlockSprite = BlockSpriteFactory.Instance.CreateDrawbridgeBlockSprite();
            IsCollidable = true;
            IsBumped = false;
            isActive = false;
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
                return new Rectangle((int)position.X, (int)position.Y, drawbridgeBlockSprite.GetWidth(), drawbridgeBlockSprite.GetHeight());
            }

        }
        public void React(int a)
        {
            //no-reaction
        }

        public void Update()
        {
            if (Singleton.Instance.getAxe)
            {
                isActive = true;
            }

        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            drawbridgeBlockSprite.Draw(spriteBatch, camera.AdjustPosition(position));
        }

        public bool RemoveCheck()
        {
            return isActive; //Change later to have drawbridge disappear with Axe obtained
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
            return "DrawbridgeBlock";
        }
    }
}
