using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Radfall
{
    internal class Player : Entity
    {
        public Player(double x, double y, Image img, int id = 0, string name = "Player") : base(x, y, img, id, name)
        {
            GravityScale = 10;
        }
    }
}
