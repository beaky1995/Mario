using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class DeadKoopaState: IKoopaState
    {
        private Koopa myKoopa;
        private ISprite koopaSprite;
        public DeadKoopaState(Koopa koopa)
        {
            myKoopa = koopa;
            koopaSprite = EnemySpriteFactory.Instance.CreateKoopaSprite();
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
