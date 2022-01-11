using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public interface IPipe: IUpdatable, IDrawable, ICollidable
    {
        Vector2 GetWarpLocation();
        string GetPipeType();
    }

}
