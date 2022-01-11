using System;
using Microsoft.Xna.Framework;

namespace Spaghetti
{
    public class ItemCollisionHandler
    {
        private ItemMarioCollision itemMarioCollision;
        private ItemBlockCollision itemBlockCollision;
        private ItemPipeCollision itemPipeCollision;
        public ItemCollisionHandler()
        {
            itemMarioCollision = new ItemMarioCollision();
            itemBlockCollision = new ItemBlockCollision();
            itemPipeCollision = new ItemPipeCollision();
        }

        public void HandleCollision(Game1 game, IItem item, CollisionDetection.Direction result, Type type, Rectangle rec)
        {
            if (type.ToString().Contains("Mario"))
            {
                itemMarioCollision.HandleMarioCollision(game, item, result, rec);
            }
            else if (type.ToString().Contains("Block") && !type.ToString().Contains("Hidden"))
            {
                itemBlockCollision.HandleBlockCollision(game,item,result, type, rec);
            }
            else if (type.ToString().Contains("Pipe"))
            {
                itemPipeCollision.HandlePipeCollision(game,item,result, type, rec);
            }

           
        }
    }
}
