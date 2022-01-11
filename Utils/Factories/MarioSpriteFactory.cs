using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Spaghetti
{
    class MarioSpriteFactory
    {
        //private Texture2D marioSpriteSheet;
        private Texture2D diedMarioSpriteSheet;
        private Texture2D leftBigMarioCrouchingSpriteSheet;
        private Texture2D leftBigMarioIdleSpriteSheet;
        private Texture2D leftBigMarioRunningSpriteSheet;
        private Texture2D leftBigMarioJumpingSpriteSheet;
        private Texture2D leftFireMarioCrouchingSpriteSheet;
        private Texture2D leftFireMarioRunningSpriteSheet;
        private Texture2D leftFireMarioIdleSpriteSheet;
        private Texture2D leftFireMarioJumpingSpriteSheet;
        private Texture2D leftSmallMarioIdleSpriteSheet;
        private Texture2D leftSmallMarioJumpingSpriteSheet;
        private Texture2D leftSmallMarioRunningSpriteSheet;
        private Texture2D rightBigMarioCrouchingSpriteSheet;
        private Texture2D rightBigMarioIdleSpriteSheet;
        private Texture2D rightBigMarioRunningSpriteSheet;
        private Texture2D rightBigMarioJumpingSpriteSheet;
        private Texture2D rightFireMarioCrouchingSpriteSheet;
        private Texture2D rightFireMarioIdleSpriteSheet;
        private Texture2D rightFireMarioJumpingSpriteSheet;
        private Texture2D rightFireMarioRunningSpriteSheet;
        private Texture2D rightSmallMarioIdleSpriteSheet;
        private Texture2D rightSmallMarioJumpingSpriteSheet;
        private Texture2D rightSmallMarioRunningSpriteSheet;





        private static MarioSpriteFactory instance = new MarioSpriteFactory();
        public static MarioSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private MarioSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            //marioSpriteSheet = content.Load<Texture2D>("smb_mario_sheet");
            leftBigMarioCrouchingSpriteSheet = content.Load<Texture2D>("leftBigMarioCrouching");
            leftBigMarioIdleSpriteSheet = content.Load<Texture2D>("leftBigMarioIdle");
            leftBigMarioRunningSpriteSheet = content.Load<Texture2D>("leftBigMarioRunning");
            leftFireMarioCrouchingSpriteSheet = content.Load<Texture2D>("leftFireMarioCrouching");
            leftFireMarioRunningSpriteSheet = content.Load<Texture2D>("leftFireMarioRunning");
            leftSmallMarioIdleSpriteSheet = content.Load<Texture2D>("leftSmallMarioIdle");
            leftSmallMarioJumpingSpriteSheet = content.Load<Texture2D>("leftSmallMarioJump");
            leftSmallMarioRunningSpriteSheet = content.Load<Texture2D>("leftSmallMarioRunning");
            leftBigMarioJumpingSpriteSheet = content.Load<Texture2D>("leftBigMarioJump");
            leftFireMarioJumpingSpriteSheet = content.Load<Texture2D>("leftFireMairoJump");
            leftFireMarioIdleSpriteSheet = content.Load<Texture2D>("leftFireMarioIdle");
            rightBigMarioCrouchingSpriteSheet = content.Load<Texture2D>("rightBigMarioCrouching");
            rightBigMarioIdleSpriteSheet = content.Load<Texture2D>("rightBigMarioIdle");
            rightBigMarioRunningSpriteSheet = content.Load<Texture2D>("rightBigMarioRunning");
            rightFireMarioCrouchingSpriteSheet = content.Load<Texture2D>("rightFireMarioCrouching");
            rightFireMarioIdleSpriteSheet = content.Load<Texture2D>("rightFireMarioIdle");
            rightFireMarioRunningSpriteSheet = content.Load<Texture2D>("rightFireMarioRunning");
            rightSmallMarioIdleSpriteSheet = content.Load<Texture2D>("rightSmallMarioIlde");
            rightSmallMarioJumpingSpriteSheet = content.Load<Texture2D>("rightSmallMarioJump");
            rightSmallMarioRunningSpriteSheet = content.Load<Texture2D>("rightSmallMarioRunning");
            rightBigMarioJumpingSpriteSheet = content.Load<Texture2D>("rightBigMarioJump");
            rightFireMarioJumpingSpriteSheet = content.Load<Texture2D>("rightFireMarioJump");
            diedMarioSpriteSheet = content.Load<Texture2D>("diedMario");


        }


        public ISprite CreateMarioDeadSprite()
        {
            return new FormalSpriteAbstract(diedMarioSpriteSheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
        public ISprite CreateMarioLeftBigCrouchingSprite()
        {
            return new FormalSpriteAbstract(leftBigMarioCrouchingSpriteSheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
        public ISprite CreateMarioLeftBigIdleSprite()
        {
            return new FormalSpriteAbstract(leftBigMarioIdleSpriteSheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
        public ISprite CreateMarioLeftBigJumpingSprite()
        {
            return new FormalSpriteAbstract(leftBigMarioJumpingSpriteSheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
        public ISprite CreateMarioLeftBigRunningSprite()
        {
            return new FormalSpriteAbstract(leftBigMarioRunningSpriteSheet, FactoryUtil.Spritebase, FactoryUtil.threeSeparatedSprite);
        }
        public ISprite CreateMarioLeftFireCrouchingSprite()
        {
            return new FormalSpriteAbstract(leftFireMarioCrouchingSpriteSheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
        public ISprite CreateMarioLeftFireIdleSprite()
        {
            return new FormalSpriteAbstract(leftFireMarioIdleSpriteSheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
        public ISprite CreateMarioLeftFireJumpingSprite()
        {
            return new FormalSpriteAbstract(leftFireMarioJumpingSpriteSheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
        public ISprite CreateMarioLeftFireRunningSprite()
        {
            return new FormalSpriteAbstract(leftFireMarioRunningSpriteSheet, FactoryUtil.Spritebase, FactoryUtil.threeSeparatedSprite);
        }
        public ISprite CreateMarioLeftSmallIdleSprite()
        {
            return new FormalSpriteAbstract(leftSmallMarioIdleSpriteSheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
        public ISprite CreateMarioLeftSmallJumpingSprite()
        {
            return new FormalSpriteAbstract(leftSmallMarioJumpingSpriteSheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
        public ISprite CreateMarioLeftSmallRunningSprite()
        {
            return new FormalSpriteAbstract(leftSmallMarioRunningSpriteSheet, FactoryUtil.Spritebase, FactoryUtil.threeSeparatedSprite);
        }
        public ISprite CreateMarioRightBigCrouchingSprite()
        {
            return new FormalSpriteAbstract(rightBigMarioCrouchingSpriteSheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
        public ISprite CreateMarioRightBigIdleSprite()
        {
            return new FormalSpriteAbstract(rightBigMarioIdleSpriteSheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
        public ISprite CreateMarioRightBigJumpingSprite()
        {
            return new FormalSpriteAbstract(rightBigMarioJumpingSpriteSheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
        public ISprite CreateMarioRightBigRunningSprite()
        {
            return new FormalSpriteAbstract(rightBigMarioRunningSpriteSheet, FactoryUtil.Spritebase, FactoryUtil.threeSeparatedSprite);
        }
        public ISprite CreateMarioRightFireCrouchingSprite()
        {
            return new FormalSpriteAbstract(rightFireMarioCrouchingSpriteSheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
        public ISprite CreateMarioRightFireIdleSprite()
        {
            return new FormalSpriteAbstract(rightFireMarioIdleSpriteSheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
        public ISprite CreateMarioRightFireJumpingSprite()
        {
            return new FormalSpriteAbstract(rightFireMarioJumpingSpriteSheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
        public ISprite CreateMarioRightFireRunningSprite()
        {
            return new FormalSpriteAbstract(rightFireMarioRunningSpriteSheet, FactoryUtil.Spritebase, FactoryUtil.threeSeparatedSprite);
        }
        public ISprite CreateMarioRightSmallIdleSprite()
        {
            return new FormalSpriteAbstract(rightSmallMarioIdleSpriteSheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
        public ISprite CreateMarioRightSmallJumpingSprite()
        {
            return new FormalSpriteAbstract(rightSmallMarioJumpingSpriteSheet, FactoryUtil.Spritebase, FactoryUtil.Spritebase);
        }
        public ISprite CreateMarioRightSmallRunningSprite()
        {
            return new FormalSpriteAbstract(rightSmallMarioRunningSpriteSheet, FactoryUtil.Spritebase, FactoryUtil.threeSeparatedSprite);
        }

    }
}
