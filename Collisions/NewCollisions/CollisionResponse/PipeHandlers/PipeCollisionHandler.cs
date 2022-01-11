using System;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace Spaghetti
{
    class PipeCollisionHandler
    {

        public PipeCollisionHandler()
        {

        }

        public void HandleCollision(Game1 game, IPipe pipe, CollisionDetection.Direction result, Type type, Rectangle intersect)
        {
           
            IPlayer mario = game.PlayerList[0];
            if (type.ToString().Contains("Mario") && mario.IsCrouching() && result.Equals(CollisionDetection.Direction.Top) && (intersect.Width > 3))
            {
                if (pipe.GetPipeType().Equals("WarpPipe"))
                {
                    SoundManager.Instance.PipeWarp();
                    mario.GetPositionRef() = pipe.GetWarpLocation();
                    game.RecenterCamera();
                }
            }
        }
    }
}
