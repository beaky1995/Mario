using Microsoft.Xna.Framework;

namespace Spaghetti
{
    public class MarioGoombaCollision
    {
        public MarioGoombaCollision()
        {

        }

        public void HandleGoombaCollision(Game1 game, IPlayer mario, CollisionDetection.Direction result, Rectangle intersect)
        {
            if (!mario.IsStar() && result.Equals(CollisionDetection.Direction.Bottom))
            {

                mario.SetIsFalling(false);
                mario.Jump();
                mario.Jump();
               
            }
            else if(mario.CanTakeDamage() && intersect.Width > 2.5f)
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
