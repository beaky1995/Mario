using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaghetti
{
    public class ItemUtil
    {
        public static int coinXBuffer = 5;
        public static int coinYBuffer = 10;
        public static int coinMaxY = 20;
        public static int coinMinY = 3;
        public static int coinSpeedY = 3;
        public static int coinScore = 200;

        public static int fireXBuffer = 7;
        public static int fireYBuffer = 6;
        public static int fireMaxY = 11;
        public static float fireSpeedY = 0.4f;
        public static int fireScore = 1000;

        public static int greenShroomMaxY = 11;
        public static float greenShroomSpeedY = 0.4f;
        public static int greenShroomGravity = 3;

        public static int redShroomDelay = 0;
        public static int redShroomDelayFinal = 10;
        public static int redShroomMaxY = 11;
        public static float redShroomSpeedY = 0.4f;
        public static int redShroomGravity = 3;
        public static int redShroomScore = 1000;

        public static int starXBuffer = 7;
        public static int starYBuffer = 6;
        public static int starMaxY = 11;
        public static float starSpeedY = 0.4f;
        public static float starSpeedX = 0.1f;
        public static int starMaxBounceY = 50;
        public static int starMinBounceY = 34;
        public static int starScore = 1000;
    }
}