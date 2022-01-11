using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public interface IEnemy: IUpdatable, IDrawable, ICollidable
    {
        void MoveLeft();
        void MoveRight();
        void BeStomped();
        void BeFlipped();
        void BeKilled();
        void React();
        bool RemoveCheck();
        ref Vector2 GetPositionRef();
        bool IsMovingUp { get; set; }

        bool IsLethal { get; set; }

        bool IsStomped { get; set; }
    }
}
