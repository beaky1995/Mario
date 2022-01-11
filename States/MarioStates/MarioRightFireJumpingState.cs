using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class MarioRightFireJumpingState : IMarioState
    {
        public ISprite MarioSprite { get; set; }
        private Mario myMario;

        public MarioRightFireJumpingState(Mario mario)
        {
            myMario = mario;
            MarioSprite = MarioSpriteFactory.Instance.CreateMarioRightFireJumpingSprite();
        }
        public bool IsCrouching()
        {
            return false;

        }
        public void ThrowFireball(Game1 game)
        {
            Vector2 launchCoordinates = myMario.CalculateFireballOriginCoordinates();
            IProjectile fireball = new Fireball((int)launchCoordinates.X, (int)launchCoordinates.Y, true);
            game.FireballList.Add(fireball);
        }

        public void Jump()
        {
            // Do nothing; Jumping Mario is already jumping
        }

        public void Crouch()
        {
            //GoIdle();
        }

        public void MoveLeft()
        {
            myMario.State = new MarioLeftFireJumpingState(myMario);
        }

        public void MoveRight()
        {
            myMario.State = new MarioRightFireRunningState(myMario);
        }

        public void GoIdle()
        {
            myMario.State = new MarioRightFireIdleState(myMario);
        }

        public void ChangeToSmall()
        {
            myMario.State = new MarioRightSmallJumpingState(myMario);
        }

        public void ChangeToBig()
        {
            // Should never happen in game logic
            myMario.State = new MarioRightBigJumpingState(myMario);
        }

        public void ChangeToFire()
        {
            // Do nothing; Fire Mario is already fire
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
            return false;
        }

        public Boolean IsFire()
        {
            return true;
        }

        public Boolean IsMovingUp()
        {
            return true;
        }
    }
}
