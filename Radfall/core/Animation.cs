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

        public Image imgSource { get; set; }

        public BitmapImage[] Imgs {  get; set; }

        public double AnimationSpeed { get; set; }

        private bool IsActive = false;

        public Animation(Drawable sprite, string pathImg, uint nbImgs, double AnimationSpeed) {
            // Setup les attributs
            this.AnimationSpeed = AnimationSpeed;

            // On récupère la ref de l'image
            imgSource = sprite.img;

            // Initialise le tableau des bitmaps
            Imgs = new BitmapImage[nbImgs];

            // Load toutes les images pour l'animation
            for (int i = 0; i < nbImgs; i++) {
                Imgs[i] = RessourceManager.LoadBitmap(pathImg + ImgNaming + i);
            }
        }  
        
        public void Active() 
        { 
            IsActive = true; 
        }

        public void Inactive()
        {
            IsActive = false;
        }
    }
}
