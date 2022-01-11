using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Spaghetti
{
    public class EnemyCollisionHandler
    {
        private EnemyMarioCollision enemyMarioCollision;
        private EnemyBlockCollision enemyBlockCollision;
        private EnemyEnemyCollision enemyEnemyCollision;
        private EnemyPipeCollision enemyPipeCollision;
        private EnemyFireballCollision enemyFireballCollision;
        public EnemyCollisionHandler()
        {
            enemyMarioCollision = new EnemyMarioCollision();
            enemyBlockCollision = new EnemyBlockCollision();
            enemyEnemyCollision = new EnemyEnemyCollision();
            enemyPipeCollision = new EnemyPipeCollision();
            enemyFireballCollision = new EnemyFireballCollision();
        }

        public void HandleCollision(Game1 game, IEnemy enemy, CollisionDetection.Direction result, Type type, Rectangle rec, object object2)
        {


            if (type.ToString().Contains("Mario"))
            {
                
                  enemyMarioCollision.HandleMarioCollision(game, enemy, result, rec);
                
            }
            else if (type.ToString().Contains("Block") && !type.ToString().Contains("Hidden"))
            {
                enemyBlockCollision.HandleBlockCollision(game, enemy, result, rec, object2);
            }
            else if (type.ToString().Contains("Pipe"))
            {
                enemyPipeCollision.HandlePipeCollision(game, enemy, result, rec);
            }else if (type.ToString().Contains("Goomba"))
            {
                enemyEnemyCollision.HandleEnemyCollision(game, enemy, result, rec, object2);
            }
            else if (type.ToString().Contains("Koopa"))
            {
                enemyEnemyCollision.HandleEnemyCollision(game, enemy, result, rec, object2);
            }else if (type.ToString().Contains("Fireball"))
            {
                enemyFireballCollision.HandleFireballCollision(game, enemy, result, rec);
            }


        }


    }
}
