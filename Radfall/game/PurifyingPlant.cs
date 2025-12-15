using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Radfall.game
{
    internal class PurifyingPlant : Item
    {
        public const int PURIFYING_AMOUNT = 20;
        public const int MAP_VALUE = 3;

        public PurifyingPlant(double x, double y, Image img, EntityManager entityManager) : base(x, y, img, entityManager)
        {

            this.x = x;
            this.y = y;
            this.img = img;
        }

        public override void Grab(Player player)
        {
            if (IsVisible)
            player.Heal(HealPlant.HEAL_AMOUNT);
            IsVisible = false;

        }
    }
}
