using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Radfall.core
{
    /// <summary>
    /// Contains everything useful for an animation.
    /// </summary>
    internal class Animation
    {
        const string DEFAULT_IMG_NAMING = "_";

        /// <summary>
        /// Symbols between the name of the image and the format.
        /// </summary>
        // Ex : name = "Player" ImgNaming = "_" => will load every Player_nb.png
        public static string ImgNaming { get; set; } = DEFAULT_IMG_NAMING;

        /// <summary>
        /// Store all the frames
        /// </summary>
        public BitmapImage[] Imgs {  get; set; }

        /// <summary>
        /// Number of frame
        /// </summary>
        public uint NbImgs { get; private set; }

        /// <summary>
        /// Time between each frames
        /// </summary>
        public double FrameInterval { get; set; }

        /// <summary>
        /// Load automaticcely all the images.
        /// </summary>
        /// <param name="pathImg"> name of the image with the pass without the format (.png)</param>
        public Animation(string pathImg, uint NbImgs, double FrameInterval) {

            // Setup attributes
            this.NbImgs = NbImgs;
            this.FrameInterval = FrameInterval;

            // Initialize the bitmap array
            Imgs = new BitmapImage[NbImgs];

            // Load every images
            for (int i = 0; i < NbImgs; i++) {
                Imgs[i] = RessourceManager.LoadBitmap(pathImg + ImgNaming + i);
            }
        }  
    }
}
