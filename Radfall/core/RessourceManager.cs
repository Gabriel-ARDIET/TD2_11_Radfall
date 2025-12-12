using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace Radfall
{
    internal class RessourceManager
    {

        // Ex : rep1/rep2/assets/
        public static string AssetsDirectory { get; set; } = "";

        public static Image LoadImage(string filename)
        {
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(AssetsDirectory + filename, UriKind.Relative);

            // Charger l'image en mémoire
            // Garde l'image en mémoire pour pouvoir y accéder rapidement
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;

            bitmapImage.EndInit();

            Image img = new Image
            {
                Source = bitmapImage,
                Width = bitmapImage.PixelWidth,
                Height = bitmapImage.PixelHeight
            };

            return img;
        }

        public static BitmapImage LoadBitmap(string filename)
        {
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(AssetsDirectory + filename, UriKind.Relative);

            // Charger l'image en mémoire
            // Garde l'image en mémoire pour pouvoir y accéder rapidement
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;

            bitmapImage.EndInit();
            
            return bitmapImage;
        }
    }
} 
