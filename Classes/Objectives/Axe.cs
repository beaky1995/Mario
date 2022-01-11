using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class Axe : IObjective
    {
        public ISprite axeSprite;
        public Vector2 position;
        public bool toDestroy;
        private bool isCollidable { get; set; }

        public Axe(int x, int y)
        {
            position.X = x;
            position.Y = y;
            toDestroy = false;
            IsCollidable = true;

            axeSprite = ObjectiveSpriteFactory.Instance.CreateAxeSprite();

        }

        public void Update()
        {
            

        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            axeSprite.Draw(spriteBatch, camera.AdjustPosition(position));
        }

        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, axeSprite.GetWidth(), axeSprite.GetHeight());
            }
            
        }

        public void React()
        {
            toDestroy = true;
    
        }

        public bool RemoveCheck()
        {
            return toDestroy;
        }

        public bool IsCollidable
        {
            get
            {
                return isCollidable;
            }
            set => isCollidable = value;
        }
    }
}
