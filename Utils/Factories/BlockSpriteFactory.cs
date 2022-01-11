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
    public class BlockSpriteFactory
    {
        private Texture2D questionBlockSpritesheet;
        private Texture2D usedBlockSpritesheet;
        private Texture2D brickBlockSpritesheet;
        private Texture2D unbreakableBlockSpritesheet;
        private Texture2D hiddenBlockSpritesheet;
        private Texture2D floorBlockSpritesheet;
        private Texture2D stoneFloorBlockSpriteSheet;
        private Texture2D lavaBlockSpritesheet;
        private Texture2D lavaTopBlockSpritesheet;
        private Texture2D movingPlatformSpritesheet;
        private Texture2D drawbridgeSpritesheet;
        private Texture2D drawbridgeChainSpritesheet;
        // More private Texture2Ds follow
        // ...

        private static BlockSpriteFactory instance = new BlockSpriteFactory();

        public static BlockSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private BlockSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            questionBlockSpritesheet = content.Load<Texture2D>("questionBlock");
            usedBlockSpritesheet = content.Load<Texture2D>("usedBlock");
            brickBlockSpritesheet = content.Load<Texture2D>("brickBlock"); 
            unbreakableBlockSpritesheet = content.Load<Texture2D>("unbreakableBlock");
            hiddenBlockSpritesheet = content.Load<Texture2D>("hiddenBlock");
            floorBlockSpritesheet = content.Load<Texture2D>("floorBlock");
            stoneFloorBlockSpriteSheet = content.Load<Texture2D>("stoneFloorBlock");
            lavaBlockSpritesheet = content.Load<Texture2D>("lavaBlock");
            lavaTopBlockSpritesheet = content.Load<Texture2D>("lavaTopBlock");
            movingPlatformSpritesheet = content.Load<Texture2D>("movingPlatform");
            drawbridgeSpritesheet = content.Load<Texture2D>("drawBridgeBlock");
            drawbridgeChainSpritesheet = content.Load<Texture2D>("drawBridgeChain");

        }

        public ISprite CreateStoneFloorBlockSprite()
        {
            return new FormalSpriteAbstract(stoneFloorBlockSpriteSheet, 1, 1);
        }
        public ISprite CreateQuestionBlockSprite()
        {
            return new FormalSpriteAbstract(questionBlockSpritesheet, FactoryUtil.Spritebase, FactoryUtil.threeSeparatedSprite);
        }

        public ISprite CreateUsedBlockSprite()
        {
            return new FormalSpriteAbstract(usedBlockSpritesheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
        public ISprite CreateBrickBlockSprite()
        {
            return new FormalSpriteAbstract(brickBlockSpritesheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }

        public ISprite CreateBlockUnbreakableSprite()
        {
            return new FormalSpriteAbstract(unbreakableBlockSpritesheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }

        public ISprite CreateDestroyedSprite()
        {
            return new FormalSpriteAbstract(hiddenBlockSpritesheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase); 
        }

        public ISprite CreateHiddenBlockSprite()
        {
            return new FormalSpriteAbstract(hiddenBlockSpritesheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase); 
        }

        public ISprite CreateFloorBlockSprite()
        {
            return new FormalSpriteAbstract(floorBlockSpritesheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }

        public ISprite CreateLavaBlockSprite()
        {
            return new FormalSpriteAbstract(lavaBlockSpritesheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
        public ISprite CreateLavaTopBlockSprite()
        {
            return new FormalSpriteAbstract(lavaTopBlockSpritesheet, FactoryUtil.Spritebase, FactoryUtil.twoSeparatedSprite);
        }
        public ISprite CreateMovingPlatformSprite()
        {
            return new FormalSpriteAbstract(movingPlatformSpritesheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
        public ISprite CreateDrawbridgeBlockSprite()
        {
            return new FormalSpriteAbstract(drawbridgeSpritesheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
        public ISprite CreateDrawbridgeChainSprite()
        {
            return new FormalSpriteAbstract(drawbridgeChainSpritesheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
    }
}
