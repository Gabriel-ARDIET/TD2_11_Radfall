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
        public bool IsFacingLeft { get; set; } = false;
        private Attack baseAttack;
        private Attack dash;
        public Player(double x, double y, Image img, EntityManager entityManager, int maxHealth, double speed, double jumpForce,bool isFlying)
            : base(x, y, img, entityManager, maxHealth, speed, jumpForce, isFlying)
        {
            MaxHealth = maxHealth;
            Health = MaxHealth;
            Speed = speed;
            JumpForce = jumpForce;
            IsFlying = isFlying;
            baseAttack = new Attack(x, y, RessourceManager.LoadImage("Attack.png"), 10, this, entityManager, 300, 500, 1, 0, 0.5, 0.5, 1, 0, 0);
            dash = new Attack(x,y, RessourceManager.LoadImage("Attack.png"), 0,this,entityManager,0,0,0,0,0,0,2,1000,0);
            Animation.Add(
                    animationName: "Idle",
                    pathImg: "BlueWizard/2BlueWizardIdle/Chara - BlueIdle",
                    nbFrame: 20,
                    animationSpeed: 0.2
            );
            Animation.Add(
                    animationName: "Walk",
                    pathImg: "BlueWizard/2BlueWizardWalk/Chara_BlueWalk",
                    nbFrame: 20,
                    animationSpeed: 0.2
            );

            Animation.SetCurrent("Idle");
        }

        public void MoveLeft()
        {
            if (!IsStunned)
            {
                x -= Speed * TimeManager.DeltaTime;
                IsFacingLeft = true;
                Animation.SetCurrent("Walk");
            }
        }

        public void MoveRight()
        {
            if (!IsStunned)
            {
                x += Speed * TimeManager.DeltaTime;
                IsFacingLeft = false;
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
                currentAttack = dash;
                currentAttack.Init(x,y,IsFacingLeft);
                TimeManager.AddTimer(0.2, () =>
                {
                    VelocityX = 0;
                    VelocityY = 0;
                });
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
        internal override void Die()
        {
            Debug.WriteLine("Mort mskn");
        }
    }
}
