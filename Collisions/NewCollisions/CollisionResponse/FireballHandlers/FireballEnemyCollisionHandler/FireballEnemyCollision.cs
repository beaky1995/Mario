using Microsoft.Xna.Framework;
using System;
namespace Spaghetti
{
    class FireballEnemyCollision
    {
        public FireballEnemyCollision()
        {


        }

        public void HandleEnemyCollision(Game1 game, IProjectile fireball, CollisionDetection.Direction result, Type type, Rectangle intersect)
        {
            fireball.React();
        }
    }
}
