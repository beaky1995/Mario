using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaghetti
{
    
    public class ChooseLevelCommand : ICommand
    {
        private Game1 myGame;
        public ChooseLevelCommand(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            Singleton.Instance.displayLevel = true;
            if(Singleton.Instance.isLevel == 1)
            {
                myGame.levelOneOne = new LevelLoaderOneOne(myGame.path + GameUtil.levelSubPath);
                myGame.Reset();
            }
            else
            {
                myGame.level = new LevelLoader(myGame.path + GameUtil.sprint6LevelSubPath);
                myGame.Reset();
                Singleton.Instance.isLevelFour = true;
            }
            
            
        }
    }
}
