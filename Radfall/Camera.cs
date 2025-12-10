using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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

        private const double DEFAULT_SPEED_FACTOR = 0.2;

        public double SpeedFactor { get; set; } = DEFAULT_SPEED_FACTOR;

        public void Update(Canvas canva, Drawable obj)
        {
            if (CurrentFollowMode == CameraFollowMode.Direct)
            {
                //this.x = obj.x + (obj.width - canva.Width) / 2;
                //this.y = obj.y + (obj.height - canva.Height) / 2;

                // Le this n'est pas nécessaire mais c'est plus lisible
                this.x = obj.x + (obj.width - 1920) / 2;
                this.y = obj.y + (obj.height - 1080) / 2;
            }

            else if (CurrentFollowMode == CameraFollowMode.Smooth)
            {
                // On calcule la distance entre la ou est la camera et la ou elle devrait être
                // on remarque que la position ou la camera devrait être est la position calculé
                // dans le mode camera Direct
                double distanceX = this.x - (obj.x + (obj.width - 1920) / 2);
                double distanceY = this.y - (obj.y + (obj.height - 1080) / 2);

                // Plus l'écart est grand plus on ramène la caméra
                this.x -= SpeedFactor * distanceX;
                this.y -= SpeedFactor * distanceY;
            }
        }
    }
}
