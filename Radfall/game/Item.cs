using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Radfall.game
{
    internal class Item : Entity
    {
        public uint RespawnTime = 60;

        public Item(double x, double y, Image img, EntityManager entityManager): base(x, y, img, entityManager)
        {
            this.x = x;
            this.y = y;
            this.img = img;
            IsVisible = true;
        }

        public virtual void IsGrabbed(Player player) { }
    }
}
