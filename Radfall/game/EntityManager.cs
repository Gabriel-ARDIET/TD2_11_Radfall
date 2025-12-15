using Radfall.game;
using Radfall.map;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Radfall
{
    internal class EntityManager
    {
        private List<Entity> entities = new List<Entity>();
        public IReadOnlyList<Entity> Entities => entities;
        private Canvas canvas;
        public EntityManager(Canvas canvas)
        {
            this.canvas = canvas;
        }

        public void Add(Entity entity)
        {
            entities.Add(entity);
            entity.InitializeRenderer(canvas);
        }

        public void Remove(Entity entity)
        {
            entities.Remove(entity);
            if (canvas.Children.Contains(entity.img))
                canvas.Children.Remove(entity.img);
        }

        public void UpdateAll(double dTime)
        {
            foreach (Entity entity in entities)
            {
                entity.Update(dTime);
            }

            CheckCollisions();
        }

        public void RenderAll(Renderer renderer)
        {
            foreach (Entity entity in entities)
            {
                if (entity.IsVisible)
                {
                    entity.img.Opacity = 100;
                    renderer.Draw(entity);
                }
                else entity.img.Opacity = 0;
            }
        }

        private void CheckCollisions()
        {
            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].IsSolid)
                {
                    // On distingue les 2 axes pour pouvoir gérer les collisions facilement

                    // Pour chaque axe on :
                    // Verifie si à l'instant d'après y'a collision
                    // Si Collision on ajoute une force

                    // En x
                    entities[i].UpdatePhysicX();

                    if (entities[i].CollideWithMap())
                    {
                        entities[i].x = entities[i].oldPosX;
                        entities[i].VelocityX = 0;
                    }

                    entities[i].oldPosX = entities[i].x;

                    // En y
                    entities[i].UpdatePhysicY();

                    if (entities[i].CollideWithMap())
                    {
                        entities[i].y = entities[i].oldPosY;
                        entities[i].VelocityY = 0;
                    }

                    entities[i].oldPosY = entities[i].y;
                }

                // Collision between entity
                for (int j = i + 1; j < entities.Count; j++)
                {
                    var e1 = entities[i];
                    var e2 = entities[j];

                    if (e1.Hitbox.IntersectsWith(e2.Hitbox))
                    {
                        if (e1 is Monster monster0 && e2 is Player player0)
                        {
                            DoAttack(player0,monster0);
                        }
                        else if (e2 is Monster monster1 && e1 is Player player1)
                        {
                            DoAttack(player1, monster1);
                        }
                        if (e1 is Attack attack0 && e2 is Being being0)
                        {
                            if (attack0.IsActive && attack0.Attacker != being0)
                                attack0.DoAttack(being0);
                        }
                        else if (e2 is Attack attack1 && e1 is Being being1)
                        {
                            if (attack1.IsActive && attack1.Attacker != being1)
                                attack1.DoAttack(being1);
                        }
                        if (e1 is Item item0 && e2 is Player player2)
                        {
                            //item0.Grabbed(player2);
                        }
                        else if (e2 is Item item1 && e1 is Player player3)
                        {
                            //item1.Grabbed(player3);
                        }
                        if (e1 is Poison poison0 && e2 is Player player4)
                        {
                            //Méthode à faire pour remplacer CheckEntities() dans Poison
                        }
                        else if (e2 is Poison poison1 && e1 is Player player5)
                        {
                            //Méthode à faire pour remplacer CheckEntities() dans Poison
                        }
                        if (e1 is Item healPlant && e2 is Player player3)
                        {
                            healPlant.IsGrabbed(player3);
                        }
                        else if (e2 is Item healPlant1 && e1 is Player player4)
                        {
                            healPlant1.IsGrabbed(player4);
                        }
                    }
                }
            }
        }
        private void DoAttack(Player player, Monster monster)
        {
            player.TakeDamage(monster.AttackDamage, monster, monster.x, 300,500, 1, 0.5);
        }
    }
}