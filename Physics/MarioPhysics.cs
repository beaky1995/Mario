namespace Spaghetti
{
    public class MarioPhysics
    {
        private IPlayer myMario;

        private float xVelocity;
        private float yVelocity;
        private float maxXVelocity;
        private float maxYVelocity;
        private float minYVelocity;

        public MarioPhysics(IPlayer mario)
        {
            myMario = mario;
            xVelocity = 0f;
            yVelocity = 0f;
            minYVelocity = PhysicsUtil.minYVelocity;
            maxYVelocity = PhysicsUtil.MaxYVelocity;
        }
        

        public void Sprint()
        {
            xVelocity *= PhysicsUtil.sprintVelocityMultiplier;
        }

        public void MoveRight()
        {
            //magic number
            if(xVelocity <= PhysicsUtil.firstPhaseXVelocity){
                xVelocity += (PhysicsUtil.maxXVelocity * PhysicsUtil.firstPhaseMultiplier );
            }
            else
            {
                xVelocity += (PhysicsUtil.maxXVelocity * PhysicsUtil.secondPhaseMultiplier );
            }
            
            //magic number
            if (xVelocity > PhysicsUtil.maxXVelocity)
            {
                xVelocity = PhysicsUtil.maxXVelocity;
            }
        }


        public void MoveLeft()
        {

            if(xVelocity >= -1.5f)
            {
                xVelocity -= (3.5f * 0.04f);
            }
            else
            {
                xVelocity -= (3.5f * 0.05f);
            }
            
            if (xVelocity < -3.5f)
            {
                xVelocity = -3.5f;
            }
        }

        public void JumpingMoveRight()
        {
            if (!myMario.IsDead())
            {
                xVelocity += (3.5f * 0.03f);

                if (xVelocity > 3.5f)
                {
                    xVelocity = 3.5f;
                }
            }
        }

        public void JumpingMoveLeft()
        {
            if (!myMario.IsDead())
            {
                xVelocity -= (3.5f * 0.03f);

                if (xVelocity < -3.5f)
                {
                    xVelocity = -3.5f;
                }
            }
        }
     
        public void Jump()
        {
            if (yVelocity <= maxYVelocity)
            {
                yVelocity = minYVelocity + yVelocity * 0.3f;
            }
            else
            {
                yVelocity = maxYVelocity;
            }
        }

        public void Update()
        {
            UpdateVertical();
            UpdateHorizontal();
            CheckFalling();
            IdleCondition();
        }

        public void IdleCondition()
        {
            if (!myMario.IsCrouching() && !myMario.IsMovingUp() && ((xVelocity >= -0.45) && (xVelocity <= 0.45)))
           {
                myMario.GoIdle();
           }
        }

        
        public void CheckFalling()
        {
            if(yVelocity < 0)
            {
                myMario.SetIsFalling(true);
                myMario.SetIsGrounded(false);
            }
            else
            {
                myMario.SetIsFalling(false);
            }
        }
        public void UpdateVertical()
        {

            if (yVelocity >= 0.05)
            {
                myMario.GetPositionRef().Y -= ((float)yVelocity);
                yVelocity *= 0.70f;
            }
            else if (yVelocity <= 0.05)
            {

                myMario.GetPositionRef().Y -= ((float)yVelocity);
                yVelocity -= maxYVelocity * 0.08f;

            }
        }

        public void UpdateHorizontal()
        {
            myMario.GetPositionRef().X += ((float)xVelocity);
            if (myMario.IsGrounded())
            { 
                xVelocity *= 0.93f;
            }
            else
            {
                xVelocity *= 0.95f;
            }
        }

        public float ReturnXVelocity()
        {
            return xVelocity;
                
        }

        public float ReturnYVelocity()
        {
            return yVelocity;
        }

        public void SetYVelocityToZero()
        {
            yVelocity = 0f;
        }

        public void SetXVelocityToZero()
        {
            xVelocity = 0f;
        }
    


            
    }
}
