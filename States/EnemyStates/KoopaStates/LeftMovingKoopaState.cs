using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class LeftMovingKoopaState: IKoopaState
    {
        private Koopa myKoopa;
        private ISprite koopaSprite;

        public LeftMovingKoopaState(Koopa koopa)
        {
            myKoopa = koopa;
            koopaSprite = EnemySpriteFactory.Instance.CreateLeftKoopaSprite();
        }

        public void MoveLeft()
        {
            //already moving left
        }

        public void MoveRight()
        {
            myKoopa.state = new RightMovingKoopaState(myKoopa);
        }

        public void BeStomped()
        {
            myKoopa.state = new LeftMovingStompedKoopaState(myKoopa);
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
            koopaSprite.Update();
            myKoopa.MoveLeft();

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
