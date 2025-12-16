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
    internal class GameUI
    {
        private Player player;
        private Canvas canva;

        private Rectangle healthBar;
        private Image healthBarImg;

        private Rectangle poisonBar;
        private Image poisonBarImg;

        TimeSpan time;
        private Label chrono;
        private const int FONT_SIZE = 80;

        private const double BAR_HEIGHT = 20;
        private const double BAR_WIDTH = 600;

        private const int X = 50;
        private const int Y = 50;

        private const int GAP = 80;

        private const int DIFFERENCE_BAR_IMAGE_WIDTH = 70;
        private const int DIFFERENCE_BAR_IMAGE_HEIGHT = 24;


        public GameUI(Player player, Canvas canva) 
        {
            // Initialize properties
            this.player = player;
            this.canva = canva;

            // Player Health UI
            healthBar = new Rectangle
            {
                Width = BAR_WIDTH - DIFFERENCE_BAR_IMAGE_WIDTH,
                Height = BAR_HEIGHT,
                Fill = Brushes.Green
            };

            canva.Children.Add(healthBar);
            Canvas.SetLeft(healthBar, X + DIFFERENCE_BAR_IMAGE_WIDTH / 2);
            Canvas.SetTop(healthBar, Y + DIFFERENCE_BAR_IMAGE_HEIGHT);
            Canvas.SetZIndex(healthBar, Renderer.LAYER_UI);

            healthBarImg = new Image
            {
                Source = RessourceManager.LoadStaticBitmap("ui/SmallBar.png"),
                Width = BAR_WIDTH
            };
                
            canva.Children.Add(healthBarImg);
            Canvas.SetLeft(healthBarImg, X);
            Canvas.SetTop(healthBarImg, Y);
            Canvas.SetZIndex(healthBarImg , Renderer.LAYER_UI + 1);

            // PLayer poison UI
            poisonBar = new Rectangle
            {
                Width = BAR_WIDTH - DIFFERENCE_BAR_IMAGE_WIDTH,
                Height = BAR_HEIGHT,
                Fill = Brushes.Violet
            };

            canva.Children.Add(poisonBar);
            Canvas.SetLeft(poisonBar, X + DIFFERENCE_BAR_IMAGE_WIDTH / 2);
            Canvas.SetTop(poisonBar, Y + DIFFERENCE_BAR_IMAGE_HEIGHT + GAP);
            Canvas.SetZIndex(poisonBar, Renderer.LAYER_UI);

            poisonBarImg = new Image
            {
                Source = RessourceManager.LoadStaticBitmap("ui/SmallBar.png"),
                Width = BAR_WIDTH
            };

            canva.Children.Add(poisonBarImg);
            Canvas.SetLeft(poisonBarImg, X);
            Canvas.SetTop(poisonBarImg, Y + GAP);
            Canvas.SetZIndex(poisonBarImg, Renderer.LAYER_UI + 1);

            // Timer 
            chrono = new Label
            {
                FontSize = FONT_SIZE,
                Foreground = Brushes.White
            };
            chrono.SetResourceReference(Control.FontFamilyProperty, "AngelicSerif");

            canva.Children.Add(chrono);
            Canvas.SetLeft(chrono, X);
            Canvas.SetTop(chrono, Y + 2 * GAP);
            Canvas.SetZIndex(chrono, Renderer.LAYER_UI);

        }

        public void Update()
        {
            // Update healthBar
            double healthRatio = (double)player.Health / (double)player.MaxHealth;
            healthBar.Width = healthRatio * (BAR_WIDTH - DIFFERENCE_BAR_IMAGE_WIDTH);

            // Update poisonBar
            double poisonRatio = (double)player.Poison / (double)player.MaxPoison;
            poisonBar.Width = poisonRatio * (BAR_WIDTH - DIFFERENCE_BAR_IMAGE_WIDTH);

            // Update chrono
            time = TimeSpan.FromSeconds(TimeManager.TotalTime);
            chrono.Content = time.ToString(@"h\:mm\:ss\.f");
        }
    }
}
