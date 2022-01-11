using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Spaghetti
{
    public class EnemyBlockCollision
    {

        public EnemyBlockCollision()
        {


        }

        public void HandleBlockCollision(Game1 game, IEnemy enemy, CollisionDetection.Direction result, Rectangle intersect, object object2)
        {
            
            switch (result)
            {
                case CollisionDetection.Direction.Bottom:

                    
                    enemy.GetPositionRef().Y -= intersect.Height;

                    if(object2 is IBlock block)
                    {

                        if (block.IsBumped)
                        {
                            enemy.BeFlipped();
                        }
                    }
                    

                    break;

                case CollisionDetection.Direction.Top:
                    enemy.GetPositionRef().Y += intersect.Height;
                    break;

                case CollisionDetection.Direction.Left:

                    if(intersect.Width > 4)
                    {
                        enemy.MoveRight();
                    }

                    break;

                case CollisionDetection.Direction.Right:
                    if(intersect.Width > 4)
                    {
                        enemy.MoveLeft();
                    }
                   

                    break;
            }
        }
    }
}
