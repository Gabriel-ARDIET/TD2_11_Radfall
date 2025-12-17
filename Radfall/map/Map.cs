using Radfall.game;
using Radfall.map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Radfall
{
    internal class Map
    {
        private const short MAP_VALUE_PURIFYING_PLANT = 3;
        private const short MAP_VALUE_HEAL_PLANT = 4;
        private const short MAP_VALUE_POISON = 5;
        private const short MAP_VALUE_SLIME = 6;
        private const short MAP_VALUE_BAT = 7;

        private const uint HEIGHT_SIZE = 10;
        private const uint WIDTH_SIZE = 10;

        public const double IMG_SIZE = 1000;
        public const int COLLISION_TILE_SIZE = 50;

        private Drawable[,] foreground = new Drawable[HEIGHT_SIZE, WIDTH_SIZE];
        private Drawable[,] background = new Drawable[HEIGHT_SIZE, WIDTH_SIZE];

        public Map(Canvas canva, EntityManager eMng, Player player)
        {
            // Pour chaque Tile
            for (int i = 0; i < HEIGHT_SIZE; i++)
            {
                for (int j = 0; j < WIDTH_SIZE; j++)
                {
                    Image foregroundTile = new Image
                    {
                        Source = RessourceManager.LoadStaticBitmap("map/tiles/foreground/MapForeground_" + GetIndice(i, j) + ".png"),
                        Width = IMG_SIZE,
                        Height = IMG_SIZE
                    };

                    foreground[i, j] = new Drawable(i * IMG_SIZE,
                                                    j * IMG_SIZE,
                                                    foregroundTile);

                    canva.Children.Add(foreground[i, j].img);
                    Canvas.SetZIndex(foreground[i, j].img, Renderer.LAYER_FOREGROUND);

                    Image backgroundTile = new Image
                    {
                        Source = RessourceManager.LoadStaticBitmap("map/tiles/background/MapBackground_" + GetIndice(i, j) + ".png"),
                        Width = IMG_SIZE,
                        Height = IMG_SIZE
                    };

                    background[i, j] = new Drawable(i * IMG_SIZE,
                                                    j * IMG_SIZE,
                                                    backgroundTile);

                    canva.Children.Add(background[i, j].img);
                    Canvas.SetZIndex(background[i, j].img, Renderer.LAYER_BACKGROUND);

                }
            }
            // Item
            InitItem(canva, eMng, player);
        }

        // Krita me fragmente les images en mettant un indice 1, 2, 3 etc...
        // Cette fonction permet de convertir une position en l'indice de que Krita met
        private int GetIndice(int x, int y)
        {
            return (int)WIDTH_SIZE * y + x + 1;
        }

        public void InitItem(Canvas canva, EntityManager eMng, Player player)
        {

            // Initialisations des items sur la map
            BitmapImage healPlantImg = RessourceManager.LoadBitmap("HealPlant.png");
            BitmapImage purifyingPlantImg = RessourceManager.LoadBitmap("hollow.jpg");

            Grenouille slime = new Grenouille(1100, 2500, RessourceManager.LoadImage("grenouille.jpg"), eMng, 100, 500, 1000, false, player, 10);
            Bat bat = new Bat(1300, 2700, RessourceManager.LoadImage("chauve-souris.png"), eMng, 50, 300, 0, true, player, 10);

            for (int i = 0;i < MapCollider.MapColliders.GetLength(0);i++)
            {
                for (int j = 0; j < MapCollider.MapColliders.GetLength(1);j++)
                {
                    switch (MapCollider.MapColliders[i, j])
                    {
                        case MAP_VALUE_PURIFYING_PLANT:
                            PurifyingPlant purifyingPlant = new PurifyingPlant(j * Map.COLLISION_TILE_SIZE, i * Map.COLLISION_TILE_SIZE, RessourceManager.LoadImage("animation/PoisonPlant/PlantPosion_0.png"), eMng);
                            break;
                        case MAP_VALUE_HEAL_PLANT:
                            HealPlant healPlant = new HealPlant(j * Map.COLLISION_TILE_SIZE, i * Map.COLLISION_TILE_SIZE, RessourceManager.LoadImage("animation/HealPlant/JumpPlant_0.png"), eMng);
                            break;
                        case MAP_VALUE_POISON:
                            Poison poison = new Poison(j * Map.COLLISION_TILE_SIZE, i * Map.COLLISION_TILE_SIZE, RessourceManager.LoadImage("poison.png"), eMng, 2);
                            break;
                        case MAP_VALUE_SLIME:
                            Spawner spawnerSlime = new Spawner(j * Map.COLLISION_TILE_SIZE, i * Map.COLLISION_TILE_SIZE, RessourceManager.LoadImage("poison.png"), eMng, slime, 5);
                            break;
                        case MAP_VALUE_BAT:
                            Spawner spawnerBat = new Spawner(j * Map.COLLISION_TILE_SIZE, i * Map.COLLISION_TILE_SIZE, RessourceManager.LoadImage("poison.png"), eMng, bat, 5);
                            break;
                    }
                }
            }

        }

        public void Draw(Renderer renderer)
        {
            for (int i = 0; i < HEIGHT_SIZE; i++)
            {
                for (int j = 0; j < WIDTH_SIZE; j++)
                {
                    renderer.Draw(background[i, j]);
                    renderer.Draw(foreground[i, j]);
                }
            }
        }

    }
}
