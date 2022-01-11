using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaghetti
{
    public class ThrowFireballCommand: ICommand
    {

        Game1 myGame;

        public ThrowFireballCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.PlayerList[MarioUtil.marioPlayerPos].ThrowFireball(myGame);
        }
    }
}
