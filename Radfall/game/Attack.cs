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
    internal class Attack(double x, double y, Image img, int damage, Being attacker, EntityManager entityManager, double knockbackX, double knockbackY,
        double invincibletime, double inactiveDuration, double activeDuration, double stunTime,double cooldownTime, double deplacementX, double deplacementY) : Entity(x, y, img, entityManager)
    {
        private int Damage { get; init; } = damage;
        public Being Attacker { get; init; } = attacker;
        private double KnockbackX { get; init; } = knockbackX;
        private double KnockbackY { get; init; } = knockbackY;
        private double InvincibleTime { get; init; } = invincibletime;
        private double InactiveDuration { get; init; } = inactiveDuration;
        private double ActiveDuration { get; init; } = activeDuration;
        private double StunTime { get; init; } = stunTime;
        private double CooldownTime { get; init; } = cooldownTime;
        private bool InCooldown { get; set; } = false;
        public bool IsActive { get; set; } = false;
        public double DeplacementX { get; init; } = deplacementX;
        public double DeplacementY { get; init; } = deplacementY;
        private bool IsFacingLeft { get; set; } = false;

        public void Init(double x, double y, bool isFacingLeft)
        {
            IsSolid = false;
            IsFacingLeft = isFacingLeft;
            x = x + (Attacker.width / 2); // Place l'origine de l'attaque au milieu de l'attaquant
            if (IsFacingLeft)
            {
                x = x - img.Width; // Déplace l'origine à gauche si l'attaquant regarde à gauche
            }
            if (!InCooldown)
            {
                this.x = x; this.y = y;
                StartAttackTimers();
                entityManager.Add(this);
                AttackMovement();
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
        private void AttackMovement()
        {
            Attacker.VelocityY = -DeplacementY;
            Attacker.VelocityX = DeplacementX;
        }

        public override void Update(double dTime)
        {
            UpdateHitbox();
        }
        public void DoAttack(Being target)
        {
            if (IsFacingLeft)
                target.TakeDamage(Damage, Attacker, x + img.Width, KnockbackX, KnockbackY, InvincibleTime, StunTime);
            else
                target.TakeDamage(Damage, Attacker, x, KnockbackX, KnockbackY, InvincibleTime, StunTime);
        }
    }
}
