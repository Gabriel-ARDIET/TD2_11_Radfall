using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Radfall.core
{
    internal class Animation
    {

        public static string ImgNaming { get; set; } = "_";

        public BitmapImage[] Imgs {  get; set; }

        public uint NbImgs { get; private set; }

        public double FrameInterval { get; set; }

        public Animation(string pathImg, uint NbImgs, double FrameInterval) {
            // Setup les attributs
            this.NbImgs = NbImgs;
            this.FrameInterval = FrameInterval;

            // Initialise le tableau des  bitmaps
            Imgs = new BitmapImage[NbImgs];

            // Load toutes les images pour l'animation
            for (int i = 0; i < NbImgs; i++) {
                Imgs[i] = RessourceManager.LoadBitmap(pathImg + ImgNaming + i);
            }
        }  
    }
}
