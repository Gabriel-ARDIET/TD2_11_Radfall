using Radfall.game;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Radfall
{
    class Monster : Being
    {
        private Entity Target { set; get; }
        public int AttackDamage { get; set; }
        private double directionX, directionY;
        public Monster(double x, double y, Image img, EntityManager manager, int maxHealth, double speed, double jumpForce,
           bool isFlying, Entity target, int attackDamage) : base(x, y, img, manager, maxHealth,speed,jumpForce,isFlying)
        {
            entityManager = manager;
            MaxHealth = maxHealth;
            Health = MaxHealth;
            Speed = speed;
            JumpForce = jumpForce;
            IsFlying = isFlying;
            Target = target;
            AttackDamage = attackDamage;
            VelocityX = 0;
            VelocityY = 0;
        }
        public override void Update(double dTime)
        {
            base.Update(dTime);
            Move();
        }
        public void Move()
        {
            if (IsFlying)
            {
                directionX = Target.x - x;
                directionY = Target.y - y;

                // Normalisation de la direction
                double length = Math.Sqrt(directionX * directionX + directionY * directionY);
                directionX /= length;
                directionY /= length;

                if (!IsStunned)
                {
                    x += Speed * directionX * TimeManager.DeltaTime;
                    y += Speed * directionY * TimeManager.DeltaTime;
                }
            }
            else
            {
                directionX = Math.Sign(Target.x - x);
                x += Speed * directionX * TimeManager.DeltaTime;
            }
        }
    }
}
