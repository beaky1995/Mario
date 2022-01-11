using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaghetti {
    class MouseMovingCommand : ICommand
    {
        private Game1 myGame;
        public MouseMovingCommand(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            if (myGame.IsMouseVisible)
            {
                myGame.IsMouseVisible = false;
            }
            else
            {
                myGame.IsMouseVisible = true;
            }
        }
            
    }
}
