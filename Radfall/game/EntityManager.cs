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
            int index = 0;
            foreach (Entity entity in entities)
            {
                index++;
                entity.Update(dTime);

                // Update des positions et check des collisions
                if (entity.IsSolid)
                {
                    // On distingue les 2 axes pour pouvoir gérer les collisions facilement
                    // En x
                    entity.UpdatePhysicX();

                    if (entity.CollideWithMap())
                    {
                        entity.x = entity.oldPosX;
                        entity.VelocityX = 0;
                    }

                    entity.oldPosX = entity.x;

                    // En y
                    entity.UpdatePhysicY();

                    if (entity.CollideWithMap())
                    {
                        entity.y = entity.oldPosY;
                        entity.VelocityY = 0;
                    }

                    entity.oldPosY = entity.y;
                }

                CheckCollisionsBetweenEntities(entity,index);
            }
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

        private void CheckCollisionsBetweenEntities(Entity e1,int i)
        {
            // Collision between entity
            for (int j = i + 1; j < entities.Count; j++)
            {
                var e2 = entities[j];

                if (e1.Hitbox.IntersectsWith(e2.Hitbox))
                {
                    switch (e1, e2)
                    {
                        case (Monster m, Player p):
                            m.CollisionAttack(p);
                            break;
                        case (Player p, Monster m):
                            m.CollisionAttack(p);
                            break;

                        case (Attack a, Being b) when a.IsActive && a.Attacker != b:
                            a.DoAttack(b);
                            break;
                        case (Being b, Attack a) when a.IsActive && a.Attacker != b:
                            a.DoAttack(b);
                            break;

                        case (Item it, Player p):
                            it.IsGrabbed(p);
                            break;
                        case (Player p, Item it):
                            it.IsGrabbed(p);
                            break;

                        case (Player p, Poison po):
                            po.InflictPoison(p);
                            break;
                        case (Poison po, Player p):
                            po.InflictPoison(p);
                            break;
                }
            }
        }

        private void DoAttack(Player player, Monster monster)
        {
            player.TakeDamage(monster.AttackDamage, monster, monster.x, 300,500, 1, 0.5);
        }
    }
}