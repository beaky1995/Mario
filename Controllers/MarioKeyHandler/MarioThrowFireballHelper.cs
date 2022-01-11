using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Spaghetti
{
    public class MarioThrowFireballHelper
    {

        private bool fireballTimerIsOn;
        private int fireballDelay;
        private bool xLetGo;

        public MarioThrowFireballHelper()
        {
            fireballTimerIsOn = false;
            fireballDelay = ControllerUtil.fireballDelay;
            xLetGo = true;
        }

        public void HandleRequest(Game1 game, Dictionary<Keys, ICommand> controllerMappings)
        {
            if (xLetGo)
            {
                xLetGo = false;
                controllerMappings[Keys.X].Execute();
            }
        }

        public void CheckXLetGo(Keys[] pressedKeys)
        {
            if (!pressedKeys.Contains(Keys.X))
            {
                xLetGo = true;
            }
        }

    }

}
