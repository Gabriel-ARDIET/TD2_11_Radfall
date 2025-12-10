using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radfall
{
    internal class Camera : GameObject
    {

        public enum CameraFollowMode
        {
            Direct,
            Smooth
        }

        public double Width { get; set; }
        public double Height { get; set; }

        public CameraFollowMode CurrentFollowMode { get; set; } = CameraFollowMode.Smooth;

        private const double DEFAULT_SPEED_FACTOR = 1.0;

        public double SpeedFactor { get; set; } = DEFAULT_SPEED_FACTOR;

        public void Update(GameObject obj)
        {
            if (CurrentFollowMode == CameraFollowMode.Direct)
            {
                // Le this n'est pas nécessaire mais c'est plus lisible
                this.x = obj.x;
                this.y = obj.y;
            }

            else if (CurrentFollowMode == CameraFollowMode.Smooth)
            {
                // On calcule la distance entre les 2 points sur les 2 axes
                double distanceX = this.x - obj.x;
                double distanceY = this.y - obj.y;

                // Plus l'écart est grand plus on ramène la caméra
                this.x = SpeedFactor * -distanceX;
                this.y = SpeedFactor * -distanceY;
            }
        }
    }
}
