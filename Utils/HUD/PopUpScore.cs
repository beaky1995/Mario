using Microsoft.Xna.Framework;

namespace Spaghetti
{
    public class PopUpScore
    {
        private bool toDestroy;
        private int myScore;
        private Vector2 position;

        private int popUpTimer;
        public PopUpScore(int score, int x, int y)
        {
            toDestroy = false;
            myScore = score;
            position.X = x;
            position.Y = y;
            popUpTimer = 30;
        }


        public void React()
        {
            toDestroy = true;
        }

        public bool RemoveCheck()
        {
            return toDestroy;
        }

        public void Update()
        {
            position.Y--;
            popUpTimer--;
            if(popUpTimer == 0)
            {
                toDestroy = true;
            }
        }

        public int GetScore()
        {
            return myScore;
        }

        public ref Vector2 GetPositionRef()
        {
            return ref position;
        }
    }
}
