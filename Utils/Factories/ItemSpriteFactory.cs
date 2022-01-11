using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using Microsoft.Xna.Framework.Content;

namespace Spaghetti
{
    public class ItemSpriteFactory
    {
        private Texture2D itemSpriteSheet;
        private Texture2D fireFlowerSheet;
        private Texture2D starSheet;
        private Texture2D redMushroomSheet;
        private Texture2D greenMushroomSheet;
        private static ItemSpriteFactory instance = new ItemSpriteFactory();
        public static ItemSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private ItemSpriteFactory()
        {

        }
        public void LoadAllTextures(ContentManager content)
        {
            itemSpriteSheet = content.Load<Texture2D>("Coin");
            fireFlowerSheet = content.Load<Texture2D>("FireFlower");
            starSheet = content.Load<Texture2D>("star");
            redMushroomSheet = content.Load<Texture2D>("RedMushroom");
            greenMushroomSheet = content.Load<Texture2D>("greenMushroom");


            
        }
        public ISprite CreateCoinSprite()
        {
            return new FormalSpriteAbstract(itemSpriteSheet, FactoryUtil.Spritebase, FactoryUtil.fourSeparatedSprite);
        }
        public ISprite CreateFireFlowerSprite()
        {
            return new FormalSpriteAbstract(fireFlowerSheet, FactoryUtil.Spritebase, FactoryUtil.fourSeparatedSprite);
        }
        public ISprite CreateExtraLifeGreenMushroomSprite()
        {
            return new FormalSpriteAbstract(greenMushroomSheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
        public ISprite CreateLevelUpRedMushroomSprite()
        {
            return new FormalSpriteAbstract(redMushroomSheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
        public ISprite CreateStarSprite()
        {
            return new FormalSpriteAbstract(starSheet, FactoryUtil.Spritebase, FactoryUtil.fourSeparatedSprite);
        }
    }
}
