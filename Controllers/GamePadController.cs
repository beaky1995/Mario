using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Spaghetti
{
    public class GamePadController : IController
    {

        private Game1 myMario;
        private ArrayList command;

        public GamePadController(Game1 mario)
        {
            myMario = mario;
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            //keeping for possible later use
        }
        public void Update()
        {
            
            GamePadState currentState = GamePad.GetState(PlayerIndex.One);
            command = new ArrayList();
            if (currentState.Buttons.Start.Equals(ButtonState.Pressed)) 
            {
                command.Add(new QuitCommand(myMario));
            }
            if(currentState.ThumbSticks.Left.X < ControllerUtil.gamePadThreshold)
            {
                command.Add(new MarioLeftCommand(myMario));
            }
            if (currentState.ThumbSticks.Left.X > ControllerUtil.gamePadThreshold)
            {
                command.Add(new MarioRightCommand(myMario));
            }
            if (currentState.ThumbSticks.Left.Y < ControllerUtil.gamePadThreshold)
            {
                command.Add(new MarioUpCommand(myMario));
            }
            if (currentState.ThumbSticks.Left.Y > ControllerUtil.gamePadThreshold)
            {
                command.Add(new MarioDownCommand(myMario));
            }
            foreach(ICommand command in command)
            {
                command.Execute();
            }
            

        }
    }
}
