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
    public class PipeSpriteFactory
    {
        private Texture2D pipeSpritesheet;
        

        private static PipeSpriteFactory instance = new PipeSpriteFactory();

        public static PipeSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private PipeSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            pipeSpritesheet = content.Load<Texture2D>("pipe");
            
        }

        public ISprite CreateStandardPipeSprite()
        {
            return new FormalSpriteAbstract(pipeSpritesheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
    }
}
