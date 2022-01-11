using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class MarioLeftSmallJumpingState : IMarioState
    {
        public ISprite MarioSprite { get; set; }
        private Mario myMario;

        public MarioLeftSmallJumpingState(Mario mario)
        {
            myMario = mario;
            MarioSprite = MarioSpriteFactory.Instance.CreateMarioLeftSmallJumpingSprite();
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
            
        }

        public void Crouch()
        {
            // Small Mario cannot crouch
            //GoIdle();
        }

        public void MoveLeft()
        {
            myMario.State = new MarioLeftSmallRunningState(myMario);
        }

        public void MoveRight()
        {
            myMario.State = new MarioRightSmallJumpingState(myMario);
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
            myMario.State = new MarioLeftBigJumpingState(myMario);
        }

        public void ChangeToFire()
        {
            myMario.State = new MarioLeftFireJumpingState(myMario);
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
            return true;
        }
    }
}
