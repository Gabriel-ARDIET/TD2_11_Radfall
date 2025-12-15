using Radfall.game;
using Radfall.map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Radfall
{
    internal class Map
    {
        private const uint HEIGHT_SIZE = 3;
        private const uint WIDTH_SIZE = 3;

        public const double IMG_SIZE = 1000;
        public const int COLLISION_TILE_SIZE = 100;

        private const int MAP_Z_INDEX = 1;

        private const int ITEM_Z_INDEX = 0;

        private Tile[,] tiles = new Tile[HEIGHT_SIZE, WIDTH_SIZE];

        public Map()
        {
        }

        // Krita me fragmente les images en mettant un indice 1, 2, 3 etc...
        // Cette fonction permet de convertir une position en l'indice de que Krita met
        private int GetIndice(int x, int y)
        {
            return (int)WIDTH_SIZE * y + x + 1;
        }

        public void Init(Canvas canva, EntityManager eMng)
        {
            // Pour chaque Tile
            for (int i  = 0; i < HEIGHT_SIZE; i++)
            {
                for (int j = 0; j < WIDTH_SIZE; j++)
                {
                    // Initialisation de chaque tile
                    tiles[i, j] = new Tile(i * IMG_SIZE, 
                                           j * IMG_SIZE, 
                                           RessourceManager.LoadImage("Radfall_map/Map_" + GetIndice(i,j) + ".png"));
                    
                    // Ajoute au canva en mettant le z-index
                    canva.Children.Add(tiles[i, j].img);
                    Canvas.SetZIndex(tiles[i, j].img, MAP_Z_INDEX);
                }
            }

            // Initialisations des items sur la map
            BitmapImage healPlantImg = RessourceManager.LoadBitmap("HealPlant.png");
            BitmapImage purifyingPlantImg = RessourceManager.LoadBitmap("hollow.jpg");

            for (int i = 0;i < MapCollider.MapColliders.GetLength(0);i++)
            {
                for (int j = 0; j < MapCollider.MapColliders.GetLength(1);j++)
                {
                    if (MapCollider.MapColliders[i,j] == HealPlant.MAP_VALUE)
                    {
                        double posX = j * Map.COLLISION_TILE_SIZE;
                        double posY = i * Map.COLLISION_TILE_SIZE;
                        //Image img = new Image { Source : healPlantImg};

                        Image img;
                        img = new Image();
                        img.Source = healPlantImg;
                        img.Width = 100;
                        img.Height = 100;

                        HealPlant plant = new HealPlant(posX, posY, img, eMng);
                    }
                    else if (MapCollider.MapColliders[i, j] == PurifyingPlant.MAP_VALUE)
                    {
                        double posX = j * Map.COLLISION_TILE_SIZE;
                        double posY = i * Map.COLLISION_TILE_SIZE;

                        Image img;
                        img = new Image();
                        img.Source = purifyingPlantImg;
                        img.Width = 100;
                        img.Height = 100;

                        HealPlant plant = new HealPlant(posX, posY, img, eMng);
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
                    renderer.Draw(tiles[i, j]);
                }
            }
        }

    }
}
