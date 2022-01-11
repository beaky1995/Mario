using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class MarioLeftBigIdleState : IMarioState
    {
        public ISprite MarioSprite { get; set; }
        private Mario myMario;


        public MarioLeftBigIdleState(Mario mario)
        {
            myMario = mario;
            MarioSprite = MarioSpriteFactory.Instance.CreateMarioLeftBigIdleSprite();
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
            myMario.State = new MarioLeftBigJumpingState(myMario);
        }

        public void Crouch()
        {
            myMario.State = new MarioLeftBigCrouchingState(myMario);
            myMario.GetPositionRef().Y += 8;
        }

        public void MoveLeft()
        {
            myMario.State = new MarioLeftBigRunningState(myMario);
        }

        public void MoveRight()
        {
            myMario.State = new MarioRightBigIdleState(myMario);
        }

        public void GoIdle()
        {
            // Do nothing; Idle Mario is already idle
        }

        public void ChangeToSmall()
        {
            myMario.State = new MarioLeftSmallIdleState(myMario);
        }

        public void ChangeToBig()
        {
            // Do nothing; Big Mario is already big
        }

        public void ChangeToFire()
        {
            myMario.State = new MarioLeftFireIdleState(myMario);
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
