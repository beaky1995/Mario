using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace Spaghetti
{
    public class MovingPlatform : IBlock
    {
        public ISprite movingPlatformSprite;
        private IBlockState state { get; set; }
        private bool isCollidable { get; set; }
        public Vector2 position;
        public Vector2 originalPosition;
        public bool movingRight;

        private float xVelocity;


        private bool isBumped { get; set;  }
        
        public MovingPlatform(int x, int y)
        {
            position.X = x;
            position.Y = y;
            originalPosition.X = x;
            movingPlatformSprite = BlockSpriteFactory.Instance.CreateMovingPlatformSprite();
            State = new MovingPlatformState(this);
            IsCollidable = true;
            IsBumped = false;
            movingRight = true;

            xVelocity = 0;
        }

        public void HandleMarioMovement(ref Vector2 pos)
        {
            if (movingRight)
            {
                pos.X += 2f;
            }
            else
            {
                pos.X -= 2f;
            }
            
            
        }

        public bool IsBumped
        {
            get
            {
                return isBumped;
            }
            set { }

        }

        public float GetXVelocity()
        {
            if (movingRight){
                return  PlatformMoveUtil.xVelocity;
            }
            else
            {
                return  (-1) * PlatformMoveUtil.xVelocity;
            }
        }

        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, movingPlatformSprite.GetWidth(), movingPlatformSprite.GetHeight());
            }

        }
        public void React(int a)
        {
            //NO OP
        }

        public void Update()
        {
            if ( (position.X <= ( originalPosition.X - PlatformMoveUtil.maxX))  || (position.X >= ( originalPosition.X + PlatformMoveUtil.maxX)))
            {           
                ChangeDirection();
            }
            if (movingRight)
            {
                position.X += PlatformMoveUtil.xVelocity;
            }
            else
            {
                position.X -= PlatformMoveUtil.xVelocity;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            movingPlatformSprite.Draw(spriteBatch, camera.AdjustPosition(position));
        }

        public bool RemoveCheck()
        {
            return false ;
        }

        public IBlockState State
        {
            get
            {
                return state;
            }
            set { }
        }

        public bool IsCollidable
        {
            get
            {
                return isCollidable;
            }
            set { }
        }

        public void NonDestroy()
        {
            SoundManager.Instance.Bump();
        }
        public void SetItem(IItem item)
        {
        }

        public string GetBlockType()
        {
            return "MovingPlatform";
        }
        public void ChangeDirection()
        {
            if (movingRight)
            {
                movingRight = false;
            }
            else
            {
                movingRight = true;
            }
        }
    }
}
