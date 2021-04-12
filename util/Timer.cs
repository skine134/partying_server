using System;
using System.Timers;

namespace partying_server.util
{
    public class Timer
    {
        private static System.Timers.Timer aTimer;
        private float cycleTime;
        private static Action _callback;
        public Timer(float seconds = 0f,Action callback = null)
        {
            cycleTime =seconds*1000;
            _callback = callback;
        }
        public void Start()
        {
            
            SetTimer(cycleTime);
            Console.WriteLine("The timeEvent started at {0:HH:mm:ss.fff}",DateTime.Now);
        }
        private static void SetTimer(float seconds)
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(seconds);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs ek)
        {
            if (_callback!=null)
                _callback();
        }
        public void Stop()
        {
            
            aTimer.Stop();
            aTimer.Dispose();
        }
    }
}