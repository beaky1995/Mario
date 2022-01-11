using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class WarpPipe : IPipe
    {
        private bool isCollidable { get; set; }
        public ISprite pipeSprite;
        public Vector2 position;
        public Vector2 warpLocation;

        public WarpPipe(int x, int y, int warpX, int warpY)
        {
            IsCollidable = true;
            position.X = x;
            position.Y = y;
            warpLocation.X = warpX;
            warpLocation.Y = warpY;
            pipeSprite = PipeSpriteFactory.Instance.CreateStandardPipeSprite();
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            pipeSprite.Draw(spriteBatch, camera.AdjustPosition(position));
        }

        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, pipeSprite.GetWidth(), pipeSprite.GetHeight());
            }
        }

        public bool IsCollidable
        {
            get
            {
                return isCollidable;
            }
            set => isCollidable = value;
        }

        public string GetPipeType()
        {
            return "WarpPipe";
        }

        public Vector2 GetWarpLocation()
        {
            return warpLocation;
        }
    }
}
