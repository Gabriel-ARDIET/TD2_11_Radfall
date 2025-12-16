using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using System.Xml.Linq;
using System.Windows;
using Radfall.core;
using Radfall.map;
using System.Diagnostics;

namespace Radfall
{
    internal class Entity : Drawable
    {
        public const double GRAVITY = 30000;

        public EntityManager entityManager;
        public double VelocityX { get; set; }
        public double VelocityY { get; set; }
        public double AccelerationX { get; set; }
        public double AccelerationY {  get; set; } 
        public double oldPosX { get; set; }
        public double oldPosY { get; set; }
        public bool IsVisible { get; set; }
        public bool IsSolid { get; set; } = true;
        public bool IsGrounded { get; set; }
        public Rect Hitbox { get; set; }
        public AnimationController Animation {  get; set; }

        public Entity(double x, double y, Image img, EntityManager manager)
        : base(x, y, img)
        {
            Hitbox = new Rect(x, y, img.Width, img.Height);
            Animation = new AnimationController(img);
            oldPosX = x;
            oldPosY = y;
            entityManager = manager;
            entityManager.Add(this);
            IsVisible = true;
        }
        public virtual void Update(double dTime) // virtual permet de rendre la méthode personnalisable pour les enfants qui peuvent donc la réécrire avec override
        {
            //UpdatePhysic(dTime);
            UpdateHitbox();
            Animation.Update();
        }
        public void InitializeRenderer(Canvas canvas)
        {
            if (!canvas.Children.Contains(img))
            {
                canvas.Children.Add(img);
                Canvas.SetZIndex(img, Renderer.LAYER_ENTITY);
            }
        }
        internal void UpdateHitbox()
        {
            Hitbox = new Rect(x, y, img.Width, img.Height);
        }

        public void UpdatePhysicX()
        {
            x += VelocityX * TimeManager.DeltaTime;
            VelocityX += AccelerationX * TimeManager.DeltaTime;
            AccelerationX = 0;
        }

        public void UpdatePhysicY()
        {
            y += VelocityY * TimeManager.DeltaTime;
            VelocityY += AccelerationY * TimeManager.DeltaTime;
            AccelerationY = 0;
        }

        public bool CollideWithMap()
        {
            bool collide = false;
            // On transforme la position en de l'entity en position tile
            int tileX = (int)x / Map.COLLISION_TILE_SIZE;
            int tileY = (int)y / Map.COLLISION_TILE_SIZE;
            // Pareil pour la largeur et hauteur
            int tileXW = (int)(x + width) / Map.COLLISION_TILE_SIZE;
            int tileYH = (int)(y + height) / Map.COLLISION_TILE_SIZE;

            // On check pour tout les tiles à l'intérieur de cette zone si collision
            for (int j = tileY; j <= tileYH; j++)
            {
                for (int i = tileX; i <= tileXW; i++)
                {
                    // Verif 
                    if (j >= MapCollider.MapColliders.GetLength(0) || i >= MapCollider.MapColliders.GetLength(1))
                    { continue; }
                    if (MapCollider.MapColliders[j, i] == 1 || MapCollider.MapColliders[j, i] == 2)
                    {
                        if (MapCollider.MapColliders[j, i] == 2)
                            IsGrounded = true;
                        collide = true;
                    }
                }
            }
            if (!collide)
                IsGrounded = false;
            return collide;
        }
    }
}
