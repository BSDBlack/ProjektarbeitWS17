using System;

namespace HoloLensRezept
{
    class Timer
    {
        DateTime end { get; set; }
        public Timer(TimeSpan duration)
        {
            this.end = DateTime.Now;
            end.Add(duration);
        }

        public bool checkRemaining()
        {
            if (this.end <= DateTime.Now)
                return false;
            return true;
        }
    }
}
