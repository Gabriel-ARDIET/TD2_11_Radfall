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
            // On check d'abord si l'image est en collision avec le rect
            // de la caméra pour voir si on affiche ou pas l'image

            //if (camera.x + camera.Width >= obj.x &&
            //    camera.x <= obj.x + obj.width &&
            //    camera.y + camera.Height >= obj.y &&
            //    camera.y <= obj.y + obj.height)
            bool a = camera.x + camera.Width >= obj.x;
            bool b = camera.x <= obj.x + obj.width;
            bool c = camera.y + camera.Height >= obj.y;
            bool d = camera.y <= obj.y + obj.height;

            if (a && b && c && d)
            {
                obj.img.Visibility = System.Windows.Visibility.Visible;

                // Mettre l'image a la bonne position en fonction de la camera
                // Par contre jsp pk vs community me dit de mettre Canvas au lieu de l'instance canva
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
