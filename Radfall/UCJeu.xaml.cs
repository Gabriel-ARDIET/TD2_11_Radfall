using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Radfall
{
    /// <summary>
    /// Logique d'interaction pour UCJeu.xaml
    /// </summary>
    public partial class UCJeu : UserControl
    {
        private static DispatcherTimer minuterie;

        private Game radfall;
        public UCJeu()
        {
            InitializeComponent();

            // Initailisation ici car sinon canva n'est pas encore initialisé avant
            radfall = new Game(canva);

            InitTimer();
        }

        private void InitTimer()
        {
            // Init le timer
            minuterie = new DispatcherTimer();
            minuterie.Interval = TimeSpan.FromMilliseconds(16);
            minuterie.Tick += radfall.Jeu;
            minuterie.Start();
        }
    }
}
