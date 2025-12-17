using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Radfall.game
{
    internal class Spawner : Entity
    {
        Being Being { get; set; }
        double SpawningInterval { get; set; }
        int MaxBeings { get; set; }
        double timer = 0;
        private List<Being> beings = new List<Being>();
        private List<Being> toRemove = new List<Being>();
        public Spawner(double x, double y, Image img, EntityManager entityManager, Being being, double spawningInterval, int maxBeings) : base (x, y, img, entityManager)
        {
            img.Opacity = 0;
            Being = being;
            SpawningInterval = spawningInterval;
            MaxBeings = maxBeings;
        }
        public override void Update(double dTime)
        {
            timer += dTime;
            if (timer >= SpawningInterval)
            {
                timer = 0;
                SpawnBeing();
                RemoveDeadBeings();
            }
        }

        private void SpawnBeing()
        {
            if (img.Visibility == System.Windows.Visibility.Visible && beings.Count < MaxBeings)
                beings.Add(Being.Clone(x,y));
        }
        private void RemoveDeadBeings()
        {
            foreach (var being in beings)
            {
                if (being.Health <= 0)
                    toRemove.Add(being);
            }
            foreach (var being in toRemove)
            {
                beings.Remove(being);
            }
            toRemove.Clear();
        }
    }
}
