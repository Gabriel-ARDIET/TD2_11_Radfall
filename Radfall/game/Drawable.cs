using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace Radfall
{
    internal class Drawable : GameObject
    {
        public Image img;
        public double width;
        public double height;

        public Drawable(double x,  double y, Image img)
        {
            this.x = x;
            this.y = y;
            this.img = img;
            this.width = img.Width;
            this.height = img.Height;
        }
    }
}
