using Microsoft.Xna.Framework;

namespace Spaghetti
{
    class EnemyFireballCollision
    {
        public EnemyFireballCollision()
        {


        }

        public void HandleFireballCollision(Game1 game, IEnemy enemy, CollisionDetection.Direction result, Rectangle intersect)
        {
            enemy.BeFlipped();
            if (enemy is Goomba)
            {
                Singleton.Instance.AddPoints(GoombaUtil.score, enemy);
            }
            else if (enemy is Koopa)
            {
                Singleton.Instance.AddPoints(KoopaUtil.score, enemy);
            }
            else if(enemy is Bowser)
            {
                //Singleton.Instance.AddPoints(BowserUtil.score, enemy);
            }
        }
    }
}
