using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Spaghetti
{
    public class ItemBlockCollision
    {

        public ItemBlockCollision()
        {

        }

        public void HandleBlockCollision(Game1 game, IItem item, CollisionDetection.Direction result, Type type, Rectangle intersect)
        {

            if (item.IsActivated())
            {
                if (type.ToString().Contains("Lava"))
                {
                    item.React();
                }
                switch (result)
                {
                    case CollisionDetection.Direction.Bottom:

                      
                            item.GetPositionRef().Y -= intersect.Height;
                        
                        break;

                    case CollisionDetection.Direction.Top:
                        item.GetPositionRef().Y += intersect.Height;
                        break;

                    case CollisionDetection.Direction.Left:

                        if(intersect.Width > 3)
                        {
                            item.ReverseDirection();
                        }
                        
                        break;

                    case CollisionDetection.Direction.Right:
                        
                        if(intersect.Width > 3)
                        {
                            item.ReverseDirection();
                        }
                        
                        break;
                }
            }
        }
    }
}
