using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Spaghetti
{
    public class DeadBowserState : IBowserState
    {
        private Bowser myBowser;
        private ISprite bowserSprite;

        public DeadBowserState(Bowser bowser)
        {
            myBowser = bowser;
            bowserSprite = EnemySpriteFactory.Instance.CreateDeadBowserSprite();
        }

        public void MoveLeft()
        {
            // NO OP
        }

        public void MoveRight()
        {
            // NO OP
        }

        public void BeKilled()
        {
            // NO OP
        }

        public void OpenMouth()
        {
            // NO OP
        }

        public void CloseMouth()
        {
            // NO OP
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
