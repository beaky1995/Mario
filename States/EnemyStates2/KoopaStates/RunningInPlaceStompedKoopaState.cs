using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class RunningInPlaceStompedKoopaState: IKoopaState
    {
        private Koopa myKoopa;
        private ISprite koopaSprite;
        private string myPreviousDirection;


        private int timer = 240;

        public RunningInPlaceStompedKoopaState(Koopa koopa, string previousDirection)
        {
            myKoopa = koopa;
            //Make sure the factory returns the appropriate sprite
            koopaSprite = EnemySpriteFactory.Instance.CreateStompedKoopaSprite();
            myPreviousDirection = previousDirection;
        }

        public void MoveLeft()
        {
            myKoopa.state = new LeftMovingStompedKoopaState(myKoopa);
        }

        public void MoveRight()
        {
            myKoopa.state = new RightMovingStompedKoopaState(myKoopa);
        }

        public void BeStomped()
        {
            //No OP
        }

        public void BeFlipped()
        {
            //NO OP
        }

        public void BeKilled()
        {
            myKoopa.state = new DeadKoopaState(myKoopa);
        }

        public void Update()
        {
            koopaSprite.Update();
            timer--;
            if(timer == 0)
            {
                myKoopa.IsLethal = true;
                myKoopa.IsStomped = false;
                timer = 240;
                if(myPreviousDirection.Equals(KoopaStateUtil.movingLeft))
                {
                    myKoopa.state = new LeftMovingKoopaState(myKoopa);
                }
                else
                {
                    myKoopa.state = new RightMovingKoopaState(myKoopa);
                }
               
            }
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            koopaSprite.Draw(spriteBatch, camera.AdjustPosition(myKoopa.position));
        }

        public int GetWidth()
        {
            return koopaSprite.GetWidth();
        }

        public int GetHeight()
        {
            return koopaSprite.GetHeight();
        }
    }
}

