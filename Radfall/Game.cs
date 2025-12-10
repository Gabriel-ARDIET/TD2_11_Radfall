using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Radfall
{
    internal class Game
    {
        private static DispatcherTimer minuterie;

        private RessourceManager ressourceMng;

        private TimeManager timeMng = new TimeManager();

        public Game() { }

        private void Update()
        {
            timeMng.Update();
            Debug.WriteLine(timeMng.GetDeltaTime());
            Debug.WriteLine(timeMng.GetTotalTime());
        }
        public void Jeu(object? sender, EventArgs e)
        {   
            Update();
        }
    }
}
