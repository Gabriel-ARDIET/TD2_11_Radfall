using System;
using System.Collections.Generic;
using System.Collections.Generic;
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