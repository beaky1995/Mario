using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Spaghetti
{
    public class OpenMouthBowserState : IBowserState
    {
        private Bowser myBowser;
        private ISprite bowserSprite;

        public OpenMouthBowserState(Bowser bowser)
        {
            myBowser = bowser;
            bowserSprite = EnemySpriteFactory.Instance.CreateOpenMouthBowserSprite();
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
            // Bowser's mouth is already opened
        }

        public void CloseMouth()
        {
            myBowser.state = new ClosedMouthBowserState(myBowser);
        }

        public void Update()
        {
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
