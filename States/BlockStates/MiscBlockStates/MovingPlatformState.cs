using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class MovingPlatformState : IBlockState
    {

        private MovingPlatform movingPlatform;
        private ISprite movingPlatformSprite;
        private bool toDestroy;

        public MovingPlatformState(MovingPlatform platform)
        {
            movingPlatform = platform;
            movingPlatformSprite = BlockSpriteFactory.Instance.CreateMovingPlatformSprite();
            toDestroy = false;
        }

        public void React()
        {

        }

        public void Update()
        {
            movingPlatformSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            movingPlatformSprite.Draw(spriteBatch, camera.AdjustPosition(movingPlatform.position));
        }

        public int GetWidth()
        {
            return movingPlatformSprite.GetWidth();
        }

        public int GetHeight()
        {
            return movingPlatformSprite.GetHeight();
        }

        public bool RemoveCheck()
        {
            return toDestroy;
        }
    }
}
