using Microsoft.Xna.Framework;
using System;
namespace Spaghetti
{
    class FireballBlockCollision
    {
        public FireballBlockCollision()
        {


        }

        public void HandleBlockCollision(Game1 game, IProjectile fireball, CollisionDetection.Direction result, Type type, Rectangle intersect)
        {

            switch (result)
            {
                case CollisionDetection.Direction.Bottom:

                    if (!type.ToString().Contains("Hidden"))
                    {
                        fireball.ChangeToBouncingState();
                        fireball.SetBounceOrigin((int)fireball.GetPositionRef().Y);
                    }

                    break;

                case CollisionDetection.Direction.Left:

                    if (!type.ToString().Contains("Hidden"))
                    {
                        if(intersect.Height > 3)
                        {
                            fireball.React();
                        }
                       
                    }

                    break;

                case CollisionDetection.Direction.Right:

                    if (!type.ToString().Contains("Hidden"))
                    {
                        if(intersect.Height > 3)
                        {
                            fireball.React();
                        }
                    }

                    break;
            }

        }
    }
}
