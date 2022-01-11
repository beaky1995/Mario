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

        public RunningInPlaceStompedKoopaState(Koopa koopa)
        {
            myKoopa = koopa;
            //Make sure the factory returns the appropriate sprite
            koopaSprite = EnemySpriteFactory.Instance.CreateStompedKoopaSprite();
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

