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

        private EntityManager entityManager;

        public Player player;

        private Map map;

        public Monster monster;

        public Game(Canvas canva) { 
            this.canva = canva;

            entityManager = new EntityManager(canva);

            renderer = new Renderer(this.canva);

            RessourceManager.AssetsDirectory = "../../../assets/";

            player = new Player(100, 100, RessourceManager.LoadImage("Perso.png"));
            entityManager.Add(player);

            monster = new Monster(300, 300, RessourceManager.LoadImage("chauve-souris.png"),1,"chauve-souris",player,10);
            entityManager.Add(monster);

            fond = new Drawable(0, 0, RessourceManager.LoadImage("hollow.jpg"));
            canva.Children.Add(fond.img);
            Canvas.SetZIndex(player.img, 3);

            map = new Map();
            map.Init(canva);

            InputManager.BindKey(Action.Left, Key.Q);
            InputManager.BindKey(Action.Right, Key.D);
        }

        private enum Action
        {
            Left,
            Right,
            Jump
        }

        private void Input()
        {
           if (InputManager.IsActionActive(Action.Left))
           {
                player.x -= 1000 * timeMng.DeltaTime;
           }
            if (InputManager.IsActionActive(Action.Right))
            {
                player.x += 1000 * timeMng.DeltaTime;
            }
        }

        private void Update()
        {
            timeMng.Update();

            renderer.camera.Update(canva, player);

            entityManager.UpdateAll(timeMng.DeltaTime);
        }

        private void Render()
        {
            entityManager.RenderAll(renderer);
            renderer.Draw(fond);
            map.Draw(renderer);
        }
        public void Jeu(object? sender, EventArgs e)
        {   
            Input();
            Update();
            Render();
        }
    }
}
