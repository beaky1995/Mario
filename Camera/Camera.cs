using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaghetti
{
    public class Camera
    {
        private Rectangle myViewableBox;

        public Rectangle viewableBox
        {
            get
            {
                return myViewableBox;
            }
            set
            {
                myViewableBox = value;
            }
        }

        public Camera(int x, int y, int width, int height)
        {
            myViewableBox = new Rectangle(x, y, width, height);
        }

        public void MoveRight(int magnitude)
        {
            myViewableBox.X += magnitude;
        }

        public void MoveUp(int magnitude)
        {
            myViewableBox.Y -= magnitude;
        }

        public void MoveDown(int magnitude)
        {
            myViewableBox.Y += magnitude;
        }

        public Vector2 AdjustPosition(Vector2 position)
        {
            Vector2 adjustedPosition = position;
            adjustedPosition.X -= myViewableBox.X;
            adjustedPosition.Y -= myViewableBox.Y;
            return adjustedPosition;
        }

        public void SnapCamera(Vector2 position)
        {
            myViewableBox.X = (int)(position.X - myViewableBox.X * CameraUtil.bufferRight);
        }

        public void Update()
        {
        }
    }
}
