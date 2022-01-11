using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class RunningInPlaceStompedGoombaState: IGoombaState
    {
        private Goomba myGoomba;
        private ISprite goombaSprite;
        private int timer;

        public RunningInPlaceStompedGoombaState(Goomba goomba)
        {
            timer = GoombaStateUtil.runningStompedTimer;
            myGoomba = goomba;
            //Make sure the factory returns the appropriate sprite
            goombaSprite = EnemySpriteFactory.Instance.CreateStompedGoombaSprite();
        }

        public void MoveLeft()
        {
            //do nothing, already stomped
        }

        public void MoveRight()
        {
            //do nothing, already stomped
        }

        public void BeStomped()
        {
            //already stomped
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
