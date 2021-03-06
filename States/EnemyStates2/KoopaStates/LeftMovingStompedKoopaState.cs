using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class LeftMovingStompedKoopaState: IKoopaState
    {
        
        private Koopa myKoopa;
        private ISprite koopaSprite;
        private int nonLethalTimer;
        public LeftMovingStompedKoopaState(Koopa koopa)
        {
            myKoopa = koopa;
            koopaSprite = EnemySpriteFactory.Instance.CreateStompedKoopaSprite();
            nonLethalTimer = KoopaStateUtil.lethalTimer;
        }

        public void MoveLeft()
        {
            myKoopa.position.X -= KoopaStateUtil.flippedSpeedX;
        }

        public void MoveRight()
        {
            myKoopa.state = new RightMovingStompedKoopaState(myKoopa);
        }

        public void BeStomped()
        {
            //NO-OP
            //already stomped, do nothing
        }

        public void BeFlipped()
        {
            myKoopa.state = new FlippedKoopaState(myKoopa);
        }

        public void BeKilled()
        {
            myKoopa.state = new DeadKoopaState(myKoopa);
        }

        public void Update()
        {
            nonLethalTimer--;
            if (nonLethalTimer == 0)
            {
                myKoopa.IsLethal = true;
            }

            myKoopa.MoveLeft();
            koopaSprite.Update();
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
