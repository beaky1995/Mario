using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class CameraPlayerCollisionHandler
    {
        public CameraPlayerCollisionHandler()
        {
        }

        public void CameraPlayerCollision(Camera camera, IPlayer player)
        {
            if (player.GetPositionRef().X < camera.viewableBox.X)
            {
                player.SetMarioXVelocityToZero();
                player.GetPositionRef().X = camera.viewableBox.X;
            }
        }
    }
}
