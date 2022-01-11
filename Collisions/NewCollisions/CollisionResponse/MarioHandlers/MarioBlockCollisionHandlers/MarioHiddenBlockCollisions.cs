using Microsoft.Xna.Framework;

namespace Spaghetti
{
    class MarioHiddenBlockCollisions
    {

        public MarioHiddenBlockCollisions()
        {

        }
        public void HandleHiddenBlockCollisions(IPlayer mario, CollisionDetection.Direction result, Rectangle intersect)
        {

            if(mario.IsMovingUp() && !mario.IsFalling() && result.Equals(CollisionDetection.Direction.Top))
            {
                mario.SetIsFalling(true);
                mario.SetMarioYVelocityToZero();
                mario.GetPositionRef().Y += intersect.Height;

            }
            
        }
    }
}
