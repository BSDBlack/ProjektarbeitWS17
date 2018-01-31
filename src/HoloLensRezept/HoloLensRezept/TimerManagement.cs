using System.Collections.Generic;
using System.Linq;

namespace HoloLensRezept
{
    class TimerManagement
    {
        static List<Timer> timerlist = new List<Timer>();

        public void cyclicCheck()
        {
            for(int i = timerlist.Count; i > 0; --i)
            {
                if(!timerlist.ElementAt(i).checkRemaining())
                {
                    // Timer Abgelaufen
                    timerlist.RemoveAt(i);
                }
            }
        }

    }
}
