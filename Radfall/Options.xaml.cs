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
                    HandleKeyChange(Game.Action.Left, key);
                    break;
                case "txtDroite":
                    HandleKeyChange(Game.Action.Right, key);
                    break;
                case "txtHaut":
                    HandleKeyChange(Game.Action.Up, key);
                    break;
                case "txtBas":
                    HandleKeyChange(Game.Action.Down, key);
                    break;
                case "txtSaut":
                    HandleKeyChange(Game.Action.Jump, key);
                    break;
                case "txtAttaquer":
                    HandleKeyChange(Game.Action.BaseAttack, key);
                    break;
                case "txtDash":
                    HandleKeyChange(Game.Action.Dash, key);
                    break;
                case "txtNoClip":
                    HandleKeyChange(Game.Action.NoClip, key);
                    break;
            }
        }

        private void HandleKeyChange(Game.Action action,Key key)
        {
            if (inputs.ContainsKey(action))
                inputs[action] = key;
            else
                inputs.Add(action, key);
        }

        private void butValider_Click(object sender, RoutedEventArgs e)
        {
            bool valeursUniques = inputs.Values.Distinct().Count() == inputs.Count;
            if (valeursUniques)
                DialogResult = true;
            else
                MessageBox.Show("Veuillez entrer des touches différentes pour chaque actions.","Erreur",MessageBoxButton.OK,MessageBoxImage.Error);
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
