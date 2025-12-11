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

        private Drawable fond;

        public Player player;

        public Game(Canvas canva) { 
            this.canva = canva;

            renderer = new Renderer(this.canva);

            RessourceManager.AssetsDirectory = "../../../assets/";

            player = new Player(100, 100, RessourceManager.LoadImage("Perso.png"));

            canva.Children.Add(player.img);
            Canvas.SetZIndex(player.img, 1);

            fond = new Drawable(0, 0, RessourceManager.LoadImage("hollow.jpg"));
            canva.Children.Add(fond.img);
            Canvas.SetZIndex(player.img, 3);
        }

        private void Input()
        {
            if (InputManager.left)
            {
                player.VelocityX = 1000;
            }
            else if (InputManager.right)
            {
                player.VelocityX = -1000;
            }
            else
                player.VelocityX = 0;
            if (InputManager.top)
            {
                player.VelocityY = -1000;
            }
            else if (InputManager.bottom)
            {
                player.VelocityY = 1000;
            }
            else
                player.VelocityY = 0;
        }

        private void Update()
        {
            timeMng.Update();

            renderer.camera.Update(canva, player);

            Debug.WriteLine(timeMng.DeltaTime);
            Debug.WriteLine(timeMng.TotalTime);

            player.Update(timeMng.DeltaTime);
        }

        private void Render()
        {
            renderer.Draw(player);
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
