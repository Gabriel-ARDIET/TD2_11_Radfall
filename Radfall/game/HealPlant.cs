using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Radfall.game
{
    internal class HealPlant : Item
    {
        public const int HEAL_AMOUNT = 20;
        public const int MAP_VALUE = 4;

        public HealPlant(double x, double y, Image img, EntityManager entityManager) : base (x, y, img, entityManager)
        {

            this.x = x;
            this.y = y;
            this.img = img;
        }

        public override void IsGrabbed(Player player)
        {
            if (IsVisible)
            {
                player.Heal(HealPlant.HEAL_AMOUNT);
                IsVisible = false;
                TimeManager.AddTimer(RespawnTime, () => { IsVisible = true; });
            }
        }
    }
}
