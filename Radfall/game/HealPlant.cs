using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Radfall.game
{
    internal class HealPlant : Item
    {
        public const int HEAL_AMOUNT = 20;

        public HealPlant(double x, double y, Image img) : base (x, y, img)
        {

            this.x = x;
            this.y = y;
            this.img = img;
        }

        public override void Grab(Player player)
        {
            player.Heal(HealPlant.HEAL_AMOUNT);   
        }
    }
}
