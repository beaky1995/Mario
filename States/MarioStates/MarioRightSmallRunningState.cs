using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class MarioRightSmallRunningState : IMarioState
    {
        public ISprite MarioSprite { get; set; }
        private Mario myMario;

        public MarioRightSmallRunningState(Mario mario)
        {
            myMario = mario;
            MarioSprite = MarioSpriteFactory.Instance.CreateMarioRightSmallRunningSprite();
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
            myMario.State = new MarioRightSmallJumpingState(myMario);
        }

        public void Crouch()
        {
            // Do nothing; Small Mario cannot crouch
        }

        public void MoveLeft()
        {
            myMario.State = new MarioRightSmallIdleState(myMario);
        }

        public void MoveRight()
        {
           //myMario.GetMarioPhysicsObject().MoveRight();
            // Right Running Mario is already running right
        }

        public void GoIdle()
        {
            myMario.State = new MarioRightSmallIdleState(myMario);
        }

        public void ChangeToSmall()
        {
            // Do nothing; Small Mario is already Small
        }

        public void ChangeToBig()
        {
            myMario.State = new MarioRightBigRunningState(myMario);
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
