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

        private Map map;

        public Player player;

        public Monster monster;

        private enum Action
        {
            Left,
            Right,
            Jump
        }

        public Game(Canvas canva) { 
            // Setup le canva
            this.canva = canva;

            // Créer les instances nécessaires
            entityManager = new EntityManager(canva);

            renderer = new Renderer(this.canva);

            RessourceManager.AssetsDirectory = "../../../assets/";

            player = new Player(500, 2000, RessourceManager.LoadImage("Perso.png"));
            entityManager.Add(player);

            monster = new Monster(300, 300, RessourceManager.LoadImage("chauve-souris.png"),1,"chauve-souris",player,10);
            entityManager.Add(monster);

            map = new Map();
            map.Init(canva);

            // Setup les Input
            InputManager.BindKey(Action.Left, Key.Q);
            InputManager.BindKey(Action.Right, Key.D);
        }

        private void HandleInput()
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
            map.Draw(renderer);
        }

        public void Jeu(object? sender, EventArgs e)
        {   
            HandleInput();
            Update();
            Render();
        }
    }
}
