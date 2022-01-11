using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaghetti
{ 
    public class StartMenu
    {
        private Vector2 position;
        ISprite menuSprite;
        public StartMenu(int x, int y)
        {
            position.X = x;
            position.Y = y;
            menuSprite = GameSpriteFactory.Instance.CreateTitleOneSprite();

        }
        public void Update()
        {
            if(Singleton.Instance.isLevel == 2)
            {
                menuSprite = GameSpriteFactory.Instance.CreateTitleTwoSprite();
            }
            else
            {
                menuSprite = GameSpriteFactory.Instance.CreateTitleOneSprite();
            }
        }
        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            if(!Singleton.Instance.displayLevel)
            menuSprite.Draw(spriteBatch, camera.AdjustPosition(position));
        }
    }
}
