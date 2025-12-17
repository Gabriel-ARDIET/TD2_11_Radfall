using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace Radfall.game
{
    internal class Poison : Entity
    {
        private const double POISON_INTERVAL = 1;
        public int Amount { get; set; }
        double timer = 0;

        public Poison(double x, double y, Image img, EntityManager entityManager, int amount) : base (x, y, img, entityManager)
        {
            this.x = x;
            this.y = y;
            this.Amount = amount;
            img.Source = RessourceManager.LoadBitmap("poison.png");
        }

        public override void Update(double dTime)
        {
            base.Update(dTime);
        }

        internal void InflictPoison(Player player)
        {
            timer += TimeManager.DeltaTime;
            if (timer >= POISON_INTERVAL)
            {
                timer = 0;
                player.TakePoison(Amount);
            }
        }
    }
}
