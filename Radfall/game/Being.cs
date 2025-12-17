using Radfall.map;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Radfall.game
{
    internal abstract class Being : Entity
    {
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public double Speed { get; set; }
        public double BaseSpeed { get; set; }
        public double JumpForce { get; set; }
        public bool IsFlying { get; set; }
        public bool IsInvicible { get; set; }
        public bool IsStunned { get; set; }
        public Attack ?currentAttack { get; set; }
        public bool IsFacingLeft { get; set; } = false;

        public Being(double x, double y, Image img, EntityManager entityManager, int maxHealth, double speed, double jumpForce,
            bool isFlying = false) : base(x, y, img, entityManager)
        {
            MaxHealth = maxHealth;
            Health = maxHealth;
            JumpForce = jumpForce;
            IsFlying = isFlying;
            BaseSpeed = speed;
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
                if (VelocityY < 750)
                {
                    VelocityY += 10;
                    AccelerationY += GRAVITY * dTime;
                }
            }
        }

        public void TakeDamage(int damage, Entity attacker, double attackX, double knockbackX, double knockbackY, double invicibilityTime,
            double stunTime)
        {
            if (IsInvicible) return;

            Health -= damage;
            Health = Math.Max(Health, 0);

            TakeKnockback(attackX, knockbackX, knockbackY);
            StartInvincibility(invicibilityTime);
            StartStunTime(stunTime);

            if (Health <= 0)
            {
                Die();
            }
        }

        internal virtual void Die()
        {
            entityManager.Remove(this);
            // Donner de l'accoutumance etc...
        }

        private void TakeKnockback(double attackX, double knockbackX, double knockbackY)
        {
            double direction = Math.Sign(x - attackX);
            VelocityX = knockbackX * direction;
            VelocityY = -knockbackY;
            TimeManager.AddTimer(0.3, () =>
            {
                if (Math.Abs(VelocityX) > 0)
                    VelocityX -= knockbackX * direction;
                if (Math.Abs(VelocityY) > 0)
                    VelocityY += knockbackY;
            });
        }

        private void StartStunTime(double stunTime)
        {
            IsStunned = true;
            //Flicker
            TimeManager.AddTimer(stunTime, () => { IsStunned = false; });
        }

        private void StartInvincibility(double invicibilityTime)
        {
            IsInvicible = true;
            img.Opacity = 0.7;
            TimeManager.AddTimer(invicibilityTime, () => { IsInvicible = false;
                img.Opacity = 1;
            });
        }

        public void Heal(int healAmount)
        {
            Health += healAmount;
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
        }
        public abstract Being Clone(double x, double y);
    }
}
