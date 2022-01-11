using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class StoneFloorBlock: IBlock
    {
        private ISprite floorBlockSprite;
        private IBlockState state { get; set; }
        private bool isCollidable { get; set; }
        public Vector2 position;

        private bool isBumped { get; set; }

        public StoneFloorBlock(int x, int y)
        {
            position.X = x;
            position.Y = y;
            floorBlockSprite = BlockSpriteFactory.Instance.CreateStoneFloorBlockSprite();
            //State = new FloorBlockState(this);
            IsCollidable = true;
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
                return new Rectangle((int)position.X, (int)position.Y, floorBlockSprite.GetWidth(), floorBlockSprite.GetHeight());
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
            floorBlockSprite.Draw(spriteBatch, camera.AdjustPosition(position));
        }

        public bool RemoveCheck()
        {
            return false; //may be able to change with later implementation of floor-block states
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
            return "FloorBlock";
        }
    }
}
