using System;
using System.Collections.Generic;
using System.Text;using System.Linq;

using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class MarioLeftFireRunningState : IMarioState
    {
        public ISprite MarioSprite { get; set; }
        private Mario myMario;

        public MarioLeftFireRunningState(Mario mario)
        {
            myMario = mario;
            MarioSprite = MarioSpriteFactory.Instance.CreateMarioLeftFireRunningSprite();
        }

        public bool IsCrouching()
        {
            return false;
        }

        public void ThrowFireball(Game1 game)
        {
            Vector2 launchCoordinates = myMario.CalculateFireballOriginCoordinates();
            IProjectile fireball = new Fireball((int)launchCoordinates.X, (int)launchCoordinates.Y, false);
            game.FireballList.Add(fireball);
        }
        public void Jump()
        {
            myMario.State = new MarioLeftFireJumpingState(myMario);
        }

        public void Crouch()
        {
            myMario.State = new MarioLeftFireCrouchingState(myMario);
            myMario.GetPositionRef().Y += 8;
        }

        public void MoveLeft()
        {
            // Left Moving Mario is already moving left
        }

        public void MoveRight()
        {
            myMario.State = new MarioLeftFireIdleState(myMario);
        }

        public void GoIdle()
        {
            myMario.State = new MarioLeftFireIdleState(myMario);
        }

        public void ChangeToSmall()
        {
            myMario.State = new MarioLeftSmallRunningState(myMario);
        }

        public void ChangeToBig()
        {
            // Should never happen in game logic
            myMario.State = new MarioLeftBigRunningState(myMario);
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
            return false;
        }
    }
}
