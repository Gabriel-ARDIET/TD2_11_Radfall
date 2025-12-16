using Radfall.game;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Radfall
{
    internal class Attack : Entity
    {
        private int Damage { get; init; }
        public Being Attacker { get; init; }
        private double KnockbackX { get; init; }
        private double KnockbackY { get; init; }
        private double InvincibleTime { get; init; }
        private double InactiveDuration { get; init; }
        private double ActiveDuration { get; init; }
        private double StunTime { get; init; }
        private double CooldownTime { get; init; }
        private bool InCooldown { get; set; } = false;
        public bool IsActive { get; set; } = false;
        public Attack(double x, double y, Image img, EntityManager entityManager, int damage, Being attacker, double knockbackX, double knockbackY,
            double invincibleTime, double inactiveDuration, double activeDuration,double stunTime, double cooldownTime) : base(x, y, img, entityManager)
        {
            Damage = damage;
            Attacker = attacker;
            KnockbackX = knockbackX;
            KnockbackY = knockbackY;
            InvincibleTime = invincibleTime;
            InactiveDuration = inactiveDuration;
            ActiveDuration = activeDuration;
            StunTime = stunTime;
            CooldownTime = cooldownTime;
            IsSolid = false;
            this.x = 0;
            this.y = 0;
            entityManager.Remove(this);
        }

        public void Init(double x, double y)
        {
            if (!InCooldown)
            {
                this.x = x; this.y = y;
                StartAttackTimers();
                entityManager.Add(this);
            }
        }

        private void StartAttackTimers()
        {
            InCooldown = true;
            TimeManager.AddTimer(InactiveDuration, () => 
            {
                IsActive = true;
                TimeManager.AddTimer(ActiveDuration, () =>
                {
                    IsActive = false;
                    Attacker.currentAttack = null;
                    entityManager.Remove(this);
                });
            });
            TimeManager.AddTimer(CooldownTime, () =>
            {
                InCooldown = false;
            });
        }

        public override void Update(double dTime)
        {
            if (Attacker.IsFacingLeft)
                x = Attacker.x - img.Width; // Déplace l'origine à gauche si l'attaquant regarde à gauche
            else
                x = Attacker.x;
            y = Attacker.y;
            x += (Attacker.width / 2); // Place l'origine de l'attaque au milieu de l'attaquant
            UpdateHitbox();
        }
        public void DoAttack(Being target)
        {
            if (Attacker.IsFacingLeft)
                target.TakeDamage(Damage, Attacker, x + img.Width, KnockbackX, KnockbackY, InvincibleTime, StunTime);
            else
                target.TakeDamage(Damage, Attacker, x, KnockbackX, KnockbackY, InvincibleTime, StunTime);
        }
    }
}
