using Radfall.game;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipes;
using System.Linq;
using System.Security.Policy;
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
        private Dash dash;

        private bool NoClip = false;
        public Player(double x, double y, Image img, EntityManager entityManager, int maxHealth, double speed, double jumpForce,bool isFlying)
            : base(x, y, img, entityManager, maxHealth, speed, jumpForce, isFlying)
        {
            MaxHealth = maxHealth;
            Health = MaxHealth;
            Speed = speed;
            JumpForce = jumpForce;
            IsFlying = isFlying;
            baseAttack = new Attack(0, 0, RessourceManager.LoadImage("Attack.png"), entityManager, 10, this, 300, 500, 1, 0, 0.5, 0.5, 1);
            dash = new Dash(this, 0.2, 1.5, 750, 0);
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
                currentAttack = baseAttack;
                currentAttack.Init(x,y);
            }
        }
        public void Dash()
        {
            if (!IsStunned)
                dash.DoDash();
        }
        public override void Update(double dTime)
        {
            if (currentAttack != null)
            {
                currentAttack.Update(dTime);
            }
            base.Update(dTime);
            if (NoClip)
            {
                IsFlying = true;
                IsInvicible = true;
                IsSolid = false;
            }
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

        internal void ActivateNoClip()
        {
            NoClip = !NoClip;
            Speed = 3 * BaseSpeed;
            if (!NoClip)
            {
                IsFlying = false;
                IsInvicible = false;
                IsSolid = true;
                Speed = BaseSpeed;
            }
        }
    }
}
