using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Radfall
{
    class Monster : Entity
    {
        private Entity Target { set; get; }
        public int AttackDamage { get; set; }
        private double directionX, directionY;
        public Monster(double x, double y, Image img, int id, string name, Entity target, int attackDamage) : base(x, y, img, id, name)
        {
            Target = target;
            Speed = 300;
            AttackDamage = attackDamage;
        }
        public override void Update(double dTime)
        {
            Move();
            base.Update(dTime);
        }
        public void Move()
        {
            directionX = Target.x - x;
            directionY = Target.y - y;

            // Normalisation de la direction
            double length = Math.Sqrt(directionX * directionX + directionY * directionY);
            directionX /= length;
            directionY /= length;

            VelocityX = directionX * Speed;
            VelocityY = directionY * Speed;
        }
    }
}
