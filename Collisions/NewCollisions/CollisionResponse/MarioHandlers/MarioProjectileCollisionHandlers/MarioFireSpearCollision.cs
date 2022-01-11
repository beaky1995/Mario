
using Microsoft.Xna.Framework;

namespace Spaghetti
{
    public class MarioFireSpearCollision
    {
        public MarioFireSpearCollision()
        {

        }

        public void HandleFireSpearCollision(Game1 game, IPlayer mario, CollisionDetection.Direction result, Rectangle intersect)
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
