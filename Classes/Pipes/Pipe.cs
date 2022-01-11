using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class Pipe : IPipe
    {
        private bool isCollidable { get; set; }
        public ISprite pipeSprite;
        public Vector2 position;
        
        public Pipe(int x, int y)
        {
            IsCollidable = true;
            position.X = x;
            position.Y = y;
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
            set { }
        }

        public Vector2 GetWarpLocation()
        {
            // should never be called
            return new Vector2();
        }

        public string GetPipeType()
        {
            return "Pipe";
        }
    }
}
