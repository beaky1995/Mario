using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class MarioLeftSmallRunningState : IMarioState
    {
        public ISprite MarioSprite { get; set; }
        private Mario myMario;

        public MarioLeftSmallRunningState(Mario mario)
        {
            myMario = mario;
            MarioSprite = MarioSpriteFactory.Instance.CreateMarioLeftSmallRunningSprite();
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
            myMario.State = new MarioLeftSmallJumpingState(myMario);
        }

        public void Crouch()
        {
            // Do nothing; Small Mario cannot crouch
        }

        public void MoveLeft()
        {
            //myMario.GetMarioPhysicsObject().MoveLeft();
            // Left Running Mario is already running left
        }

        public void MoveRight()
        {
            myMario.State = new MarioLeftSmallIdleState(myMario);
        }

        public void GoIdle()
        {
            myMario.State = new MarioLeftSmallIdleState(myMario);
        }

        public void ChangeToSmall()
        {
            // Do nothing; Small Mario is already Small
        }

        public void ChangeToBig()
        {
            myMario.State = new MarioLeftBigRunningState(myMario);
        }

        public void ChangeToFire()
        {
            myMario.State = new MarioLeftFireRunningState(myMario);
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
