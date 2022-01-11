using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace Spaghetti
{
    public class CameraCollisionDetector
    {
        private Game1 myGame;
        private CameraPlayerCollisionHandler cameraPlayerCollisionHandler;

        public CameraCollisionDetector(Game1 game)
        {
            myGame = game;
            cameraPlayerCollisionHandler = new CameraPlayerCollisionHandler();
        }

        public void DetectCameraCollisions(Camera camera, List<IPlayer> playerList, List<IEnemy> enemyList)
        {
            foreach (IPlayer player in playerList)
            {
                Rectangle playerRectangle = player.CollisionBox;
                if (camera.viewableBox.Intersects(playerRectangle)) {
                    cameraPlayerCollisionHandler.CameraPlayerCollision(camera, player);
                }
                else if (!camera.viewableBox.Intersects(playerRectangle)  && player.GetPositionRef().Y > (camera.viewableBox.Y + camera.viewableBox.Height))
                {
                    player.Die();
                }
            }
        }
    }
}
