using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace Radfall.game
{
    internal class PlayerUI
    {
        private Player player;

        private Canvas canva;

        private Rectangle healthBar;

        private Rectangle poisonBar;

        public const double BAR_HEIGHT = 20;

        public const double BAR_WIDTH = 200;

        public const int X = 50;
        public const int Y = 50;

        public const int GAP = 25;

        public PlayerUI(Player player, Canvas canva) 
        {
            this.player = player;
            this.canva = canva;

            healthBar = new Rectangle();
            healthBar.Width = BAR_WIDTH;
            healthBar.Height = BAR_HEIGHT;
            healthBar.Fill = Brushes.Green;
            canva.Children.Add(healthBar);

            poisonBar = new Rectangle();
            poisonBar.Width = BAR_WIDTH;
            poisonBar.Height = BAR_HEIGHT;
            poisonBar.Fill = Brushes.Violet;
            canva.Children.Add(poisonBar);
        }

        public void Update()
        {
            // Update healthBar
            double healthRatio = (double)player.Health / (double)player.MaxHealth;
            healthBar.Width = healthRatio * BAR_WIDTH;

            // Update poisonBar
            double poisonRatio = (double)player.Health / (double)player.MaxHealth;
            poisonBar.Width = poisonRatio * BAR_WIDTH;
        }

        public void Draw()
        {

        }
    }
}
