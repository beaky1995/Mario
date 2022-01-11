using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaghetti
{
    class ChangeLevelCommand: ICommand
    {
        public void Execute()
        {
            if(Singleton.Instance.isLevel == 2)
            {
                Singleton.Instance.isLevel = 1;
            }
            else 
            {
                Singleton.Instance.isLevel = 2;
            }

        }
    }
}
