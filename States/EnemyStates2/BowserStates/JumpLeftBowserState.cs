using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class JumpLeftBowserState : IBowserState
    {
        private Bowser myBowser;
        private ISprite bowserSprite;
        private float velocityY;

        public JumpLeftBowserState(Bowser bowser)
        {
            myBowser = bowser;
            bowserSprite = EnemySpriteFactory.Instance.CreateClosedMouthBowserSprite();
            velocityY = BowserStateUtil.velocityY;
        }

        public void MoveLeft()
        {
            myBowser.MoveLeft();
        }

        public void MoveRight()
        {
            myBowser.MoveRight();
        }

        public void BeKilled()
        {
            myBowser.state = new DeadBowserState(myBowser);
        }

        public void OpenMouth()
        {
            myBowser.state = new OpenMouthBowserState(myBowser);
        }

        public void CloseMouth()
        {
            // Bowser's mouth is already closed
        }

        public void Update()
        {
            myBowser.GetPositionRef().Y -= velocityY;
            velocityY *= BowserStateUtil.velocityReductionFactor;
            myBowser.MoveLeft();
            if (velocityY <= BowserStateUtil.velocityThreshold)
            {
                myBowser.state = new ClosedMouthBowserState(myBowser);
            }
            bowserSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            bowserSprite.Draw(spriteBatch, camera.AdjustPosition(myBowser.position));
        }

        public int GetWidth()
        {
            return bowserSprite.GetWidth();
        }

        public int GetHeight()
        {
            return bowserSprite.GetHeight();
        }
    }
}
