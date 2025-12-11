using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Radfall
{
    internal class Player : Entity
    {
        public int MaxPoison {  get; set; }
        public int Poison { get; set; }
        public int Accoutumance { get; set; }

        public Player(double x, double y, Image img, int id = 0, string name = "Player") : base(x, y, img, id, name)
        {
            GravityScale = 10;
            IsFlying = false;
            IsGrounded = false;
        }
        public void Move(bool left)
        {
            if (!IsStunned)
            {
                if (left)
                    VelocityX = 1000;
                else
                    VelocityX = -1000;
            }
        }
        public void Jump()
        {
            if (IsGrounded)
                VelocityY = -1000;
        }
    }
}
