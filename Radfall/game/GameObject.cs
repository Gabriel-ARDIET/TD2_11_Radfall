using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radfall
{
    internal class GameObject
    {
        public double x;
        public double y;

        public GameObject()
        {
            x = 0;
            y = 0;
        }
        public GameObject(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
