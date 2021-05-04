using System;
using System.Threading.Tasks;
using System.Timers;

namespace partying_server.util
{
    public class AsyncTimer
    {
        private Timer t;
        public bool Flag { get; set; }
        public Action Callback
        {
            set
            {
                t.Elapsed += new ElapsedEventHandler((s, e) =>
                {

                    if (!Flag)
                    {
                        t.Stop();
                        return;
                    }
                    value();
                }
                );
            }
        }
        public float seconds { get; set; }
        public AsyncTimer(float time)
        {
            seconds = time * 1000;

            t = new Timer(seconds);
            t.AutoReset = true;
            Flag = true;
        }
        public void Start()
        {
            Console.WriteLine("TimeEvent Start");
            t.Start();
        }
    }
}