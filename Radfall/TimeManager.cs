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
        private Stopwatch time = new Stopwatch();

        private List<Timer> timers = new List<Timer>();

        public double TotalTime { get; private set; } = 0;

        public double DeltaTime { get; private set; } = 0;


        public TimeManager() {
            time.Start();
        }

        public void Update()
        {
            DeltaTime = time.ElapsedMilliseconds / 1000.0;
            TotalTime += DeltaTime;

            // Décompte à l'envers pour éviter des problèmes
            // Car on supprime des éléments de la liste
            // Et tous les éléments après le RemoteAt()
            // Vont voir leur index baisser de 1
            for (int i = timers.Count - 1; i >= 0; i--)
            {
                timers[i].TimeLeft -= DeltaTime;

                if (timers[i].TimeLeft <= 0)
                {
                    timers[i].Callback();
                    timers.RemoveAt(i);
                }
            }
            time.Restart();
        }

        public void AddTimer(double duration, Action callback)
        {
            timers.Add(new Timer(duration, callback));
        }
    }

    internal class Timer
    {
        // J'ai utilisé une classe car une struct passe une copie
        // par défaut, car c'est un type valeur, et je connais pas
        // trop les pointeurs et ref en c# par rapport au c++

        public double TimeLeft { get; set; }
        public Action Callback {  get; set; }

        // You need to pass the callback function by ref
        // So player.Do() become player.Do
        public Timer(double duration, Action callback)
        {
            TimeLeft = duration;
            Callback = () => callback();
        }
    }
}
