using Radfall.game;
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
    public class Game
    {
        private static DispatcherTimer minuterie;
        private Canvas canva;
        private Renderer renderer;
        private EntityManager entityManager;
        private Map map;
        private GameUI gameUI;
        private Player player;
        private Monster monster;

        public enum Action
        {
            Left,
            Right,
            Jump,
            BaseAttack,
            Dash,
            NoClip
        }

        public Game(Canvas canva) { 
            // Setup le canva
            this.canva = canva;

            // Créer les instances nécessaires
            entityManager = new EntityManager(canva);

            renderer = new Renderer(this.canva);

            RessourceManager.AssetsDirectory = "../../../assets/";

            player = new Player(1000, 2500, RessourceManager.LoadImage("Perso.png"),entityManager,100,800,1000,false);
            entityManager.Add(player);
            player = new Player(1000, 2500, RessourceManager.LoadImage("Perso.png"),entityManager,100,500,1500,false);

            monster = new Grenouille(1100, 2500, RessourceManager.LoadImage("grenouille.jpg"), entityManager, 100,500,1000,false,player,10);

            map = new Map(canva, entityManager);

            // Setup les Input
            InputManager.BindKey(Action.Left, Key.Q);
            InputManager.BindKey(Action.Right, Key.D);
            InputManager.BindKey(Action.Jump, Key.Space);
            InputManager.BindKey(Action.BaseAttack, Key.E);
            InputManager.BindKey(Action.Dash, Key.LeftShift);
            InputManager.BindKey(Action.NoClip, Key.F3);

            // Setup ui
            gameUI = new GameUI(player, canva);
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
            if(InputManager.IsActionActive(Action.Dash))
            {
                player.Dash();
            }
            if (InputManager.IsActionActive(Action.NoClip))
            {
                player.ActivateNoClip();
            }
        }

        private void Update()
        {
            TimeManager.Update();

            renderer.camera.Update(canva, player);

            entityManager.UpdateAll(TimeManager.DeltaTime);

            gameUI.Update();
        }

        private void Render()
        {
            entityManager.RenderAll(renderer);
            map.Draw(renderer);
        }

        public void Run(object? sender, EventArgs e)
        {   
            HandleInput();
            Update();
            Render();
        }
    }
}
