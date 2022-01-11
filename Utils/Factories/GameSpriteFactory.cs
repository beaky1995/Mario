using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaghetti
{ 

    public class GameSpriteFactory
    {
        private Texture2D levelOne;
        private Texture2D levelTwo;


        private static GameSpriteFactory instance = new GameSpriteFactory();

        public static GameSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private GameSpriteFactory()
        {


        }

        public void LoadAllTextures(ContentManager content)
        {
            levelOne = content.Load<Texture2D>("title1");
            levelTwo = content.Load<Texture2D>("title2");

        }

        public ISprite CreateTitleOneSprite()
        {
            return new FormalSpriteAbstract(levelOne, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
        public ISprite CreateTitleTwoSprite()
        {
            return new FormalSpriteAbstract(levelTwo, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
    }
}

