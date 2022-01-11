using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Diagnostics;


namespace Spaghetti
{
    class MarioCollisionDetector
    {
        private Game1 myGame;
        private IPlayer mario;

        private CollisionDetection myCollisionDetection;
            
        public MarioCollisionDetector(Game1 game, CollisionDetection collisionDetection)
        {
            myGame = game;
            myCollisionDetection = collisionDetection;
        }

        public void DetectCollisions(List<IBlock> blockList, List<IEnemy> enemyList, List<IItem> itemList, List<IPipe> pipeList, List<IObjective> objectiveList, List<IObstacle> obstacleList, List<IProjectile> projectileList)
        {
            mario = myGame.PlayerList[0];
            Rectangle marioRectangle = mario.CollisionBox;

            foreach (ICollidable enemy in enemyList)
            {
                if (enemy.IsCollidable && (mario.IsCollidable))
                {
                    myCollisionDetection.Collision(mario, enemy);
                }
            }

            foreach (ICollidable pipe in pipeList)
            {
                myCollisionDetection.Collision(pipe, mario);
            }

            foreach (ICollidable block in blockList)
            {
               // if (mario.IsCollidable)
               // {
                    myCollisionDetection.Collision(block, mario);
                //}
            }

            foreach (ICollidable item in itemList)
            {
                if (item.IsCollidable) { 
                    myCollisionDetection.Collision(item, mario);
                }
            }
            foreach(ICollidable flagpole in objectiveList)
            {
                
                    myCollisionDetection.Collision(flagpole, mario);
                
            }

            foreach(ICollidable firebar in obstacleList)
            {
                IObstacle root = firebar as IObstacle;
                while(root != null)
                {
                    if (mario.IsCollidable)
                    {
                        myCollisionDetection.Collision(root, mario);
                    }
                    root = root.Next();
                }
            }

            foreach(ICollidable projectile in projectileList)
            {
                myCollisionDetection.Collision(projectile, mario);
            }

        }
    }
}
