using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Radfall
{
    internal class RessourceManager
    {

        private Dictionary<string, BitmapImage> images = new Dictionary<string, BitmapImage>();

        public void LoadImage(string imgName, string filename)
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(filename);

            // Charger l'image en mémoire
            // Garde l'image en mémoire pour pouvoir y accéder rapidement
            image.CacheOption = BitmapCacheOption.OnLoad;

            images.Add(imgName, image);

            image.EndInit();
        }

        public BitmapImage GetImage(string imgName)
        {
            return images[imgName];
        }

    }
}
