using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaghetti
{
    class KeyBoardControllerStartMenu: IController
    {
        private Dictionary<Keys, ICommand> controllerMappings;
        ICommand currentCommand;
        Game1 myGame;

        private Keys previousKey;

        public KeyBoardControllerStartMenu(Game1 game)
        {
            myGame = game;
            controllerMappings = new Dictionary<Keys, ICommand>();

            //Mario commands
            controllerMappings.Add(Keys.W, currentCommand = new ChangeLevelCommand());
            controllerMappings.Add(Keys.S, currentCommand = new ChangeLevelCommand());
            controllerMappings.Add(Keys.Down, currentCommand = new ChangeLevelCommand());
            controllerMappings.Add(Keys.Up, currentCommand = new ChangeLevelCommand());
            controllerMappings.Add(Keys.Enter, currentCommand = new ChooseLevelCommand(myGame));

            // Game commands
            controllerMappings.Add(Keys.Q, currentCommand = new QuitCommand(myGame));
            controllerMappings.Add(Keys.R, currentCommand = new ResetGameCommand(myGame));
            previousKey = Keys.None;
        

        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                    
                if (controllerMappings.ContainsKey(key))
                {
                    if (previousKey != key)
                    {
                        controllerMappings[key].Execute();
                        previousKey = key;
                    }
                    
                        
                }
            }
        }
    }
}
