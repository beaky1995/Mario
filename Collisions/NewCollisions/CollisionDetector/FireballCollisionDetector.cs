using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Spaghetti
{
    public class FireballCollisionDetector
    {
        private Game1 myGame;
        private CollisionDetection myCollisionDetection;

        public FireballCollisionDetector(Game1 game, CollisionDetection collisionDetection)
        {
            myGame = game;
            myCollisionDetection = collisionDetection;
        }

        public void DetectCollisions(List<IProjectile> fireballList, List<IBlock> blockList, List<IEnemy> enemyList, List<IPipe> pipeList)
        {


            foreach (ICollidable fireball in fireballList)
            {
                foreach (ICollidable block in blockList)
                {

                    myCollisionDetection.Collision(fireball, block);
                }
            }

            foreach (ICollidable fireball in fireballList)
            {
                foreach (ICollidable pipe in pipeList)
                {
                    myCollisionDetection.Collision(fireball, pipe);
                }
            }

            foreach (ICollidable fireball in fireballList)
            {
                foreach (ICollidable enemy in enemyList)
                {
                    myCollisionDetection.Collision(fireball, enemy);
                }
            }

        }
    }
}
