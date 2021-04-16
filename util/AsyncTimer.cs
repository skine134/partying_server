using System;
using System.Threading.Tasks;
using System.Timers;

namespace partying_server.util
{
    public class AsyncTimer
    {
        private Timer t;
        public AsyncTimer(float time, Action callback)
        {
            var seconds = time * 1000;
            
            t = new Timer(seconds);
            t.AutoReset = true;
            t.Elapsed += new ElapsedEventHandler((s,e)=>{callback();});
        }
        public void Start()
        {
            Console.WriteLine("TimeEvent Start");
            t.Start();
        }
    }
}