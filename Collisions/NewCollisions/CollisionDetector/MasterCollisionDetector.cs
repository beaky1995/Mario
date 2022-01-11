using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaghetti
{
    public class MasterCollisionDetector
    {
        private Game1 myGame;
        private IPlayer myMario;
        private List<IBlock> myBlockList;
        private List<IEnemy> myEnemyList;
        private List<IItem> myItemList;
        private List<IPipe> myPipeList;
        private List<IObjective> myObjectiveList;
        private List<IProjectile> myFireballList;
        private List<IProjectile> myProjectileList;
        private List<IObstacle> myObstacleList;
 

        private CollisionDetection collisionDetection;
        private MarioCollisionDetector marioCollisionDetector;
        private ItemCollisionDetector itemCollisionDetector;
        private EnemyCollisionDetector enemyCollisionDetector;
        private FireballCollisionDetector fireballCollisionDetector;

        public MasterCollisionDetector(Game1 game, List<IBlock> blockList, List<IEnemy> enemyList, List<IItem> itemList, List<IPipe> pipeList, List<IObjective> objectiveList, List<IProjectile> fireballList, List<IProjectile> projectileList , List<IObstacle> obstacleList)
        {
            myGame = game;
            myMario = myGame.PlayerList[0];
            myBlockList = blockList;
            myEnemyList = enemyList;
            myItemList = itemList;
            myPipeList = pipeList;
            myObjectiveList = objectiveList;
            myFireballList = fireballList;
            myProjectileList = projectileList;
            myObstacleList = obstacleList;

            collisionDetection = new CollisionDetection(myGame);

            marioCollisionDetector = new MarioCollisionDetector(myGame, collisionDetection);
            itemCollisionDetector = new ItemCollisionDetector(myGame, collisionDetection);
            enemyCollisionDetector = new EnemyCollisionDetector(myGame, collisionDetection);
            fireballCollisionDetector = new FireballCollisionDetector(myGame, collisionDetection);
        }


        public void DetectAllCollisions()
        {
            //Stop mario from colliding when he dies. Removes an IF in all of the collisions.
            //The goal is to remove all checks if possible by delegating the work to different collision files that occur in certain situations.

            if (!myMario.IsDead())
            {
                marioCollisionDetector.DetectCollisions(myBlockList, myEnemyList, myItemList, myPipeList, myObjectiveList, myObstacleList, myProjectileList);
            }

           itemCollisionDetector.DetectCollisions(myBlockList, myPipeList, myItemList);
           enemyCollisionDetector.DetectCollisions(myBlockList, myPipeList, myEnemyList);
           fireballCollisionDetector.DetectCollisions(myFireballList, myBlockList, myEnemyList, myPipeList);
        }

    }
}
