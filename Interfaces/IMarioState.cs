using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public interface IMarioState: IDrawable, IUpdatable
    {
        void ThrowFireball(Game1 game);
        void StarDraw(SpriteBatch spriteBatch, Camera camera);
        void Jump();
        void Crouch();
        void MoveLeft();
        void MoveRight();
        void GoIdle();
        void ChangeToSmall();
        void ChangeToBig();
        void ChangeToFire();
        void Die();
        int GetWidth();
        int GetHeight();
        bool IsBig();
        bool IsSmall();
        bool IsFire();
        bool IsMovingUp();
        bool IsCrouching();
        
    }
}
