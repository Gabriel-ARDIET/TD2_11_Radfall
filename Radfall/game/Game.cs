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

        private Renderer renderer;

        private Drawable fond;

        private EntityManager entityManager;

        private Map map;

        public Player player;

        public Monster monster;

        public enum Action
        {
            Left,
            Right,
            Jump,
            BaseAttack
        }

        public Game(Canvas canva) { 
            // Setup le canva
            this.canva = canva;

            // Créer les instances nécessaires
            entityManager = new EntityManager(canva);

            renderer = new Renderer(this.canva);

            RessourceManager.AssetsDirectory = "../../../assets/";

            player = new Player(1000, 1500, RessourceManager.LoadImage("Perso.png"),entityManager,100,500,1000,false);
            entityManager.Add(player);

            monster = new Monster(300, 300, RessourceManager.LoadImage("chauve-souris.png"), entityManager, 100,200,0,true,player,10);
            entityManager.Add(monster);

            map = new Map();
            map.Init(canva);

            // Setup les Input
            InputManager.BindKey(Game.Action.Left, Key.Q);
            InputManager.BindKey(Game.Action.Right, Key.D);
            InputManager.BindKey(Game.Action.Jump, Key.Space);
            InputManager.BindKey(Game.Action.BaseAttack, Key.E);
        }

        private void HandleInput()
        {
            if (InputManager.IsActionActive(Action.Left))
            {
                player.MoveLeft();
            }
            if (InputManager.IsActionActive(Action.Right))
            {
                player.MoveRight();
            }
            if (InputManager.IsActionActive(Action.Jump))
            {
                player.Jump();
            }
            if (InputManager.IsActionActive(Action.BaseAttack))
            {
                player.BaseAttack();
            }
        }

        private void Update()
        {
            TimeManager.Update();

            renderer.camera.Update(canva, player);

            entityManager.UpdateAll(TimeManager.DeltaTime);
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
