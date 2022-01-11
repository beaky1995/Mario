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
    public class FireballSpriteFactory
    {
        private Texture2D fireballSpritesheet;
        private Texture2D fireSpearSpritesheet;


        private static FireballSpriteFactory instance = new FireballSpriteFactory();

        public static FireballSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private FireballSpriteFactory()
        {


        }

        public void LoadAllTextures(ContentManager content)
        {
            fireballSpritesheet = content.Load<Texture2D>("animatedFireball2");
            fireSpearSpritesheet = content.Load<Texture2D>("firespear");
            
        }

        public ISprite CreateStandardFireballSprite()
        {
            return new FormalSpriteAbstract(fireballSpritesheet, FactoryUtil.Spritebase, FactoryUtil.fourSeparatedSprite);
        }

        public ISprite CreateFireSpearSprite()
        {
            return new FormalSpriteAbstract(fireSpearSpritesheet, FactoryUtil.Spritebase, FactoryUtil.twoSeparatedSprite);
        }
    }
}
