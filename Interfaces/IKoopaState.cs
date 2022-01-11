using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public interface IKoopaState: IUpdatable,IDrawable
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
