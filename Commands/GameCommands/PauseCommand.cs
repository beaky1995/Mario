using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaghetti
{ 
    class PauseCommand:ICommand
    {
        private Game1 myGame;
        public PauseCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            if (Singleton.Instance.isPause == false)
            {
                Singleton.Instance.isPause = true;
            }
            else
            {
                Singleton.Instance.isPause = false ;
            }
        }
    }
}
