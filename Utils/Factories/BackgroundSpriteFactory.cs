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
    public class BackgroundSpriteFactory
    {
        private Texture2D bigMountainSpritesheet;
        private Texture2D singleBushSpritesheet;
        private Texture2D singleCloudSpritesheet;
        private Texture2D smallMountainSpritesheet;
        private Texture2D tripleBushSpritesheet;
        private Texture2D tripleCloudSpritesheet;
        private Texture2D castleSpritesheet;
        private Texture2D toadSpritesheet;
        // More private Texture2Ds follow

        private static BackgroundSpriteFactory instance = new BackgroundSpriteFactory();

        public static BackgroundSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private BackgroundSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            bigMountainSpritesheet = content.Load<Texture2D>("bigMountain");
            singleBushSpritesheet = content.Load<Texture2D>("singleBush");
            singleCloudSpritesheet = content.Load<Texture2D>("singleCloud");
            smallMountainSpritesheet = content.Load<Texture2D>("smallMountain");
            tripleBushSpritesheet = content.Load<Texture2D>("tripleBush");
            tripleCloudSpritesheet = content.Load<Texture2D>("tripleCloud");
            castleSpritesheet = content.Load<Texture2D>("castle");
            toadSpritesheet = content.Load<Texture2D>("toad");
        }

        public ISprite CreateBigMountainSprite()
        {
            return new FormalSpriteAbstract(bigMountainSpritesheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }

        public ISprite CreateSingleBushSprite()
        {
            return new FormalSpriteAbstract(singleBushSpritesheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
        public ISprite CreateSingleCloudSprite()
        {
            return new FormalSpriteAbstract(singleCloudSpritesheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }

        public ISprite CreateSmallMountainSprite()
        {
            return new FormalSpriteAbstract(smallMountainSpritesheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }

        public ISprite CreateTripleBushSprite()
        {
            return new FormalSpriteAbstract(tripleBushSpritesheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }

        public ISprite CreateTripleCloudSprite()
        {
            return new FormalSpriteAbstract(tripleCloudSpritesheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
        public ISprite CreateCastleSprite()
        {
            return new FormalSpriteAbstract(castleSpritesheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
        public ISprite CreateToadSprite()
        {
            return new FormalSpriteAbstract(toadSpritesheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
    }
}
