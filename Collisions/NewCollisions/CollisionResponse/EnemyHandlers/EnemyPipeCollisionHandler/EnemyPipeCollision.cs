using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Spaghetti { 
    public class EnemyPipeCollision
    {

        public EnemyPipeCollision()
        {


        }

        public void HandlePipeCollision(Game1 game, IEnemy enemy, CollisionDetection.Direction result, Rectangle intersect)
        {

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

                    enemy.MoveRight();

                    break;

                case CollisionDetection.Direction.Right:

                    enemy.MoveLeft();

                    break;
            }
        }
    }
}
