using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Radfall.game
{
    internal class Bat : Monster
    {
        public Bat(double x, double y, Image img, EntityManager entityManager, int maxHealth,
            double speed, double jumpForce, bool isFlying, Entity target, int attackDamage)
            : base(x, y, img, entityManager, maxHealth, speed, jumpForce, isFlying, target, attackDamage)
        {
            
        }
        public override void Update(double dTime)
        {
            base.Update(dTime);
            Move();
        }

        public void Move()
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
    }
}
