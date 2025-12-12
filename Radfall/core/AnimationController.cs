using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radfall.core
{
    // C'est pas un manager mais un controller pour chaque entity que l'on sqouhaite
    internal class AnimationController
    {
        public Animation CurrentAnimation {  get; set; }

        public List<Animation> animations {  get; set; }

        public AnimationController() { }

        public void SetAnimation(Animation animation)
        {
            // On vérifie que l'animation existe et est unique d'abord
            uint exist = 0;
            for (int i = 0; i < animations.Count; i++)
            {
                if (animations[i] == animation)
                    exist++;
            }

            // Afficher les erreurs
            if (exist == 0)
            {
                Debug.WriteLine("Erreur : L'animation n'existe pas");
            }
            else if (exist > 1)
            {
                Debug.WriteLine("Erreur : Il y a plusieurs copies de cette animation");
            }

            // Mettre toutes les animations en inactive sauf celle qu'on veut
            else
            {
                for (int i = 0; i < animations.Count; i++)
                {
                    if (animations[i] == animation)
                    {
                        animations[i].Active();
                    }
                    else
                    {
                        animations[i].Inactive();
                    }
                }
            }
        }
    }
}
