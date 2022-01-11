using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaghetti
{
    public interface IPlayer:  IUpdatable, IDrawable, ICollidable
    {
        void ThrowFireball(Game1 game);
        void Jump();
        void Crouch();
        void Sprint();
        void MoveLeft();
        void MoveRight();
        void GoIdle();
        void ChangeToSmall();
        void ChangeToBig();
        void ChangeToFire();
        void Die();
        ref Vector2 GetPositionRef();
        IMarioState State { get ; set; }
        void StarDraw(SpriteBatch spriteBatch, Camera camera);
        bool IsBig();
        bool IsSmall();
        bool IsStar();
        bool IsFire();
        bool IsDead();
        bool IsMovingUp();
        bool CanTakeDamage();
        MarioPhysics GetMarioPhysicsObject();
        void SetMarioYVelocityToZero();
        void SetMarioXVelocityToZero();
        void SetIsGrounded(bool value);
        void SetIsFalling(bool value);
        bool IsGrounded();

        bool IsFalling();
        void WinAnimation();
        void getAxes();
        bool IsCrouching();
        bool isFinish();
    }
}
