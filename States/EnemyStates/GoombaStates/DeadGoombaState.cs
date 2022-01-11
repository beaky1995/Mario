using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class DeadGoombaState: IGoombaState
    {

        private Goomba myGoomba;
        private ISprite goombaSprite;
        public DeadGoombaState(Goomba goomba)
        {
            myGoomba = goomba;
            goombaSprite = EnemySpriteFactory.Instance.CreateGoombaSprite();
        }

        public void MoveLeft()
        {
            //NO OP
        }
        public void MoveRight()
        {
            //NO OP
        }

        public void BeStomped()
        {
            //NO OP
        }

        public void BeFlipped()
        {
            //NO OP
        }
        public void BeKilled()
        {
            //NO OP
        }

        public void Update()
        {
            goombaSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            goombaSprite.Draw(spriteBatch, camera.AdjustPosition(myGoomba.position));
        }

        public int GetWidth()
        {
            return goombaSprite.GetWidth();
        }

        public int GetHeight()
        {
            return goombaSprite.GetHeight();
        }


    }
}
