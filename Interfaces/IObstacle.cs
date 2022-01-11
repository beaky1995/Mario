using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public interface IObstacle: IUpdatable, IDrawable, ICollidable
    {

        Firebar CreateChildLinks(int barLength, int barPosition);
        Vector2 CalculateNextLinkCoordinates();
        Firebar Next();

    }
}
