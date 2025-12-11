using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Xml.Linq;

namespace Radfall
{
    internal class Tile : Drawable
    {
        public bool[,] collider { get; set; } = new bool[10,10];

        public Tile(double x, double y, Image img, bool[,] collider)
        : base(x, y, img)
        {
            this.collider = collider;
        }
    }
}
