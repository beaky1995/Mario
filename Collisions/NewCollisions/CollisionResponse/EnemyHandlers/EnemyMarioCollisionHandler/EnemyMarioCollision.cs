using Microsoft.Xna.Framework;

namespace Spaghetti
{
    public class EnemyMarioCollision
    {
        public EnemyMarioCollision()
        {


        }

        public void HandleMarioCollision(Game1 game, IEnemy enemy, CollisionDetection.Direction result, Rectangle intersect)
        {
            if (game.PlayerList[0].IsStar())
            {
                enemy.BeFlipped();
                Singleton.Instance.AddPoints(GoombaUtil.score, enemy);
            }
            else if (result.Equals(CollisionDetection.Direction.Top))
            {
                if(intersect.Height > 0.5f)
                {
                    enemy.BeStomped();
                }
            
            }else if ( (enemy is Koopa) && (!enemy.IsLethal && enemy.IsStomped) && result.Equals(CollisionDetection.Direction.Left))
            {
                enemy.MoveRight();

            }else if ((enemy is Koopa) && (!enemy.IsLethal && enemy.IsStomped) && result.Equals(CollisionDetection.Direction.Right))
            {
                enemy.MoveLeft();

            }
           

        }

    }
}
