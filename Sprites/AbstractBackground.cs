using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaghetti
{
    public abstract class AbstractBackground: IBackground
    {
        protected ISprite sprite;
        private Vector2 position;
        protected AbstractBackground(int x, int y)
        {
            position = new Vector2(x, y);
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            sprite.Draw(spriteBatch, camera.AdjustPosition(position));
        }

    }
}
