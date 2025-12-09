using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radfall
{
    class TimeManager
    {
        private Stopwatch time;

        private double totalTime;

        private double deltaTime;

        private List<Timer> timers;

        TimeManager() {
            totalTime = 0;
            time = new Stopwatch();
            time.Start();
        }

        public void Update()
        {
            deltaTime = time.ElapsedMilliseconds;
            totalTime += deltaTime;
        }

        public double GetDeltaTime()
        {
            return deltaTime;
        }

        public double GetTotalTime()
        {
            return totalTime;
        }

        //public void AddTimer(double duration, Action<void> callback)
        //{
        //    timers.Add(new Timer(duration));
        //}

    }

    /*
     To create a callback in C#, you need to store a function address 
    inside a variable. This is achieved using a delegate or the new 
    lambda semantic Func or Action.
    
    https://myelin.nz/notes/callbacks/cs-delegates.html
     */
    public struct Timer
    {
        double timer { get; set; }
        double timeLeft { get; set; }
        Action callback {  get; set; }

        //Timer(double duration)
        //{
        //    timer = duration;
        //    timeLeft = duration;
        //    callback = () => ...
        //}
    }
}
