using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class MarioRightBigRunningState : IMarioState
    {
        public ISprite MarioSprite { get; set; }
        private Mario myMario;

        public MarioRightBigRunningState(Mario mario)
        {
            myMario = mario;
            MarioSprite = MarioSpriteFactory.Instance.CreateMarioRightBigRunningSprite();
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
            myMario.State = new MarioRightBigJumpingState(myMario);
        }

        public void Crouch()
        {
            myMario.State = new MarioRightBigCrouchingState(myMario);
            myMario.GetPositionRef().Y += 8;
        }

        public void MoveLeft()
        {
            myMario.State = new MarioRightBigIdleState(myMario);
        }

        public void MoveRight()
        {
            // Right Running Mario is already running right
        }

        public void GoIdle()
        {
            myMario.State = new MarioRightBigIdleState(myMario);
        }

        public void ChangeToSmall()
        {
            myMario.State = new MarioRightSmallRunningState(myMario);
        }

        public void ChangeToBig()
        {
            // Do nothing; Big Mario is already big
        }

        public void ChangeToFire()
        {
            myMario.State = new MarioRightFireRunningState(myMario);
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
            return true;
        }
        public Boolean IsSmall()
        {
            return false;
        }

        public Boolean IsFire()
        {
            return false;
        }

        public Boolean IsMovingUp()
        {
            return false;
        }
    }
}
