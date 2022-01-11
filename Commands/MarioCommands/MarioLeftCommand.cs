using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spaghetti
{
    public class MarioLeftCommand : ICommand
    {
        Game1 myGame;

        public MarioLeftCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.PlayerList[MarioUtil.marioPlayerPos].MoveLeft();
        }
    }
}
