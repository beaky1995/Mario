using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaghetti
{
    public class ToggleSoundtrackCommand: ICommand
    {


        public ToggleSoundtrackCommand()
        {
            
        }

        public void Execute()
        {
            SoundManager.Instance.ToggleSoundtrack();
        }


    }
}
