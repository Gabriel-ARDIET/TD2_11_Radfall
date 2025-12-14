using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Radfall
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UCMenuPrincipal ucMenu;

        private UCJeu ucJeu;

        private Game radfall;

        public MainWindow()
        {
            InitializeComponent();

            ucMenu = new UCMenuPrincipal();
            ucJeu = new UCJeu();
            radfall = new Game(ucJeu.canva);

            ShowMainMenu();   
        }

        private void ShowMainMenu()
        { 
            ZoneJeu.Content = ucMenu;
            ucMenu.butJouer.Click += ShowGame;
        }

        private void ShowGame(object sender, RoutedEventArgs e)
        {  
            ZoneJeu.Content = ucJeu;
            ucJeu.GameLoop(radfall);
        }
    }
}