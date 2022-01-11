using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Spaghetti
{
    public class KeyboardController : IController
    {

        private Dictionary<Keys, ICommand> controllerMappings;
        ICommand currentCommand;
        Game1 myGame;

        private MarioJumpHelper jumpHandler;

        private MarioThrowFireballHelper fireballHandler;
      
        public KeyboardController(Game1 game)
        {
            myGame = game;
            controllerMappings = new Dictionary<Keys, ICommand>();

            //Mario commands
            controllerMappings.Add(Keys.W, currentCommand = new MarioUpCommand(myGame));
            controllerMappings.Add(Keys.S, currentCommand = new MarioDownCommand(myGame));
            controllerMappings.Add(Keys.Down, currentCommand = new MarioDownCommand(myGame));
            controllerMappings.Add(Keys.A, currentCommand = new MarioLeftCommand(myGame));
            controllerMappings.Add(Keys.Left, currentCommand = new MarioLeftCommand(myGame));
            controllerMappings.Add(Keys.D, currentCommand = new MarioRightCommand(myGame));
            controllerMappings.Add(Keys.Right, currentCommand = new MarioRightCommand(myGame));
            controllerMappings.Add(Keys.LeftShift, currentCommand = new MarioSprintCommand(myGame));

            // Game commands
            controllerMappings.Add(Keys.Q, currentCommand = new QuitCommand(myGame));
            controllerMappings.Add(Keys.R, currentCommand = new ResetGameCommand(myGame));
            controllerMappings.Add(Keys.U, currentCommand = new PauseCommand(myGame));
            // Mouse moving command
            controllerMappings.Add(Keys.M, currentCommand = new MouseMovingCommand(myGame));
            controllerMappings.Add(Keys.X, currentCommand = new ThrowFireballCommand(myGame));


            //Mute soundtrack command
            controllerMappings.Add(Keys.P, currentCommand = new ToggleSoundtrackCommand());

            jumpHandler = new MarioJumpHelper();
            fireballHandler = new MarioThrowFireballHelper();
        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();




            if (!Singleton.Instance.winAction)
            {
                jumpHandler.UpdateTimer();
            
                foreach (Keys key in pressedKeys)
                { 
                    if ((key == Keys.W))
                    {
                        jumpHandler.HandleRequest(myGame, controllerMappings);                      
                    }
                    else if(key == Keys.X)
                    {
                        fireballHandler.HandleRequest(myGame, controllerMappings);
                        
                    }else
                    {
                        if (controllerMappings.ContainsKey(key))
                        {
                            controllerMappings[key].Execute();
                        }
                    }
                }

                jumpHandler.CheckWLetGo(pressedKeys);
                fireballHandler.CheckXLetGo(pressedKeys);
            }
        }
    }
}