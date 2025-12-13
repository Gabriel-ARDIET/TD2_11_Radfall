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
            foreach (var entity in entities)
            {
                entity.Update(dTime);
            }

            CheckCollisions();
        }
        public void RenderAll(Renderer renderer)
        {
            foreach (var entity in entities)
            {
                renderer.Draw(entity);
            }
        }

        private void CheckCollisions()
        {
            for (int i = 0; i < entities.Count; i++)
            {
                // On distingue les 2 axes pour pouvoir gérer les collisions facilement

                // Pour chaque axe on :
                // Verifie si à l'instant d'après y'a collision
                // Si Collision on ajoute une force

                // En x
                entities[i].x += entities[i].VelocityX * TimeManager.DeltaTime;
                entities[i].VelocityX += entities[i].AccelerationX * TimeManager.DeltaTime;
                entities[i].AccelerationX = 0;

                if (entities[i].CollideWithMap())
                {
                    entities[i].x = entities[i].oldPosX;
                    entities[i].VelocityX = 0;
                }

                entities[i].oldPosX = entities[i].x;


                // En y
                entities[i].y += entities[i].VelocityY * TimeManager.DeltaTime;
                entities[i].VelocityY += entities[i].AccelerationY * TimeManager.DeltaTime;
                entities[i].AccelerationY = 0;

                if (entities[i].CollideWithMap())
                {
                    entities[i].y = entities[i].oldPosY;
                    entities[i].VelocityY = 0;
                }

                entities[i].oldPosY = entities[i].y;

                // Collision between entity
                for (int j = i + 1; j < entities.Count; j++)
                {
                    var e1 = entities[i];
                    var e2 = entities[j];

                    if (e1.Hitbox.IntersectsWith(e2.Hitbox))
                    {
                        if (e1 is Monster m && e2 is Player p)
                        {
                            p.TakeDamage(m.AttackDamage, m, m.x, 3, 0.5);
                        }
                        else if (e2 is Monster m2 && e1 is Player p2)
                        {
                            p2.TakeDamage(m2.AttackDamage, m2, m2.x, 3, 0.5);
                        }
                    }
                }
            }
        }
    }
}