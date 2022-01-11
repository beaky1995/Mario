using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
namespace Spaghetti
{
    public class SoundManager
    {
        private static SoundManager instance;

        private SoundManager() { }

        public static SoundManager Instance
        {

            get
            {
                if(instance == null)
                {
                    instance = new SoundManager();
                }
                return instance;
            }
        }

        public void ToggleSoundtrack()
        {
            if (MediaPlayer.Volume == 0)
            {
                MediaPlayer.Volume = 1.0f;
            }
            else
            {
                MediaPlayer.Volume = 0f;
            }
        }


        public void PlayEndOfLevelMusic()
        {
            Song endOfLevelMusic = SoundEffectFactory.Instance.CreateEndOfLevelMusic();
            MediaPlayer.Volume = 0.5f;
            MediaPlayer.IsRepeating = false;
            MediaPlayer.Play(endOfLevelMusic);
        }

        public void Flip()
        {
            SoundEffectInstance flip = SoundEffectFactory.Instance.CreateFlipSoundEffect();
            flip.Volume = 0.5f;
            flip.Play();
        }

        public void PipeWarp()
        {
            SoundEffectInstance pipeWarp = SoundEffectFactory.Instance.CreatePipeTravelSoundEffect();
            pipeWarp.Volume = 0.5f;
            pipeWarp.Play();
        }
        public void PlayTimeRunningOutMusic()
        {
            Song timeRunningOutMusic = SoundEffectFactory.Instance.CreateTimeRunningOutMusic();
            MediaPlayer.Stop();
            MediaPlayer.Volume = 0.5f;
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(timeRunningOutMusic);
        }


        public void PlaySoundtrack()
        {
            Song backgroundMusic = SoundEffectFactory.Instance.CreateBackgroundMusic();
            //MediaPlayer.Stop();
            MediaPlayer.Volume = 0.1f;
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(backgroundMusic);
        }

        public void PlayMarioDieMusic()
        {
            Song marioDieMusic = SoundEffectFactory.Instance.CreateMarioDieMusic();
            MediaPlayer.IsRepeating = false;
            MediaPlayer.Volume = 0.5f;
            MediaPlayer.Play(marioDieMusic);
        }

        public void PlayGameOverMusic()
        {

            Song gameOverMusic = SoundEffectFactory.Instance.GameOverMusic();
            MediaPlayer.Volume = 0.5f;
            MediaPlayer.Play(gameOverMusic);

        }
        public void PlayStar()
        {
            MediaPlayer.Stop();
            Song starMarioMusic = SoundEffectFactory.Instance.StarMarioMusic();
            MediaPlayer.Volume = 0.5f;
            MediaPlayer.Play(starMarioMusic);
        }

        public void TakeDamage()
        {
            SoundEffectInstance takeDamage = SoundEffectFactory.Instance.CreateTakeDamageEffectInstance();
            takeDamage.Volume = 0.2f;
            takeDamage.Play();
        }
        public void PowerUp()
        {
            SoundEffectInstance powerUp = SoundEffectFactory.Instance.CreateMarioPowerUpEffectInstance();
            powerUp.Volume = 0.2f;
            powerUp.Play();
        }

        public void PowerUpAppears()
        {
            SoundEffectInstance powerUpAppears = SoundEffectFactory.Instance.CreatePowerUpAppearEffectInstance();
            powerUpAppears.Volume = 0.2f;
            powerUpAppears.Play();
        }

        public void OneUp()
        {
            SoundEffectInstance oneUp = SoundEffectFactory.Instance.CreateOneUpEffectInstance();
            oneUp.Volume = 0.5f;
            oneUp.Play();
        }

        public void Coin()
        {
            SoundEffectInstance coin = SoundEffectFactory.Instance.CreateCoinEffectInstance();
            coin.Volume = 0.2f;
            coin.Play();
        }

        public void Jump()
        {

           SoundEffectInstance jump =  SoundEffectFactory.Instance.CreateJumpSoundEffectInstance();
            jump.Volume = 0.2f;
            jump.Play();

        }

        public void ThrowFireball()
        {
            SoundEffectInstance fireball = SoundEffectFactory.Instance.CreateFireballSoundEffectInstance();
            fireball.Volume = 0.2f;
            fireball.Play();
        }

        public void BreakBlock()
        {
            SoundEffectInstance breakBlock = SoundEffectFactory.Instance.CreateBreakBlockSoundEffectInstance();
            breakBlock.Volume = 0.4f;
            breakBlock.Play();
        }

        public void Bump()
        {
            SoundEffectInstance bump = SoundEffectFactory.Instance.CreateBumpSoundEffectInstance();
            bump.Volume = 0.15f;
            bump.Play();
        }

        public void Stomp()
        {
            SoundEffectInstance stomp = SoundEffectFactory.Instance.CreateStompSoundEffectInstance();
            stomp.Volume = 0.10f;
            stomp.Play();
        }

        //Add other methods here.
    }
}
