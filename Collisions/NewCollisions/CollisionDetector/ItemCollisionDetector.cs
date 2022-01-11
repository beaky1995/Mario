using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaghetti
{
    class ItemCollisionDetector
    {

        private Game1 myGame;
        private CollisionDetection myCollisionDetection;
        private IPlayer myMario;
        public ItemCollisionDetector(Game1 game, CollisionDetection collisionDetection)
        {
            myGame = game;
            myCollisionDetection = collisionDetection;
            myMario = myGame.PlayerList[0];
        }


        public void DetectCollisions(List<IBlock> blockList, List<IPipe> pipeList, List<IItem> itemList)
        {

            foreach (ICollidable item in itemList)
            {

                foreach (ICollidable block in blockList)
                {

                    myCollisionDetection.Collision(item, block);

                }

            }

            foreach (ICollidable item in itemList)
            {

                foreach (ICollidable pipe in pipeList)
                {
                    myCollisionDetection.Collision(item, pipe);
                }

            }

      
        }

    }
}
