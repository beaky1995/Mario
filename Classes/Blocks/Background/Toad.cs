using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class Toad: IBackground
    {
        public ISprite toadSprite;
        public Vector2 position;
        
        public Toad(int x, int y)
        {
            position.X = x;
            position.Y = y+BlockMoveUtil.toadYAdjust;
            toadSprite = BackgroundSpriteFactory.Instance.CreateToadSprite();
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            toadSprite.Draw(spriteBatch, camera.AdjustPosition(position));
        }

        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, toadSprite.GetWidth(), toadSprite.GetHeight());
            }

        }
    }
}
