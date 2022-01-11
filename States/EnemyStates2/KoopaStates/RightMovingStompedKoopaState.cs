using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class RightMovingStompedKoopaState: IKoopaState
    {
        private Koopa myKoopa;
        private ISprite koopaSprite;

        private int nonLethalTimer;

        public RightMovingStompedKoopaState(Koopa koopa)
        {
            myKoopa = koopa;
            koopaSprite = EnemySpriteFactory.Instance.CreateStompedKoopaSprite();
            nonLethalTimer = KoopaStateUtil.lethalTimer;
        }

        public void MoveLeft()
        {
            myKoopa.state = new LeftMovingStompedKoopaState(myKoopa);
        }

        public void MoveRight()
        {
            myKoopa.position.X += KoopaStateUtil.flippedSpeedX;
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

            koopaSprite.Update();
            myKoopa.MoveRight();

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
