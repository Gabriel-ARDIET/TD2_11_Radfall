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
        private Canvas renderTarget;

        public Camera camera = new Camera();
        public Renderer(Canvas canva) {
            renderTarget = canva;
        }

        // Ajouter des éléments au render target
        public void Draw(Drawable obj)
        {
            if (camera.x < obj.x + obj.width && 
                camera.x + camera.Width > obj.x &&
                camera.y < obj.y + obj.height &&
                camera.y + camera.Width > obj.y)
            {
                obj.img.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                obj.img.Visibility = System.Windows.Visibility.Visible;
            }
        } 
    }
}
