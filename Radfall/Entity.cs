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

namespace Radfall
{
    internal class Entity : Drawable
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public double Speed { get; set; }
        public double GravityScale { get; set; }
        public double JumpForce { get; set; }
        public double VelocityX { get; set; }
        public double VelocityY { get; set; }
        public bool IsFlying { get; set; }
        public bool IsVisible { get; set; }
        public bool IsGrounded { get; set; }
        public bool IsInvicible { get; set; }
        public bool IsSolid { get; set; }
        public Rect Hitbox { get; set; }

        public Entity(double x, double y, Image img, int id, string name)
        : base(x, y, img)
        {
            Id = id;
            Name = name;
            Hitbox = new Rect(x, y, img.Width, img.Height);
        }
        public void Update(double dTime)
        {
            ApplyVelocity(dTime);
            ApplyGravity(dTime);
            UpdateHitbox();
            //CheckCollisions();
        }

        private void UpdateHitbox()
        {
            Hitbox = new Rect(x,y,img.Width, img.Height);
        }

        private void ApplyGravity(double dTime)
        {
            if (!IsFlying)
                VelocityY += GravityScale * dTime;
        }

        private void ApplyVelocity(double dTime)
        {
            x += VelocityX * dTime;
            y += VelocityY * dTime;
        }
    }
}
