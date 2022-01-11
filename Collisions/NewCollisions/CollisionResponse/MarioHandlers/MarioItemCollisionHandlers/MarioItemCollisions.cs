using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Spaghetti
{
    class MarioItemCollisions
    {

        public MarioItemCollisions()
        {

        }

        public void HandleItemCollisions(Game1 game, IPlayer mario, CollisionDetection.Direction result, Type type, Rectangle intersect)
        {
            
            
            if (type.ToString().Equals("Spaghetti.FireFlower"))
            {
                if (mario.IsSmall() || mario.IsBig())
                {
                    SoundManager.Instance.PowerUp();
                   game.PlayerList[0] = new FirePickupMario(mario, game);
                }
            }
            else if (type.ToString().Equals("Spaghetti.RedMushroom"))
            {
                if (mario.IsSmall())
                {
                    SoundManager.Instance.PowerUp();
                    game.PlayerList[0] = new MushroomPickupMario(mario, game);
                }
            }
            else if (type.ToString().Equals("Spaghetti.Star"))
            {
                if (!mario.IsStar())
                { 
                    SoundManager.Instance.PowerUp();
                    game.PlayerList[0] = new StarMario(mario, game);
                    SoundManager.Instance.PlayStar();
                }

            }else if (type.ToString().Equals("Spaghetti.GreenMushroom"))
            {
                game.marioLives.AddLife();
                SoundManager.Instance.OneUp();
            }
          


        }
    }
}
