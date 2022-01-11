using Microsoft.Xna.Framework;

namespace Spaghetti
{
    public class MarioBowserCollision
    {
        public MarioBowserCollision()
        {

        }

        public void HandleBowserCollision(Game1 game, IPlayer mario, CollisionDetection.Direction result, Rectangle intersect)
        {
            if(mario.CanTakeDamage() && intersect.Width > 2.5f)
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
