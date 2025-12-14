using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
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
        public UCJeu()
        {
            InitializeComponent();
        }

        public void GameLoop(Game radfall)
        {
            // Init le timer
            minuterie = new DispatcherTimer();
            minuterie.Interval = TimeSpan.FromMilliseconds(16);
            minuterie.Tick += radfall.Run;
            minuterie.Start();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.KeyDown += InputManager.KeyDown;
            Application.Current.MainWindow.KeyUp += InputManager.KeyUp;
        }   
    }
}
