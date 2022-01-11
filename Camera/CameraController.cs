using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaghetti
{
    public class CameraController
    {
        Camera myCamera;
        IPlayer myPlayer;

        public CameraController(Camera camera, IPlayer player)
        {
            myCamera = camera;
            myPlayer = player;
        }

        public bool ShouldMoveRight(Vector2 playerPosition)
        {
            return playerPosition.X > (myCamera.viewableBox.X + myCamera.viewableBox.Width * CameraUtil.bufferRight);
        }

        public bool ShouldMoveUp(Vector2 playerPosition)
        {
            return playerPosition.Y < (myCamera.viewableBox.Y + myCamera.viewableBox.Height * CameraUtil.bufferTop);
        }

        public bool ShouldMoveDown(Vector2 playerPosition)
        {
            return (playerPosition.Y > (myCamera.viewableBox.Y + myCamera.viewableBox.Height * CameraUtil.bufferBottom))
                && myCamera.viewableBox.Y <= 0;
        }

        public void Follow()
        {
            Vector2 playerPosition = myPlayer.GetPositionRef();

            if (ShouldMoveRight(playerPosition))
            {
                myCamera.MoveRight((int)(playerPosition.X - (myCamera.viewableBox.X + myCamera.viewableBox.Width * CameraUtil.bufferRight)));
            }
            if (ShouldMoveUp(playerPosition))
            {
                myCamera.MoveUp((int)((myCamera.viewableBox.Y + myCamera.viewableBox.Height * CameraUtil.bufferTop) - playerPosition.Y));
            }
            else if (ShouldMoveDown(playerPosition))
            {
                myCamera.MoveDown((int)(playerPosition.Y - (myCamera.viewableBox.Y + myCamera.viewableBox.Height * CameraUtil.bufferBottom)));
            }
        }

        public void Update()
        {
            Follow();
        }
    }
}
