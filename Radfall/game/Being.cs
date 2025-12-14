using Radfall.map;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Radfall.game
{
    internal class Being : Entity
    {
        public EntityManager entityManager;
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public double Speed { get; set; }
        public double JumpForce { get; set; }
        public bool IsFlying { get; set; }
        public bool IsInvicible { get; set; }
        public bool IsStunned { get; set; }
        public Attack ?currentAttack { get; set; }

        public Being(double x, double y, Image img, EntityManager manager, int maxHealth, double speed, double jumpForce,
            bool isFlying = false) : base(x, y, img)
        {
            entityManager = manager;
            MaxHealth = maxHealth;
            Health = maxHealth;
            JumpForce = jumpForce;
            IsFlying = isFlying;
        }

        public override void Update(double dTime)
        {
            base.Update(dTime);
            ApplyGravity(dTime);
        }
        private void ApplyGravity(double dTime)
        {
            if (!IsFlying || IsStunned)
            {
                VelocityY += 50;
                AccelerationY += GRAVITY * dTime;
            }
        }

        public void TakeDamage(int damage, Entity attacker, double attackX, double knockbackX, double knockbackY, double invicibilityTime, double stunTime)
        {
            if (IsInvicible) return;

            Health -= damage;
            Health = Math.Max(Health, 0);

            double direction = Math.Sign(x - attackX);
            VelocityX += knockbackX * direction;
            VelocityY -= knockbackY;

            StartInvincibility(invicibilityTime);
            StartStunTime(stunTime);

            if (Health <= 0)
            {
                //Die();
            }
            Debug.WriteLine(Health);
        }

        private void StartStunTime(double stunTime)
        {
            IsStunned = true;
            // Flicker du sprite si possible
            TimeManager.AddTimer(stunTime, () => { IsStunned = false; });
        }

        private void StartInvincibility(double invicibilityTime)
        {
            IsInvicible = true;
            TimeManager.AddTimer(invicibilityTime, () => { IsInvicible = false; });
        }
    }
}
