using System;
using System.Threading.Tasks;
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
            aTimer.Elapsed += async ( sender, e ) => await OnTimedEvent(_callback);
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static Task OnTimedEvent(Action callback)
        {
            Console.WriteLine("time event");
            if (callback!=null)
                callback();
            throw null;
        }
        public void Stop()
        {
            
            aTimer.Stop();
            aTimer.Dispose();
        }
    }
}