using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class ObjectiveSpriteFactory
    {
        private Texture2D flagSpritesheet;
        private Texture2D poleSpritesheet;
        private Texture2D axeSpritesheet;


        private static ObjectiveSpriteFactory instance = new ObjectiveSpriteFactory();

        public static ObjectiveSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ObjectiveSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            flagSpritesheet = content.Load<Texture2D>("flag");
            poleSpritesheet = content.Load<Texture2D>("pole");
            axeSpritesheet = content.Load<Texture2D>("axe");

        }

        public ISprite CreatePoleSprite()
        {
            return new FormalSpriteAbstract(poleSpritesheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
        public ISprite CreateFlagSprite()
        {
            return new FormalSpriteAbstract(flagSpritesheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
        public ISprite CreateAxeSprite()
        {
            return new FormalSpriteAbstract(axeSpritesheet, FactoryUtil.Spritebase, FactoryUtil.fourSeparatedSprite);
        }
    }

}
