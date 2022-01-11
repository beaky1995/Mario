using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Spaghetti
{ 
    public class CollisionDetection
    {
        public enum Direction { Top, Left, Bottom, Right};
        Direction result1, result2;
        private Game1 myGame;

        private MarioCollisionHandler marioCollisionHandler;
        private BlockCollisionHandler blockCollisionHandler;
        private ItemCollisionHandler itemCollisionHandler;
        private EnemyCollisionHandler enemyCollisionHandler;
        private FireballCollisionHandler fireballCollisionHandler;
        private PipeCollisionHandler pipeCollisionHandler;
        private ObjectiveCollisionHandler objectiveCollisionHandler;
        //private CameraCollisionHandler cameraCollisionHandler;
        
        public CollisionDetection(Game1 game)
        {
            myGame = game;
            marioCollisionHandler = new MarioCollisionHandler();
            blockCollisionHandler = new BlockCollisionHandler();
            pipeCollisionHandler = new PipeCollisionHandler();
            enemyCollisionHandler = new EnemyCollisionHandler();
            itemCollisionHandler  = new ItemCollisionHandler();
            fireballCollisionHandler = new FireballCollisionHandler();
            objectiveCollisionHandler = new ObjectiveCollisionHandler();
            //cameraCollisionHandler  = new CameraCollisionHandler();
        }
        public void Collision(ICollidable obj1, ICollidable obj2)
        {
            Rectangle rec1 = obj1.CollisionBox;
            Rectangle rec2 = obj2.CollisionBox;
            Rectangle overlap = Rectangle.Intersect(rec1, rec2);
            if (overlap == Rectangle.Empty) return;
            Action<object, Direction, Type, Rectangle, object> pass = (obj, result, type, rectangle, object2) =>
            {

                switch (obj)
                {

                    case IPlayer mario:
                        marioCollisionHandler.HandleCollision(myGame, mario, result, type, rectangle, object2);
                        break;
                    case IBlock block:
                        blockCollisionHandler.HandleCollision(myGame, block, result, type, rectangle);
                        break;
                    case IItem item:
                        itemCollisionHandler.HandleCollision(myGame, item, result, type, rectangle);
                        break;
                    case IEnemy enemy:                       
                        enemyCollisionHandler.HandleCollision(myGame, enemy, result, type, rectangle, object2);
                        break;
                    case IProjectile fireball:
                        fireballCollisionHandler.HandleCollision(myGame, fireball, result, type, rectangle);
                        break;
                    case IPipe pipe:
                        pipeCollisionHandler.HandleCollision(myGame, pipe, result, type, rectangle);
                        break;
                    case IObjective objective:
                        objectiveCollisionHandler.HandleCollision(myGame, objective, result, type, rectangle);
                        break;
                    
                }
            };


            
            if ((overlap.Height > overlap.Width))
            {

                
                if ((rec1.Right > rec2.Left) && (rec1.Right < rec2.Right))
                {


                    result1 = Direction.Right;
                    result2 = Direction.Left;


                }
                else
                {

                    result1 = Direction.Left;
                    result2 = Direction.Right;


                }
            }
            else if (overlap.Height < overlap.Width)
            {
                if ((rec1.Bottom > rec2.Top) && (rec1.Bottom < rec2.Bottom))
                {

                    result1 = Direction.Bottom;
                    result2 = Direction.Top;


                }
                else
                {

                    result1 = Direction.Top;
                    result2 = Direction.Bottom;


                }
            }
            

            pass(obj1, result1, obj2.GetType(), overlap, obj2);
            pass(obj2, result2, obj1.GetType(), overlap, obj1);
        }
        
    }
}
