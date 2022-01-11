
using Microsoft.Xna.Framework;

namespace Spaghetti
{
    public class MarioFirebarCollision
    {
        public MarioFirebarCollision()
        {

        }

        public void HandleFirebarCollision(Game1 game, IPlayer mario, CollisionDetection.Direction result, Rectangle intersect)
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
