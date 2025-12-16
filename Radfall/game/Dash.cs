using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radfall.game
{
    internal class Dash
    {
        private Being User { get; init; }
        private double ActiveDuration { get; init; }
        private double CooldownTime { get; init; }
        private bool InCooldown { get; set; } = false;
        public double DeplacementX { get; init; }
        public double DeplacementY { get; init; }
        public Dash(Being user, double activeDuration, double cooldownTime, double deplacementX, double deplacementY) 
        {
            User = user;
            ActiveDuration = activeDuration;
            CooldownTime = cooldownTime;
            DeplacementX = deplacementX;
            DeplacementY = deplacementY;
        }
        public void DoDash()
        {
            if (!InCooldown)
            {
                StartDash();
                StartDashTimer();
            }
        }
        private void StartDash()
        {
            InCooldown = true;
            User.IsFlying = true;
            User.IsInvicible = true;
            if (User.IsFacingLeft)
                User.VelocityX = -DeplacementX;
            else
                User.VelocityX = DeplacementX;
            User.VelocityY = -DeplacementY;
        }
        private void StartDashTimer()
        {
            TimeManager.AddTimer(ActiveDuration, () =>
            {
                User.IsFlying = false;
                User.IsInvicible = false;
                User.VelocityX = 0;
                User.VelocityY = 0;
            });
            TimeManager.AddTimer(CooldownTime, () =>
            {
                InCooldown = false;
            });
        }
    }
}
