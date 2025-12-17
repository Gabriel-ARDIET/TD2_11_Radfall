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
        double timer = 0;
        private List<Being> beings = new List<Being>();

        public uint Capacity { get; set; } = 3;

        private int counter = 0;

        public Spawner(double x, double y, Image img, EntityManager entityManager, Being being, double spawningInterval) : base (x, y, img, entityManager)
        {
            IsVisible = false;
            Being = being;
            SpawningInterval = spawningInterval;
        }
        public override void Update(double dTime)
        {
            timer += dTime;
            if (timer >= SpawningInterval)
            {
                timer = 0;
                SpawnBeing();
            }
        }

        private void SpawnBeing()
        {
            if (counter < Capacity)
            {
                beings.Add(Being.Clone(x, y));
                counter++;
            }
        }
    }
}
