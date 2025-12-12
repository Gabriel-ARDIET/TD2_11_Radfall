using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace Radfall.game
{
    internal class Poison : Drawable
    {

        public double damage { get; set; }

        public double accoutumance { get; set; }

        public Poison (double x, double y, Image img) : base (x, y, img)
        {
                
        }



    }
}
