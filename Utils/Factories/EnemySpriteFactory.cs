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
    public class EnemySpriteFactory
    {
        private Texture2D goombaSpritesheet;
        private Texture2D koopaSpritesheet;
        private Texture2D koopaLeftSpritesheet;
        private Texture2D koopaRightSpritesheet;
        private Texture2D goombaStompedSpritesheet;
        private Texture2D koopaStompedSpritesheet;
        private Texture2D flippedGoombaSpritesheet;
        private Texture2D flippedKoopaSpritesheet;
        private Texture2D openMouthBowserSpritesheet;
        private Texture2D closedMouthBowserSpritesheet;
        // More private Texture2Ds follow
        // ...

        private static EnemySpriteFactory instance = new EnemySpriteFactory();

        public static EnemySpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private EnemySpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            goombaSpritesheet = content.Load<Texture2D>("goomba");
            koopaSpritesheet = content.Load<Texture2D>("koopa");
            koopaRightSpritesheet = content.Load<Texture2D>("koopaRight");
            koopaLeftSpritesheet = content.Load<Texture2D>("koopaLeft");
            goombaStompedSpritesheet = content.Load<Texture2D>("stompedGoomba");
            koopaStompedSpritesheet = content.Load<Texture2D>("stompedKoopa");
            flippedGoombaSpritesheet = content.Load<Texture2D>("flippedGoomba");
            flippedKoopaSpritesheet = content.Load<Texture2D>("flippedKoopa");
            openMouthBowserSpritesheet = content.Load<Texture2D>("bowserOpenMouth");
            closedMouthBowserSpritesheet = content.Load<Texture2D>("bowserClosedMouth");

            // More Content.Load calls follow
            //...
        }

        public ISprite CreateGoombaSprite()
        {
            return new FormalSpriteAbstract(goombaSpritesheet, FactoryUtil.Spritebase, FactoryUtil.twoSeparatedSprite);
        }

        public ISprite CreateFlippedGoombaSprite()
        {
            return new FormalSpriteAbstract(flippedGoombaSpritesheet, FactoryUtil.Spritebase, FactoryUtil.twoSeparatedSprite);
        }
        public ISprite CreateStompedGoombaSprite()
        {
            return new FormalSpriteAbstract(goombaStompedSpritesheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }


        public ISprite CreateKoopaSprite()
        {
            return new FormalSpriteAbstract(koopaSpritesheet, FactoryUtil.Spritebase, FactoryUtil.fourSeparatedSprite);
        }

        public ISprite CreateRightKoopaSprite()
        {
            return new FormalSpriteAbstract(koopaRightSpritesheet, FactoryUtil.Spritebase, FactoryUtil.twoSeparatedSprite);
        }
        
        public ISprite CreateLeftKoopaSprite()
        {
            return new FormalSpriteAbstract(koopaLeftSpritesheet, FactoryUtil.Spritebase, FactoryUtil.twoSeparatedSprite);
        }
        public ISprite CreateFlippedKoopaSprite()
        {
            return new FormalSpriteAbstract(flippedKoopaSpritesheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
        public ISprite CreateStompedKoopaSprite()
        {
            return new FormalSpriteAbstract(koopaStompedSpritesheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
        public ISprite CreateOpenMouthBowserSprite()
        {
            return new FormalSpriteAbstract(openMouthBowserSpritesheet, FactoryUtil.Spritebase, FactoryUtil.twoSeparatedSprite);
        }
        public ISprite CreateClosedMouthBowserSprite()
        {
            return new FormalSpriteAbstract(closedMouthBowserSpritesheet, FactoryUtil.Spritebase, FactoryUtil.twoSeparatedSprite);
        }
        public ISprite CreateDeadBowserSprite()
        {
            return new FormalSpriteAbstract(flippedGoombaSpritesheet, FactoryUtil.Spritebase, FactoryUtil.twoSeparatedSprite);
        }
    }
}
