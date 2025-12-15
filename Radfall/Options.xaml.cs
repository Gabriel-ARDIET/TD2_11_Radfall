using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Radfall
{
    /// <summary>
    /// Logique d'interaction pour Options.xaml
    /// </summary>
    public partial class Options : Window
    {
        public Dictionary<Game.Action, Key> inputs = new Dictionary<Game.Action, Key>();
        public Options()
        {
            InitializeComponent();
        }
        private void KeyCapture(object sender, KeyEventArgs e)
        {
            e.Handled = true; // empêche l’écriture dans la TextBox
            Key key = e.Key;
            ((TextBox)sender).Text = key.ToString();
            switch (((TextBox)sender).Name)
            {
                case "txtGauche":
                    inputs.Add(Game.Action.Left, key);
                    break;
                case "txtDroite":
                    inputs.Add(Game.Action.Right, key);
                    break;
                case "txtSaut":
                    inputs.Add(Game.Action.Jump, key);
                    break;
            }

        }

        private void butValider_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void butAnnuler_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void txtGotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = "";
        }
    }
}
