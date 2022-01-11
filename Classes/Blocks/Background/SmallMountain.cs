using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public class SmallMountain : AbstractBackground
    {

        public SmallMountain(int x, int y):base(x,y)
        {
            sprite = BackgroundSpriteFactory.Instance.CreateSmallMountainSprite();
        }

       
    }
}
