using Radfall.game;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Radfall
{
    internal class Player : Being
    {
        public int MaxPoison {  get; set; }
        public int Poison { get; set; }
        public int Accoutumance { get; set; }
        private Attack baseAttack;
        public Player(double x, double y, Image img, EntityManager entityManager, int maxHealth, double speed, double jumpForce,bool isFlying)
            : base(x, y, img, entityManager, maxHealth, speed, jumpForce, isFlying)
        {
            MaxHealth = maxHealth;
            Health = MaxHealth;
            Speed = speed;
            JumpForce = jumpForce;
            IsFlying = isFlying;
            baseAttack = new Attack(x, y, RessourceManager.LoadImage("Attack.png"), 10, this, entityManager, 300, 500, 1, 0, 0.5, 0.5, 1, 0, 0);
        }

        public void MoveLeft()
        {
            if (!IsStunned)
            {
                x -= Speed * TimeManager.DeltaTime;
            }
        }

        public void MoveRight()
        {
            if (!IsStunned)
            {
                x += Speed * TimeManager.DeltaTime;
            }
        }

        public void Jump()
        {
            if (IsGrounded && !IsStunned)
            {
                VelocityY = -JumpForce;
            }
        }

        public void BaseAttack()
        {
            if (!IsStunned)
            {
                currentAttack = baseAttack;
                currentAttack.Init(x,y);
            }
        }
        public override void Update(double dTime)
        {
            if (currentAttack != null)
            {
                currentAttack.Update(dTime);
            }
            base.Update(dTime);
        }

        internal void TakePoison(int damage)
        {
            Poison = Math.Min(Poison + damage, MaxPoison);
        }

        public void Purify(int purifyAmount)
        {
            Poison -= purifyAmount;
            if (Poison < 0)
            {
                Poison = 0;
            }
        }
    }
}
