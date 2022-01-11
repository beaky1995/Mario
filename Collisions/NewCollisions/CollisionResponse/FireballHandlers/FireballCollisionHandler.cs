using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaghetti
{
    class FireballCollisionHandler
    {
        private FireballBlockCollision fireballBlockCollision;
        private FireballEnemyCollision fireballEnemyCollision;
        private FireballPipeCollision  fireballPipeCollision;
        public FireballCollisionHandler()
        {
            fireballBlockCollision = new FireballBlockCollision();
            fireballEnemyCollision = new FireballEnemyCollision();
            fireballPipeCollision = new FireballPipeCollision();
        }

        public void HandleCollision(Game1 game, IProjectile fireball, CollisionDetection.Direction result, Type type, Rectangle rec)
        {
            if (type.ToString().Contains("Goomba") || type.ToString().Contains("Koopa") || type.ToString().Contains("Bowser"))
            {
               fireballEnemyCollision.HandleEnemyCollision(game, fireball, result, type, rec);
            }
            else if (type.ToString().Contains("Pipe"))
            {
                fireballPipeCollision.HandlePipeCollision(game, fireball, result, type, rec);
            }
            else if (type.ToString().Contains("Block"))
            {
                fireballBlockCollision.HandleBlockCollision(game, fireball, result, type, rec);
            }


        }
    }
}
