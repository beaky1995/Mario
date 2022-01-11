using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaghetti
{
    public class LivesCounter
    {
        private int lives;
        public LivesCounter()
        {
            lives = coinCounterUtil.liveCounter;
        }

        public int GetLives()
        {
            return lives;
        }
        
        public void RemoveLife()
        {
            if(lives > 0)
            {
                lives--;
            }
        }

        public void AddLife()
        {
            lives++;
        }
    }
}
