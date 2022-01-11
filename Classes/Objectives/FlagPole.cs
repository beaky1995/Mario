using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class Flagpole : IObjective
    {
        public ISprite flagSprite;
        public ISprite poleSprite;
        public Vector2 position;
        public Vector2 flagPosition;
        public bool isDown;
        private bool isCollidable { get; set; }

        public Flagpole(int x, int y)
        {
            position.X = x;
            position.Y = y;
            flagPosition.X = position.X;
            flagPosition.X -= FlagpoleUtil.flagSpeedX;
            flagPosition.Y = position.Y;
            flagPosition.Y += FlagpoleUtil.flagSpeedY;
            isDown = false;

            flagSprite = ObjectiveSpriteFactory.Instance.CreateFlagSprite();
            poleSprite = ObjectiveSpriteFactory.Instance.CreatePoleSprite();

        }

        public void Update()
        {
            if (isDown)
            {
                if (flagPosition.Y <= FlagpoleUtil.flagMaxY) //"drop" to height of unbreakable block base of flagpole 
                {
                    flagPosition.Y++;
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            flagSprite.Draw(spriteBatch, camera.AdjustPosition(flagPosition));
            poleSprite.Draw(spriteBatch, camera.AdjustPosition(position));
        }

        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, poleSprite.GetWidth(), poleSprite.GetHeight());
            }
            
        }

        public void React()
        {
            isDown = true;
    
        }

        public bool RemoveCheck()
        {
            return false;
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
