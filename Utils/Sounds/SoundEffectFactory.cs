using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Spaghetti
{
    public class SoundEffectFactory
    {
        private SoundEffect jumpSoundEffect;
        private SoundEffect fireballSoundEffect;
        private SoundEffect breakBlockSoundEffect;
        private SoundEffect bumpSoundEffect;
        private SoundEffect stompSoundEffect;
        private SoundEffect flipSoundEffect;

        private SoundEffect powerUpAppearsEffect;
        private SoundEffect coinEffect;
        private SoundEffect oneUpEffect;
        private SoundEffect marioPowerUpEffect;

        private SoundEffect marioTakeDamage;

        private SoundEffect pipeTravel;

        private Song backgroundMusic;
        private Song starMarioMusic;
        private Song gameOverMusic;
        private Song marioDieMusic;
        private Song timeRunningOutMusic;
        private Song endOfLevelMusic;

        private static SoundEffectFactory instance = new SoundEffectFactory();
        public static SoundEffectFactory Instance
        {
            get
            {
                return instance;
            }

        }

        private SoundEffectFactory()
        {

        }


        public void LoadAllSoundEffects(ContentManager content)
        {
            jumpSoundEffect = content.Load<SoundEffect>("marioJump");
            fireballSoundEffect = content.Load<SoundEffect>("marioFireball");
            breakBlockSoundEffect = content.Load<SoundEffect>("breakBlock");
            stompSoundEffect = content.Load<SoundEffect>("stomp");
            bumpSoundEffect = content.Load<SoundEffect>("bump");
            flipSoundEffect = content.Load<SoundEffect>("flip");

            backgroundMusic = content.Load<Song>("marioBGM");
           
            gameOverMusic = content.Load<Song>("gameOver");
            marioDieMusic = content.Load<Song>("marioDie");
            starMarioMusic = content.Load<Song>("starMarioMusic");
            timeRunningOutMusic = content.Load<Song>("timeRunningOut");

            powerUpAppearsEffect = content.Load<SoundEffect>("powerUpAppears");
            coinEffect = content.Load<SoundEffect>("marioCoin");
            oneUpEffect = content.Load<SoundEffect>("marioOneUp");
            marioPowerUpEffect = content.Load<SoundEffect>("marioPowerUp");
            marioTakeDamage = content.Load<SoundEffect>("takeDamage");

            pipeTravel = content.Load<SoundEffect>("pipeTravel");
            endOfLevelMusic = content.Load<Song>("clearStage");


        }

        public SoundEffectInstance CreatePipeTravelSoundEffect()
        {
            return pipeTravel.CreateInstance();

        }

        public SoundEffectInstance CreateFlipSoundEffect()
        {
            return flipSoundEffect.CreateInstance();
        }

        public Song CreateEndOfLevelMusic()
        {
            return endOfLevelMusic;
        }

        public Song CreateTimeRunningOutMusic()
        {
            return timeRunningOutMusic;
        }
        public Song CreateMarioDieMusic()
        {
            return marioDieMusic;
        }
        public Song CreateBackgroundMusic()
        {
            return backgroundMusic;
        }

        public Song GameOverMusic()
        {
            return gameOverMusic;
        }

        public Song StarMarioMusic()
        {
            return starMarioMusic;
        }

        public SoundEffectInstance CreateTakeDamageEffectInstance()
        {
            return marioTakeDamage.CreateInstance();
        }

        public SoundEffectInstance CreateCoinEffectInstance()
        {
            return coinEffect.CreateInstance();
        }
        public SoundEffectInstance CreatePowerUpAppearEffectInstance()
        {
            return powerUpAppearsEffect.CreateInstance();
        }

        public SoundEffectInstance CreateOneUpEffectInstance()
        {
            return oneUpEffect.CreateInstance();
        }
        public SoundEffectInstance CreateMarioPowerUpEffectInstance()
        {
            return marioPowerUpEffect.CreateInstance();
        }

        public SoundEffectInstance CreateJumpSoundEffectInstance()
        {
            return jumpSoundEffect.CreateInstance();
        }

        public SoundEffectInstance CreateFireballSoundEffectInstance()
        {
            return fireballSoundEffect.CreateInstance();
        }

        public SoundEffectInstance CreateBreakBlockSoundEffectInstance()
        {
            return breakBlockSoundEffect.CreateInstance();
        }

        public SoundEffectInstance CreateBumpSoundEffectInstance()
        {
            return bumpSoundEffect.CreateInstance();
        }

        public SoundEffectInstance CreateStompSoundEffectInstance()
        {
            return stompSoundEffect.CreateInstance();
        }
    }
}
