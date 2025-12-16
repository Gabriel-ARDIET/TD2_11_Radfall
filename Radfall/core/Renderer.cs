using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Radfall
{
    internal class Renderer
    {

        public const short LAYER_BACKGROUND = 1;
        public const short LAYER_ENTITY = 2;
        public const short LAYER_FOREGROUND = 3;
        public const short LAYER_UI = 4;

        private Canvas renderTarget;

        public Camera camera = new Camera();
        public Renderer(Canvas canva) {
            renderTarget = canva;
        }

        // Ajouter des éléments au render target
        public void Draw(Drawable obj)
        {
            if (camera.x + camera.Width >= obj.x &&
                camera.x <= obj.x + obj.width &&
                camera.y + camera.Height >= obj.y &&
                camera.y <= obj.y + obj.height)
            {
                obj.img.Visibility = System.Windows.Visibility.Visible;

                Canvas.SetLeft(obj.img, obj.x - camera.x);
                Canvas.SetTop(obj.img, obj.y - camera.y);
            }
            else
            {
                obj.img.Visibility = System.Windows.Visibility.Hidden;
            }
        }
    }
}
