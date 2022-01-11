using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class Fireball : IProjectile
    {
        private bool isCollidable { get; set; }
        private Vector2 position;
        private bool toDestroy;

        private ISprite fireballSprite;
        private float yVelocity;
        private bool isMovingRight;
        int bounceOriginYValue;

        private enum state { Falling, Bouncing};
        private state fireballState;

        public Fireball(int x, int y, bool isFacingRight)
        {
            IsCollidable = true;
            isMovingRight = isFacingRight;
            position.X = x;
            position.Y = y;
            yVelocity = FireballUtil.velocityY;
            toDestroy = false;
            bounceOriginYValue = FireballUtil.bouceOriginY;
            fireballSprite = FireballSpriteFactory.Instance.CreateStandardFireballSprite();
            fireballState = state.Falling;
        }
        public bool IsCollidable
        {
            get
            {
                return isCollidable;
            }
            set => isCollidable = value;
        }

        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, fireballSprite.GetWidth(), fireballSprite.GetHeight());
            }

        }
        public void ChangeToBouncingState()
        {
            fireballState = state.Bouncing;
        }

        public void ChangeToFallingState()
        {
            fireballState = state.Falling;
        }

        public void SetBounceOrigin(int value)
        {
            bounceOriginYValue = value;
        }

        public void React()
        {
            toDestroy = true;
        }

        public bool RemoveCheck()
        {
            return toDestroy;
        }

        public void Update()
        {
            if (isMovingRight)
            {
                position.X += FireballUtil.velocityX;
            }
            else
            {
                position.X -= FireballUtil.velocityX;
            }

            if (fireballState == state.Falling)
            {
                position.Y += yVelocity;
            }
            else
            {

                position.Y -= yVelocity;
                if ((bounceOriginYValue - position.Y) > FireballUtil.maxY)
                {
                    ChangeToFallingState();
                }

            }
            fireballSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            Vector2 value = camera.AdjustPosition(position);
            if (value.X < CameraUtil.windowMinX || value.X > CameraUtil.windowMaxX || value.Y < CameraUtil.windowMinY || value.Y > CameraUtil.windowMaxY)
            {
                toDestroy = true;
            }
            fireballSprite.Draw(spriteBatch, value);
        }

        public ref Vector2 GetPositionRef()
        {
            return ref position;
        }

    }
}
