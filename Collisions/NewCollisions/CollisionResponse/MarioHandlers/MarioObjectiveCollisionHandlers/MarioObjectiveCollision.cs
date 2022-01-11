using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaghetti
{
    class MarioObjectiveCollision
    {
        public MarioObjectiveCollision()
        {



        }

        public void HandleObjectiveCollision(Game1 game, IPlayer mario, CollisionDetection.Direction result, Rectangle intersect)
        {

            if (!Singleton.Instance.isLevelFour)
            {
                mario.SetMarioXVelocityToZero();
                mario.GetPositionRef().X += intersect.Width;
                mario.GoIdle();
                mario.WinAnimation();
                ScoreCounting(mario.GetPositionRef().Y);
                SoundManager.Instance.PlayEndOfLevelMusic();
                game.gameTimer.ToggleTime(false);
            }
            else
            {
                mario.getAxes();
            }
                   

        }
        private void ScoreCounting(float position)
        {
            if (position >= 160)
            {
                Singleton.Instance.score += 100;
            }
            else if (position >= 120 && position < 160)
            {
                Singleton.Instance.score += 400;
            }
            else if (position >= 80 && position < 120)
            {
                Singleton.Instance.score += 800;
            }
            else if (position >= 60 && position < 44)
            {
                Singleton.Instance.score += 2000;
            }
        }
    }
}
