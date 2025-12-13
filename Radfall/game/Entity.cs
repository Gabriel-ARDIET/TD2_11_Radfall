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

namespace Radfall
{
    internal class Entity : Drawable
    {
        public const double GRAVITY = 30000;

        public int Id { get; init; }
        public string Name { get; init; }
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public double Speed { get; set; }
        public double JumpForce { get; set; }
        public double VelocityX { get; set; }
        public double VelocityY { get; set; }
        public double AccelerationX { get; set; }
        public double AccelerationY {  get; set; } 
        public double oldPosX { get; set; }
        public double oldPosY { get; set; }
        public bool IsFlying { get; set; }
        public bool IsVisible { get; set; }
        public bool IsGrounded { get; set; }
        public bool IsInvicible { get; set; }
        public bool IsSolid { get; set; }
        public bool IsStunned { get; set; }
        public Rect Hitbox { get; set; }
        public AnimationController Animation {  get; set; }

        public Entity(double x, double y, Image img, int id, string name)
        : base(x, y, img)
        {
            Id = id;
            Name = name;
            Hitbox = new Rect(x, y, img.Width, img.Height);
            Animation = new AnimationController(img);
            oldPosX = x;
            oldPosY = y;
        }
        public virtual void Update(double dTime) // virtual permet de rendre la méthode personnalisable pour les enfants qui peuvent donc la réécrire avec override
        {
            ApplyGravity(dTime);
            //UpdatePhysic(dTime);
            UpdateHitbox();
            Animation.Update();
        }
        public void InitializeRenderer(Canvas canvas, int zIndex = 1)
        {
            if (!canvas.Children.Contains(img))
            {
                canvas.Children.Add(img);
                Canvas.SetZIndex(img, zIndex);
            }
        }
        private void UpdateHitbox()
        {
            Hitbox = new Rect(x, y, img.Width, img.Height);
        }

        private void ApplyGravity(double dTime)
        {
            if (!IsFlying)
            {
                VelocityY += 50;
                AccelerationY += GRAVITY * dTime;
            }
        }

        private void UpdatePhysic(double dTime)
        {
            oldPosX = x;
            oldPosY = y;
            // On integre l'acceleration 
            // De meme pour la vitesse
            // Pour trouver la nouvelle position
            VelocityX += AccelerationX * dTime;
            VelocityY += AccelerationY * dTime;
            x += VelocityX * dTime;
            y += VelocityY * dTime;

            // Reset l'acceleration
            AccelerationX = 0;
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
                    if (MapCollider.MapColliders[j, i] > 0)
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

        public void TakeDamage(int damage, Entity attacker, double attackX, double knockback, double invicibilityTime)
        {
            if (IsInvicible) return;

            Health -= damage;
            Health = Math.Max(Health, 0);

            double direction = Math.Sign(x - attackX);
            VelocityX += knockback * direction;
            VelocityY -= knockback / 2;

            if (Health > 0)
            {
                StartInvincibility(invicibilityTime);
            }
            else
            {
                //Die();
            }
        }

        private void StartInvincibility(double invicibilityTime)
        {
            IsInvicible = true;
            Timer timer = new Timer(invicibilityTime, () => { IsInvicible = false; });
        }
    }
}
