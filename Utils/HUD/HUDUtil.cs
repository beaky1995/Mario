using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaghetti { 
    public class HUDUtil
    {
        //subtracted 5 to everything
        public static Vector2 PositionOfMarioText = new Vector2(35, 5);
        public static Vector2 PositionOfTotalScore = new Vector2(35, 15);
        public static Vector2 PositionOfCoinCounter = new Vector2(135, 15);
        public static Vector2 PositionOfWorldText = new Vector2(220, 5);
        public static Vector2 PositionOfLevelSpecifier = new Vector2(220, 15);

        public static Vector2 PositionOfTimeText = new Vector2(310, 5);
        public static Vector2 PositionOfTimeRemaining = new Vector2(310, 15);

        public static Vector2 PositionOfIntroWorldText = new Vector2(155, 100);
        public static Vector2 PositionOfLivesSprite = new Vector2(152, 114);
        public static Vector2 PositionOfLivesText = new Vector2(180, 120);
        public static Vector2 PositionOfLivesRemaining = new Vector2(200, 120);

        public static Vector2 PositionOfGameOverText = new Vector2(160, 120);
        public static Vector2 PositionOfEndText1 = new Vector2(75, 75);
        public static Vector2 PositionOfEndText2 = new Vector2(75, 105);
        public static Vector2 PositionOfEndText3 = new Vector2(75, 135);

        public static String SpriteFont = "hud";
        public static String MarioText = "MARIO";
        public static String TimesText = "x";
        public static String WorldText = "WORLD";
        public static String LevelTextOne = "1-1";
        public static String LevelTextTwo = "1-4";
        public static String TimeText = "TIME";
        public static String InitialDisplayOne = "WORLD 1-1";
        public static String InitialDisplayTwo = "WORLD 1-4";
        public static String GOText = "GAME OVER";
        public static String FinalText = "THANK YOU MARIO!";
        public static String FinalText2 = "OUR PRINCESS IS IN ANOTHER CASTLE!";
        public static String FinalText3 = "BUT ANYWAY WE ARE NOT GOING TO BUILD OTHER LEVELS";
        
    }
}
