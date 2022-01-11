using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class MarioDeadState : IMarioState
    {
        private Mario myMario;
        public ISprite MarioSprite { get; set; }
    

        public MarioDeadState(Mario mario)
        {
            myMario = mario;
            MarioSprite = MarioSpriteFactory.Instance.CreateMarioDeadSprite();
            myMario.SetMarioXVelocityToZero();
            myMario.SetIsFalling(false);
            myMario.Jump();
        }

        public bool IsCrouching()
        {
            return false;
        }
        public void ThrowFireball(Game1 game)
        {
            //Do nothing; Mario is dead.
        }
        public void Jump()
        {
            // Do nothing; Mario is dead.
        }

        public void Crouch()
        {
            // Do nothing; Mario is dead.
        }

        public void MoveLeft()
        {
            // Do nothing; Mario is dead.
        }

        public void MoveRight()
        {
            // Do nothing; Mario is dead.
        }

        public void GoIdle()
        {
            // Do nothing; Mario is dead.
        }

        public void ChangeToSmall()
        {
            myMario.State = new MarioRightSmallIdleState(myMario);
        }

        public void ChangeToBig()
        {
            myMario.State = new MarioRightBigIdleState(myMario);
        }

        public void ChangeToFire()
        {
            myMario.State = new MarioRightFireIdleState(myMario);
        }

        public void Die()
        {
            // Do nothing; Mario is dead :)
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
