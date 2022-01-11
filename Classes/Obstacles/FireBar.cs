using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace Spaghetti
{
    public class Firebar: IObstacle
    {

        private bool isCollidable { get; set; }
        private Vector2 position;
        private bool toDestroy;

        private bool clockwise;


        private float radius;

        
        private int myPositionOnBar;
        private int myBarLength;

        private float angle;

        private Vector2 myOrigin;

        private Firebar nextItem;

        private string myDirection;
        private ISprite fireBarSprite;
        public Firebar(Vector2 origin, int barLength, int barPosition, string direction) 
        {
            IsCollidable = true;
            position.X = origin.X;
            position.Y = origin.Y;
            toDestroy = false;
            fireBarSprite = FireballSpriteFactory.Instance.CreateStandardFireballSprite();
            myPositionOnBar = barPosition;
            myBarLength = barLength;

            radius = Radius();
            myOrigin = origin;
            myDirection = direction;

            angle = 0;
        

            nextItem = CreateChildLinks(myBarLength,myPositionOnBar + 1);

        }

        public void CenterFireBar()
        {
            //some code to center the bar.
        }

        public float Radius()
        {
            return CollisionBox.Height * myPositionOnBar;
        }

        public Vector2 Origin()
        {
            return new Vector2((int) position.X, (int) position.Y - radius);
        }

        public Firebar Next()
        {
            return nextItem;
        }
        public Firebar CreateChildLinks(int barLength, int barPosition)
        {
            if (barPosition < barLength)
            {
                Vector2 nextPosition = CalculateNextLinkCoordinates();
                return new Firebar(myOrigin, barLength, barPosition, myDirection);
            }
            else
            {
                return null;
            }
        }

        public Vector2 CalculateNextLinkCoordinates()
        {
            Rectangle fireballRectangle = CollisionBox;
            int y = fireballRectangle.Y - (fireballRectangle.Height);
            return new Vector2((int) position.X, (int)y);
        }

        public void SpinAntiClockWise()
        {
           
            float angleRadian = (float) angle * (float) ( Math.PI / 180);
            Vector2 pos = myOrigin + Vector2.Transform(new Vector2(radius, 0), Matrix.CreateRotationZ(angle));
            angle += 0.05f;
            position.X = pos.X;
            position.Y = pos.Y;
            // double CosAngle = Math.Acos( (position.X - origin.X) / radius);
            //double SinAngle = Math.Asin()
            //position.X = origin.X + (float)Math.Cos(CosAngle) * radius;
            //position.Y = origin.Y + (float)Math.Sin(CosAngle) * radius;

            //    if((position.X <= origin.X) && (position.X > origin.X - radius) && (position.Y > origin.Y))
            //    {
            //        position.X -= 0.5f;
            //    }
            //    else if((position.X > origin.X && ( position.Y < origin.Y)))
            //    {
            //        position.X += 0.5f;
            //    }



            //double yValue = Math.Sqrt(Math.Pow(radius, 2) - Math.Pow(position.X, 2));
            //if (position.X < origin.X )
            //{
            //    position.Y = (float) -yValue;
            //}
            //else if (position.X > origin.X)
            //{
            //    position.Y = (float) yValue;
            //}

        }

        public void SpinClockWise()
        {
            float angleRadian = (float)angle * (float)(Math.PI / 180);
            Vector2 pos = myOrigin + Vector2.Transform(new Vector2(radius, 0), Matrix.CreateRotationZ(angle));
            angle -= 0.05f;
            position.X = pos.X;
            position.Y = pos.Y;
        }

        public void Update()
        {

            if (myDirection.Equals("Clockwise"))
            {
                SpinClockWise();
            }
            else
            {
                SpinAntiClockWise();
            }


            fireBarSprite.Update();
            //fireBarSprite.Update();

            if(nextItem != null)
            {
                nextItem.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            
            Vector2 value = camera.AdjustPosition(position);
            if (value.X < CameraUtil.windowMinX || value.X > CameraUtil.windowMaxX || value.Y < CameraUtil.windowMinY || value.Y > CameraUtil.windowMaxY)
            {
                toDestroy = true;
            }

            //value.X += (CollisionBox.Width / 2);
            //value.Y += (CollisionBox.Height / 2);
            fireBarSprite.Draw(spriteBatch, value);


            if (nextItem != null)
            {
                nextItem.Draw(spriteBatch, camera);
            }
        }


        public bool IsCollidable
        {
            get
            {
                return isCollidable;
            }
            set => isCollidable = value;
        }

        public Rectangle CollisionBox
        {
            //Alter collisionbox too!.
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, fireBarSprite.GetWidth(), fireBarSprite.GetHeight());
            }

        }
 
        //Add RemoveCheck, we need to remove the FireBar after we cross it. Less collisions.
    }
}
