using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class FireSpear : IProjectile
    {
        private bool isCollidable { get; set; }
        private Vector2 position;
        private bool toDestroy;

        private ISprite fireSpearSprite;

        public FireSpear(int x, int y)
        {
            IsCollidable = true;
            position.X = x;
            position.Y = y;
            toDestroy = false;
            fireSpearSprite = FireballSpriteFactory.Instance.CreateFireSpearSprite();
        }
        public bool IsCollidable
        {
            get
            {
                return isCollidable;
            }
            set { }
        }

        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, fireSpearSprite.GetWidth(), fireSpearSprite.GetHeight());
            }

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
            position.X--;
            fireSpearSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            Vector2 value = camera.AdjustPosition(position);
            fireSpearSprite.Draw(spriteBatch, value);
        }

        public ref Vector2 GetPositionRef()
        {
            return ref position;
        }

        public void ChangeToBouncingState()
        {
            throw new NotImplementedException();
        }

        public void ChangeToFallingState()
        {
            throw new NotImplementedException();
        }

        public void SetBounceOrigin(int value)
        {
            throw new NotImplementedException();
        }
    }
}
