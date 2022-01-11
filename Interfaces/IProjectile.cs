using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Spaghetti
{
    public interface IProjectile: IUpdatable, IDrawable, ICollidable
    {
        void React();
        bool RemoveCheck();
        ref Vector2 GetPositionRef();
        void ChangeToBouncingState();
        void ChangeToFallingState();
        void SetBounceOrigin(int value);
        
        

    }
}
