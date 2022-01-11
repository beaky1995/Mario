using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public interface IGoombaState: IDrawable, IUpdatable
    {
        void MoveLeft();
        void MoveRight();
        void BeStomped();
        void BeFlipped();
        void BeKilled();
        int GetWidth();
        int GetHeight();
    }
}
