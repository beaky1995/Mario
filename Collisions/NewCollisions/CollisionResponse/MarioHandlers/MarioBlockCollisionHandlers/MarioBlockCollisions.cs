using System;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace Spaghetti
{
    class MarioBlockCollisions
    {
        public MarioBlockCollisions()
        {

        }

        public void HandleBlockCollisions(IPlayer mario, CollisionDetection.Direction result, Rectangle intersect)
        {

            //Debug.WriteLine("Collision Direction: " + result.ToString() + " Width:" +intersect.Width + " Height: " + intersect.Height);

            switch (result)
            {
                case CollisionDetection.Direction.Bottom:
                    //formalMarioSetting();



                    mario.SetMarioYVelocityToZero();
                    mario.SetIsFalling(false);
                    mario.SetIsGrounded(true);

                    mario.GetPositionRef().Y -= intersect.Height;


                    if (mario.IsMovingUp())
                    {
                        //Debug.WriteLine("Printing");
                        //mario.LandingSequence();
                        if (mario.GetMarioPhysicsObject().ReturnXVelocity() >= 0.1)
                        {
                            mario.MoveRight();
                        }  
                        else if (mario.GetMarioPhysicsObject().ReturnXVelocity() <= -0.1) { 
                            mario.MoveLeft();
                        }
                        else {
                            mario.GoIdle();
                        }
                    }


                   
                    break;

                case CollisionDetection.Direction.Top:
                    
                    if(intersect.Height >1)
                    {
                        mario.SetIsFalling(true);
                        mario.SetMarioYVelocityToZero();
                        mario.GetPositionRef().Y += intersect.Height;
                        
                    }
                    break;

                case CollisionDetection.Direction.Left:
                    
                    //Try heights instead of width.
                    if(intersect.Height > 10)
                    {
                        mario.SetMarioXVelocityToZero();
                        mario.GetPositionRef().X += intersect.Width;
                    }
                        
                        //mario.GoIdle();
                    
                    break;

                case CollisionDetection.Direction.Right:
                    if(intersect.Height > 10)
                    {
                        mario.SetMarioXVelocityToZero();
                        mario.GetPositionRef().X -= intersect.Width;
                    }
                        
                        //mario.GoIdle();
                    
                    break;
            }
        }

    }
}
