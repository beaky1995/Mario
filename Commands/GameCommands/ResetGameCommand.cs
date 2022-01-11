using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spaghetti
{
    public class ResetGameCommand : ICommand
    {
        private Game1 myGame;
        public ResetGameCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Reset();
            myGame.marioLives = new LivesCounter();
        }
    }
}
