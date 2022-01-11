using System;
using Microsoft.Xna.Framework;

namespace Spaghetti
{
    public class ItemMarioCollision
    {
        public ItemMarioCollision()
        {

        }

        public void HandleMarioCollision(Game1 game, IItem item, CollisionDetection.Direction result, Rectangle intersect)
        {
            item.React();
            if (item is Star)
            {
                Singleton.Instance.AddPoints(ItemUtil.starScore, item);
            }
            else if (item is RedMushroom)
            {
                Singleton.Instance.AddPoints(ItemUtil.redShroomScore, item);
            }
            
        }
    }
}
