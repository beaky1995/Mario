using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaghetti
{
    public class Castle : AbstractBackground
    { 

        public Castle(int x, int y):base(x,y)
        {
            sprite = BackgroundSpriteFactory.Instance.CreateCastleSprite();
        }
    }
}
