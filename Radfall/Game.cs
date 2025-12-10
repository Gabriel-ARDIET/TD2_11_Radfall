using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Radfall
{
    internal class Game
    {
        private static DispatcherTimer minuterie;

        private Canvas canva;

        private TimeManager timeMng = new TimeManager();

        private Renderer renderer;

        Drawable sprite;
        Drawable fond;

        public Game(Canvas canva) { 
            this.canva = canva;

            renderer = new Renderer(this.canva);

            RessourceManager.AssetsDirectory = "../../../assets/";

            sprite = new Drawable(100, 100, RessourceManager.LoadImage("test.png"));
            canva.Children.Add(sprite.img);
            Canvas.SetZIndex(sprite.img, 1);

            fond = new Drawable(0, 0, RessourceManager.LoadImage("test2.jpg"));
            canva.Children.Add(fond.img);
            Canvas.SetZIndex(sprite.img, 3);
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
            renderer.Draw(fond);
            renderer.Draw(fond);
            renderer.Draw(fond);
            renderer.Draw(fond);

        }

        private void Input()
        {

        }

        public void Jeu(object? sender, EventArgs e)
        {   
            Update();
            Render();
        }
    }
}
