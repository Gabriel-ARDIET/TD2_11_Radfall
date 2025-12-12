using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Radfall
{
    internal class Attack : Drawable
    {
        public int Damage { get; init; }
        public Entity Attacker { get; init; }
        public double Knockback { get; init; }
        public double InvincibleTime { get; init; }
        public double InactiveDuration { get; init; }
        public double ActiveDuration { get; init; }
        public double StunTime { get; init; }
        public bool IsActive { get; set; }
        public Rect Hitbox { get; set; }
        double timer = 0;
        public Attack(double x, double y, Image img, int damage, Entity attacker, double knockback, 
            double invincibletime,double inactiveDuration, double activeDuration, double stunTime) : base(x, y, img)
        {
            Damage = damage;
            Attacker = attacker;
            Knockback = knockback;
            InvincibleTime = invincibletime;
            InactiveDuration = inactiveDuration;
            ActiveDuration = activeDuration;
            StunTime = stunTime;
            IsActive = false;
            Hitbox = new Rect(x, y, img.Width, img.Height);
        }
        public void Update(double dTime)
        {
            timer += dTime;
            if (timer >= InactiveDuration)
            {
                IsActive = true;
                timer = 0;
            }
            else if (timer >= ActiveDuration)
            {
                IsActive = false;
                timer = 0;
            }
        }
    }
}
