using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Media;

namespace Spaghetti
{
    public class GameTimer
    {
        private int time;
        private int delay;
        private bool started;
        private Game1 myGame;

      
        public GameTimer(Game1 game)
        {
            time = 400;
            started = false;
            myGame = game;
        }


        public void Update()
        {
            if(time == 150)
            {
                PlayTimeRunningOutSound();
            }
        

            if(time == 0)
            {
                TimerIsUp();
            }

            if (started)
            {
                delay++;
                if (delay == 30)
                {
                    if(time > 0)
                    {
                        time--;
                    }
                    delay = 0;
                }
            }
        }

        public int CurrentTime()
        {
            return time;
        }

        public void ResetTimer()
        {
            time = 400;
            ToggleTime(false);

        }

        public void ToggleTime(bool value)
        {
            started = value;
        }

        public void TimerIsUp()
        {
            myGame.PlayerList[0].Die();
        }

        public void PlayTimeRunningOutSound()
        {
            SoundManager.Instance.PlayTimeRunningOutMusic();
        }
    }
}
