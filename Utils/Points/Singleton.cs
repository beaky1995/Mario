using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaghetti
{
    public class Singleton

    {
        private static Singleton instance;

        private Singleton() { }

        public int score = SingletonUtil.scoreInit;
        public bool isPause = false;
        public bool winAction = false;
        private bool timerIsOn = false;
        public int isLevel = 0;
        public bool displayLevel = false;
        public bool isLevelFour = false;
        private int timerDelay = SingletonUtil.timerDelay;

        private int bounceCount = SingletonUtil.bounceInit;

        private int StompPoints = SingletonUtil.stompInit;
        public bool getAxe = false;

        public List<PopUpScore> myPopUpScoreObjects = new List<PopUpScore>();

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                    
                }
                return instance;
            }
        }

        void Awake()
        {
            instance = this;
        }

        public void AddPoints(int x, ICollidable obj)
        {
            score += x;
            myPopUpScoreObjects.Add(new PopUpScore(x, obj.CollisionBox.X, obj.CollisionBox.Y));

        }

        public void AddItemPoints(int x, ICollidable obj)
        {
            score += x;
            myPopUpScoreObjects.Add(new PopUpScore(x, obj.CollisionBox.X, obj.CollisionBox.Y + 5));

        }


        public void AddStompPoints(int x, IEnemy enemy)
        {
            timerDelay = SingletonUtil.timerDelay;
            timerIsOn = true;
            bounceCount++;
            StompPoints = x * bounceCount;
            score += StompPoints;
            Vector2 pos = enemy.GetPositionRef();
            myPopUpScoreObjects.Add(new PopUpScore(StompPoints, (int) pos.X,(int) pos.Y));

            StompPoints = SingletonUtil.stompInit;
        }
 
        public void Update()
        {        
            if (timerIsOn)
            {
                timerDelay--;
                if(timerDelay == 0)
                {
                    timerIsOn = false;
                    timerDelay = SingletonUtil.timerDelay;
                    bounceCount = SingletonUtil.bounceInit;
                }            
            }
        }
    }
}
