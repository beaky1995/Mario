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

        public RightMovingStompedKoopaState(Koopa koopa)
        {
            myKoopa = koopa;
            koopaSprite = EnemySpriteFactory.Instance.CreateStompedKoopaSprite();
        }

        public void MoveLeft()
        {
            myKoopa.state = new LeftMovingStompedKoopaState(myKoopa);
        }

        public void MoveRight()
        {
            myKoopa.position.X += 1;
        }
        public void BeStomped()
        {
            //NO-OP
            //already stomped, do nothing
        }
        public void BeFlipped()
        {
            //NO-OP
            //if stomped, do not respond to being attacked by star mario(assumed but not tested behavior)
        }

        public void BeKilled()
        {
            myKoopa.state = new DeadKoopaState(myKoopa);
        }
        public void Update()
        {
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
