using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaghetti
{
    public class EnemyCollisionDetector
    {
        private Game1 myGame;
        private CollisionDetection myCollisionDetection;
        private IPlayer myMario;
        public EnemyCollisionDetector(Game1 game, CollisionDetection collisionDetection)
        {
            myGame = game;
            myCollisionDetection = collisionDetection;
            myMario = myGame.PlayerList[0];
        }


        public void DetectCollisions(List<IBlock> blockList, List<IPipe> pipeList, List<IEnemy> enemyList)
        {

            foreach (ICollidable enemy in enemyList)
            {

                foreach (ICollidable otherEnemy in enemyList)
                {
                    if (enemy.IsCollidable && otherEnemy.IsCollidable && !otherEnemy.Equals(enemy))
                    {
                        myCollisionDetection.Collision(enemy, otherEnemy);
                    }
                }

            }

            foreach (ICollidable enemy in enemyList)
            {

                foreach (ICollidable pipe in pipeList)
                {
                    if (enemy.IsCollidable)
                    {
                        myCollisionDetection.Collision(enemy, pipe);
                    }

                }

            }


            foreach (ICollidable enemy in enemyList)
            {
                foreach(ICollidable block in blockList)
                {
                    if (enemy.IsCollidable)
                    {
                        myCollisionDetection.Collision(enemy, block);
                    }
                }
            }


        }
    }
}
