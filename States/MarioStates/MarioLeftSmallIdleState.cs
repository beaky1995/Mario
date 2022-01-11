using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class MarioLeftSmallIdleState : IMarioState
    {
        public ISprite MarioSprite { get; set; }
        private Mario myMario;
        private bool isCrouching;

        public MarioLeftSmallIdleState(Mario mario)
        {
            myMario = mario;
            MarioSprite = MarioSpriteFactory.Instance.CreateMarioLeftSmallIdleSprite();
            isCrouching = false;
        }

        public bool IsCrouching()
        {
            return isCrouching;
        }

        public void ThrowFireball(Game1 game)
        {
            //Do nothing; Mario is not in Fire state.
        }

        public void Jump()
        {
            myMario.State = new MarioLeftSmallJumpingState(myMario);
        }

        public void Crouch()
        {
           
        }

        public void MoveLeft()
        {
            myMario.State = new MarioLeftSmallRunningState(myMario);
        }

        public void MoveRight()
        {
            myMario.State = new MarioRightSmallIdleState(myMario);
        }

        public void GoIdle()
        {
            // Do nothing; Idle Mario is already Idle
        }

        public void ChangeToSmall()
        {
            // Do nothing; Small Mario is already Small
        }

        public void ChangeToBig()
        {
            myMario.State = new MarioLeftBigIdleState(myMario);
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
            return false;
        }
    }
}
