using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaghetti
{
    public class MouseController : IController
    {
        private Game1 myGame;
        private Vector2 position;
        public MouseController(Game1 game)
        {
            myGame = game;
            myGame.IsMouseVisible = false;
            position.X = ControllerUtil.mouseInitX;
            position.Y = ControllerUtil.mouseInitY;
        }
        public void Update()
        {
            if (myGame.IsMouseVisible)
            {
                MouseState state = Mouse.GetState();
                position.X = state.X;
                position.Y = state.Y;
                myGame.PlayerList[MarioUtil.marioPlayerPos].GetPositionRef().X = position.X;
                myGame.PlayerList[MarioUtil.marioPlayerPos].GetPositionRef().Y = position.Y;
            }
        }
    }
}
