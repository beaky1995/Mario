using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public interface IObjective: IUpdatable, IDrawable, ICollidable
    {
        void React();
        bool RemoveCheck();

    }
}
