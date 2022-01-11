using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class FloorBlockState : IBlockState
    {

        private FloorBlock floorBlock;
        private ISprite floorBlockSprite;
        private bool toDestroy;

        public FloorBlockState(FloorBlock block)
        {
            floorBlock = block;
            //floorBlock.
            floorBlockSprite = BlockSpriteFactory.Instance.CreateFloorBlockSprite();
            toDestroy = false;
        }

        public void React()
        {

        }

        public void Update()
        {
            floorBlockSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            floorBlockSprite.Draw(spriteBatch, camera.AdjustPosition(floorBlock.position));
        }

        public int GetWidth()
        {
            return floorBlockSprite.GetWidth();
        }

        public int GetHeight()
        {
            return floorBlockSprite.GetHeight();
        }

        public bool RemoveCheck()
        {
            return toDestroy;
        }
    }
}
