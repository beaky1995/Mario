using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spaghetti
{
    public class MarioRightCommand : ICommand
    {
        Game1 myGame;

        public MarioRightCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.PlayerList[MarioUtil.marioPlayerPos].MoveRight();
        }
    }
}
