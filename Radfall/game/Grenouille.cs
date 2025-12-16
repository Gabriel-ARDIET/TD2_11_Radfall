using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Radfall.game
{
    internal class Grenouille : Monster
    {
        private const double JUMP_INTERVAL = 3;
        double timer = 0;
        public Grenouille(double x, double y, Image img, EntityManager entityManager, int maxHealth,
            double speed, double jumpForce, bool isFlying, Entity target, int attackDamage)
            : base(x, y, img, entityManager, maxHealth, speed, jumpForce, isFlying, target, attackDamage)
        {

        }
        public override void Update(double dTime)
        {
            timer += dTime;
            base.Update(dTime);
            if (timer >= JUMP_INTERVAL && IsGrounded && !IsStunned)
            {
                timer = 0;
                Jump();
            }
        }

        private void Jump()
        {
            if (x - Target.x >= 0)
            {
                IsFacingLeft = true;
                VelocityX = -Speed;
            }
            else
            {
                IsFacingLeft = false;
                VelocityX = Speed;
            }
            VelocityY = -JumpForce;
        }
    }
}
