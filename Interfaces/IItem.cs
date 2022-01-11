using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public interface IItem: IDrawable, IUpdatable, ICollidable
    {
        void ReverseDirection();
        void React();
        bool RemoveCheck();
        Vector2 GetPosition();
        void Appears();
        void MoveLeft();
        void MoveRight();
        ref Vector2 GetPositionRef();
        bool IsActivated();
    }
}
