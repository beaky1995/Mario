using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class FlippedGoombaState: IGoombaState
    {
        private Goomba myGoomba;
        private ISprite goombaSprite;
        private int timer;
        public FlippedGoombaState(Goomba goomba)
        {
            myGoomba = goomba;
            //Change sprite here.
            goombaSprite = EnemySpriteFactory.Instance.CreateFlippedGoombaSprite();
            timer = GoombaStateUtil.flippedTimer;
        }

        public void MoveLeft()
        {
            // No OP
        }

        public void MoveRight()
        {
            // No OP
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
            myGoomba.state = new DeadGoombaState(myGoomba);
        }

        public void Update()
        {
            timer--;
            if(timer == 0)
            {
                myGoomba.React();
            }
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
