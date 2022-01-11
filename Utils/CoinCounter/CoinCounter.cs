using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaghetti
{
    public class CoinCounter
    {
        private static CoinCounter instance;
        private int coinCount;
        private CoinCounter() {

            coinCount = coinCounterUtil.baseCount;

        }

        public static CoinCounter Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new CoinCounter();
                }
                return instance;
            }
        }

        public void Increment()
        {
            coinCount++;
        }

        public int GetCoinCount()
        {
            return coinCount;
        }

        public void ResetCoinCount()
        {
            coinCount = coinCounterUtil.baseCount;
        }
    }
}
