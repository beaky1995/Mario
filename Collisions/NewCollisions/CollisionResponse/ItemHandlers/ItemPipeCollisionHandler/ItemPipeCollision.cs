using System;
using Microsoft.Xna.Framework;

namespace Spaghetti
{
    public class ItemPipeCollision
    {
        public ItemPipeCollision()
        {

        }

        public void HandlePipeCollision(Game1 game, IItem item, CollisionDetection.Direction result, Type type, Rectangle intersect)
        {
            switch (result)
            {
                case CollisionDetection.Direction.Bottom:

                    if (intersect.Width > 3.5)
                    {
                        item.GetPositionRef().Y -= intersect.Height;
                    }
                    break;

                case CollisionDetection.Direction.Top:
                    item.GetPositionRef().Y += intersect.Height;
                    break;

                case CollisionDetection.Direction.Left:

                    item.ReverseDirection();

                    break;

                case CollisionDetection.Direction.Right:

                    item.ReverseDirection();

                    break;
            }
        }
    }
}
