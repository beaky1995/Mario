using Microsoft.Xna.Framework;
using System;
namespace Spaghetti
{
    class FireballPipeCollision
    {
        public FireballPipeCollision()
        {


        }

        public void HandlePipeCollision(Game1 game, IProjectile fireball, CollisionDetection.Direction result, Type type, Rectangle intersect)
        {

            switch (result)
            {
                case CollisionDetection.Direction.Bottom:

                    
                        fireball.ChangeToBouncingState();
                        fireball.SetBounceOrigin((int)fireball.GetPositionRef().Y);
                    

                    break;

                case CollisionDetection.Direction.Left:

                    if ((intersect.Width > 1))
                    {
                        fireball.React();
                    }

                    break;

                case CollisionDetection.Direction.Right:

                    if ((intersect.Width > 1))
                    {
                        fireball.React();
                    }

                    break;
            }

        }
    }
}
