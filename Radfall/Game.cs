using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using System.Windows.Threading;

namespace Radfall
{
    internal class Game
    {
        private static DispatcherTimer minuterie;

        private Canvas canva;

        public TimeManager timeMng = new TimeManager();

        private Renderer renderer;

        public Drawable sprite;
        private Drawable fond;

        public Game(Canvas canva) { 
            this.canva = canva;

            renderer = new Renderer(this.canva);

            RessourceManager.AssetsDirectory = "../../../assets/";

            sprite = new Drawable(100, 100, RessourceManager.LoadImage("Perso.png"));
            canva.Children.Add(sprite.img);
            Canvas.SetZIndex(sprite.img, 1);

            fond = new Drawable(0, 0, RessourceManager.LoadImage("hollow.jpg"));
            canva.Children.Add(fond.img);
            Canvas.SetZIndex(sprite.img, 3);
        }

        private void Input()
        {
            if (InputManager.left)
            {
                sprite.x += 1000 * timeMng.DeltaTime;
            }
            if (InputManager.right)
            {
                sprite.x -= 1000 * timeMng.DeltaTime;
            }
            if (InputManager.top)
            {
                sprite.y -= 1000 * timeMng.DeltaTime;
            }
            if (InputManager.bottom)
            {
                sprite.y += 1000 * timeMng.DeltaTime;
            }
        }

        private void Update()
        {
            timeMng.Update();

            renderer.camera.Update(canva, sprite);

            Debug.WriteLine(timeMng.DeltaTime);
            Debug.WriteLine(timeMng.TotalTime);
        }

        private void Render()
        {
            renderer.Draw(sprite);
            renderer.Draw(fond);

        }
        public void Jeu(object? sender, EventArgs e)
        {   
            Input();
            Update();
            Render();
        }
    }
}
