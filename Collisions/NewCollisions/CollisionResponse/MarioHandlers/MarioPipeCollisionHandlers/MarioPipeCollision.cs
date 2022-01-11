using Microsoft.Xna.Framework;

namespace Spaghetti
{
    public class MarioPipeCollision
    {

        public MarioPipeCollision()
        {

        }

        public void HandlePipeCollision(IPlayer mario, CollisionDetection.Direction result, Rectangle intersect)
        {
            switch (result)
            {
            case CollisionDetection.Direction.Bottom:
                if (intersect.Width > 1.5)
                {
                    mario.GetPositionRef().Y -= intersect.Height;
                    mario.SetMarioYVelocityToZero();
                    mario.SetIsFalling(false);
                    mario.SetIsGrounded(true);
                }

                if (mario.IsMovingUp())
                {
                    //mario.LandingSequence();
                    if (mario.GetMarioPhysicsObject().ReturnXVelocity() >= 0.1)
                    mario.MoveRight();
                    else if (mario.GetMarioPhysicsObject().ReturnXVelocity() <= -0.1)
                    mario.MoveLeft();
                    else
                    mario.GoIdle();
                }

                if (mario.IsCrouching())
                {
                    
                    //logic for warping?
                }
                break;

            case CollisionDetection.Direction.Top:
                mario.SetIsFalling(true);
                mario.SetMarioYVelocityToZero();
                mario.GetPositionRef().Y += intersect.Height;
                break;

            case CollisionDetection.Direction.Left:
                    
                mario.SetMarioXVelocityToZero();
                mario.GetPositionRef().X += intersect.Width;
                //mario.GoIdle();
                    
                break;

            case CollisionDetection.Direction.Right:
                    
                mario.SetMarioXVelocityToZero();
                mario.GetPositionRef().X -= intersect.Width;
                // mario.GoIdle();
                    
                break;
            }
        }
    }
}
