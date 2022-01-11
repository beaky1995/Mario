using Microsoft.Xna.Framework;

namespace Spaghetti
{
    public class MarioKoopaCollision
    {

        public MarioKoopaCollision()
        {

        }

        public void HandleKoopaCollision(Game1 game, IPlayer mario, CollisionDetection.Direction result, Rectangle intersect, object object2)
        {
          
            IEnemy enemy = object2 as IEnemy;

            if (!mario.IsStar() && result.Equals(CollisionDetection.Direction.Bottom))
            {

                mario.SetIsFalling(false);
                mario.Jump();
                mario.Jump();
                mario.Jump();

            }
            else if (mario.CanTakeDamage() && (!enemy.IsStomped || enemy.IsLethal))
            {

                if (mario.IsBig() || mario.IsFire())
                {
                    game.PlayerList[0] = new DamageMario(mario, game);
                    SoundManager.Instance.TakeDamage();
                }
                else
                {
                    mario.Die();
                }

            }
        }
    }
}
