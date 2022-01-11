using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Spaghetti
{
    public class EnemyEnemyCollision
    {

        public EnemyEnemyCollision()
        {


        }

        public void HandleEnemyCollision(Game1 game, IEnemy enemy, CollisionDetection.Direction result, Rectangle intersect, object object2)
        {


            IEnemy enemy2 = object2 as IEnemy;
            

            switch (result)
            {
                case CollisionDetection.Direction.Bottom:

                    if (intersect.Width > 3.5)
                    {
                        enemy.GetPositionRef().Y -= intersect.Height;
                    }
                    break;

                case CollisionDetection.Direction.Top:
                    enemy.GetPositionRef().Y += intersect.Height;
                    break;

                case CollisionDetection.Direction.Left:

                   if(!enemy.IsStomped)
                    {
                        if (enemy2 is Koopa && (enemy2.IsLethal && enemy2.IsStomped))
                        {
                            enemy.BeFlipped();
                            Singleton.Instance.AddPoints(GoombaUtil.score, enemy);
                        }
                        else
                        {
                            enemy.MoveRight();
                        }
                    }
                   
                    break;

                case CollisionDetection.Direction.Right:

                    if (!enemy.IsStomped)
                    {
                        if (enemy2 is Koopa && (enemy2.IsLethal && enemy2.IsStomped))
                        {
                            enemy.BeFlipped();
                            Singleton.Instance.AddPoints(GoombaUtil.score, enemy);
                        }
                        else
                        {
                            enemy.MoveLeft();
                        }
                    }

                    break;
            }
        }

    }
}
