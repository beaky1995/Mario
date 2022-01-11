using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class FlippedKoopaState: IKoopaState
    {
        private Koopa myKoopa;
        private ISprite koopaSprite;
        private int timer;
        public FlippedKoopaState(Koopa koopa)
        {
            myKoopa = koopa;
            //Make sure the factory returns the right sprite.
            koopaSprite = EnemySpriteFactory.Instance.CreateFlippedKoopaSprite();
            timer = KoopaStateUtil.flippedTimer;
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
            myKoopa.state = new DeadKoopaState(myKoopa);
        }

        public void Update()
        {
            timer--;
            if (timer == 0)
            {
                myKoopa.React();
            }
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
