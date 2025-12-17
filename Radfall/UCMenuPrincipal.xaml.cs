using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
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

namespace Radfall
{
    /// <summary>
    /// Logique d'interaction pour UCMenuPrincipal.xaml
    /// </summary>
    public partial class UCMenuPrincipal : UserControl
    {
        public UCMenuPrincipal()
        {
            InitializeComponent();
        }

        private void butOption_Click(object sender, RoutedEventArgs e)
        {
            Options options = new Options();
            bool? rep = options.ShowDialog();
            if (rep == true)
            {
                foreach (var element in options.inputs)
                {
                    InputManager.ChangeKey(element.Key, element.Value);
                }
            }
        }
    }
}
