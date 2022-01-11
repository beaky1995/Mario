using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public interface IBowserState: IDrawable, IUpdatable
    {
        void MoveLeft();
        void MoveRight();
        void BeKilled();
        void OpenMouth();
        void CloseMouth();
        int GetWidth();
        int GetHeight();
    }
}
