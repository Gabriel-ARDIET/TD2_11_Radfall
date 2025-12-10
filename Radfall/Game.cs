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

        private TimeManager timeMng = new TimeManager();

        private Renderer renderer;

        Drawable sprite;

        public Game(Canvas canva) { 
            renderer = new Renderer(canva);

            RessourceManager.AssetsDirectory = "../../../assets/";

            sprite = new Drawable
            {
                x = 0,
                y = 0,
                width = 100,
                height = 100,
                img = RessourceManager.LoadImage("test.png")
            };
            canva.Children.Add(sprite.img);
        }

        private void Update()
        {
            timeMng.Update();
            renderer.camera.Update(sprite);
            Debug.WriteLine(timeMng.DeltaTime);
            Debug.WriteLine(timeMng.TotalTime);
        }

        private void Render()
        {
            renderer.Draw(sprite);
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
