using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Spaghetti
{
    public class MarioJumpHelper
    {

        private bool wTimerIsOn;
        private int delay;
        private bool wLetGo;

        public MarioJumpHelper()
        {
            wTimerIsOn = false;
            wLetGo = true;
            delay = ControllerUtil.jumpDelay;
        }

        public void HandleRequest(Game1 game, Dictionary<Keys, ICommand> controllerMappings)
        {
            if(wTimerIsOn && !wLetGo)
            {

                controllerMappings[Keys.W].Execute();
                
            }
            else
            {
                if(!game.PlayerList[MarioUtil.marioPlayerPos].IsMovingUp() && wLetGo)
                {
                    wLetGo = false;
                    wTimerIsOn = true;
                }
            }

        }

        public void CheckWLetGo(Keys[] pressedKeys)
        {
            if (!pressedKeys.Contains(Keys.W))
            {
                wLetGo = true;
            }
        }

        public void UpdateTimer()
        {
            if (wTimerIsOn)
            {
                delay++;
                if (delay == ControllerUtil.jumpMaxDelay)
                {
                    wTimerIsOn = false;
                    delay = ControllerUtil.jumpDelay;
                }
            }
        }
    }
}
