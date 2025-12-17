using Radfall.game;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Radfall
{
    internal abstract class Monster : Being
    {
        public Entity Target { set; get; }
        public int AttackDamage { get; set; }
        public double directionX, directionY;
        public Monster(double x, double y, Image img, EntityManager entityManager, int maxHealth, double speed, double jumpForce,
           bool isFlying, Entity target, int attackDamage) : base(x, y, img, entityManager, maxHealth,speed,jumpForce,isFlying)
        {
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
        }
        public void CollisionAttack(Being target)
        {
            target.TakeDamage(AttackDamage, this, x, 600, 600, 1, 0.5);
        }
    }
}
