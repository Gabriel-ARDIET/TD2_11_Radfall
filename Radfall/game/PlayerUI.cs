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
        private Image healthBarImg;

        private Rectangle poisonBar;
        private Image poisonBarImg;

        public const double BAR_HEIGHT = 15;

        public const double BAR_WIDTH = 425;

        public const int X = 50;
        public const int Y = 50;

        public const int GAP = 50;

        public const int Z_INDEX = 4;

        public PlayerUI(Player player, Canvas canva) 
        {
            this.player = player;
            this.canva = canva;

            healthBar = new Rectangle();
            healthBar.Width = BAR_WIDTH;
            healthBar.Height = BAR_HEIGHT;
            healthBar.Fill = Brushes.Green;
            canva.Children.Add(healthBar);
            Canvas.SetLeft(healthBar, X+30);
            Canvas.SetTop(healthBar, Y+63);
            Canvas.SetZIndex(healthBar, Z_INDEX);

            healthBarImg = RessourceManager.LoadImage("ui/SmallBar.png");
            healthBarImg.Width = 500;
            canva.Children.Add(healthBarImg);
            Canvas.SetLeft(healthBarImg, X);
            Canvas.SetTop(healthBarImg, Y);
            Canvas.SetZIndex(healthBarImg , Z_INDEX+1);


            poisonBar = new Rectangle();
            poisonBar.Width = BAR_WIDTH;
            poisonBar.Height = BAR_HEIGHT;
            poisonBar.Fill = Brushes.Violet;
            canva.Children.Add(poisonBar);
            Canvas.SetLeft(poisonBar, X);
            Canvas.SetTop(poisonBar, Y + GAP);
            Canvas.SetZIndex(poisonBar, Z_INDEX);
        }

        public void Update()
        {
            // Update healthBar
            double healthRatio = (double)player.Health / (double)player.MaxHealth;
            healthBar.Width = healthRatio * BAR_WIDTH;

            // Update poisonBar
            double poisonRatio = (double)player.Poison / (double)player.MaxPoison;
            poisonBar.Width = poisonRatio * BAR_WIDTH;
        }
    }
}
