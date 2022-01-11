using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class MarioRightBigCrouchingState : IMarioState
    {
        private ISprite MarioSprite;
        private Mario myMario;

        public MarioRightBigCrouchingState(Mario mario)
        {
            myMario = mario;
            MarioSprite = MarioSpriteFactory.Instance.CreateMarioRightBigCrouchingSprite();
        }
        public bool IsCrouching()
        {
            return true;
        }

        public void ThrowFireball(Game1 game)
        {
            //Do nothing; Mario is not in Fire state.
        }
        public void Jump()
        {
            GoIdle();
        }

        public void Crouch()
        {
            // Do nothing; Crouching Mario is already crouching
        }

        public void MoveLeft()
        {
            myMario.State = new MarioLeftBigCrouchingState(myMario);
            myMario.GetPositionRef().Y -= 8;
        }

        public void MoveRight()
        {
            myMario.State = new MarioRightBigRunningState(myMario);
            myMario.GetPositionRef().Y -= 8;
        }

        public void GoIdle()
        {
            myMario.State = new MarioRightBigIdleState(myMario);
        }

        public void ChangeToSmall()
        {
            myMario.State = new MarioRightSmallIdleState(myMario);
        }

        public void ChangeToBig()
        {
            // Do nothing; Big Mario is already big
        }

        public void ChangeToFire()
        {
            myMario.State = new MarioRightFireCrouchingState(myMario);
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
