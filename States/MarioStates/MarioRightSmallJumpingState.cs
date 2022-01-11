using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class MarioRightSmallJumpingState : IMarioState
    {
        public ISprite MarioSprite { get; set; }
        private Mario myMario;
        private bool isMovingUp;

        public MarioRightSmallJumpingState(Mario mario)
        {
            myMario = mario;
            MarioSprite = MarioSpriteFactory.Instance.CreateMarioRightSmallJumpingSprite();
            isMovingUp = true;
        }
        public bool IsCrouching()
        {
            return false;
        }

        public void ThrowFireball(Game1 game)
        {
            //Do nothing; Mario is not in Fire state.
        }

        public void Jump()
        {
            //myMario.GetMarioPhysicsObject().Jump();
            // Do nothing; Jumping Mario is already jumping
        }

        public void Crouch()
        {
            // Small Mario cannot crouch
            //GoIdle();
        }

        public void MoveLeft()
        {
            myMario.State = new MarioLeftSmallJumpingState(myMario);
        }

        public void MoveRight()
        {
            myMario.State = new MarioRightSmallRunningState(myMario);
        }

        public void GoIdle()
        {
            //isMovingUp = false;
            //Change this to Land()

            //isMovingUp = false;
            //myMario.state = new MarioRightSmallRunningState(myMario);
          
            myMario.State = new MarioRightSmallIdleState(myMario);

        }
        
        public void ChangeToSmall()
        {
            // Do nothing; Small Mario is already Small
        }

        public void ChangeToBig()
        {
            myMario.State = new MarioRightBigJumpingState(myMario);
        }

        public void ChangeToFire()
        {
            myMario.State = new MarioRightFireJumpingState(myMario);
        }

        public void Die()
        {
            myMario.State = new MarioDeadState(myMario);
        }
        public void Update()
        {
            MarioSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            MarioSprite.Draw(spriteBatch, camera.AdjustPosition(myMario.position));
        }
        public void StarDraw(SpriteBatch spriteBatch, Camera camera)
        {
            MarioSprite.StarDraw(spriteBatch, camera.AdjustPosition(myMario.position));
        }

        public int GetWidth()
        {
            return MarioSprite.GetWidth();
        }

        public int GetHeight()
        {
            return MarioSprite.GetHeight();
        }

        public Boolean IsBig()
        {
            return false;
        }
        public Boolean IsSmall()
        {
            return true;
        }

        public Boolean IsFire()
        {
            return false;
        }

        public Boolean IsMovingUp()
        {
            return isMovingUp;
        }
    }
}
