using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Radfall.core
{
    // C'est pas un manager mais un controller pour chaque entity que l'on sqouhaite
    internal class AnimationController
    {
        private Dictionary<string, Animation> animations = new Dictionary<string, Animation>();

        private Image imgSource;

        private double chrono;

        private int currentStep;
        public Animation CurrentAnimation {  get; set; }

        public AnimationController(Image imgSource) 
        {
            this.imgSource = imgSource;
            chrono = 0;
            currentStep = 0;
        }

        public void SetCurrent(string animationName)
        {
            // On vérifie que l'animation existe
            bool exist = false;
            foreach (var animation in animations)
            {
                if (animationName == animation.Key)
                {
                    exist = true;
                    break;
                }
            }
            if (!exist)
            {
                Debug.WriteLine("Erreur : L'animation n'existe pas");
            }

            // Mettre l'animation voulue
            CurrentAnimation = animations[animationName];
        }

        public void Add(string animationName, string pathImg, uint nbFrame, double animationSpeed)
        {
            // Check si l'anim existe déja ou pas
            if (animations.ContainsKey(animationName))
            {
                    Debug.WriteLine("Erreur : l'animation existe déja");
            }
            else 
            {
                Animation animation = new Animation(pathImg, nbFrame, animationSpeed);
                animations.Add(animationName, animation);
            }
        }

        public void Update()
        {
            if (CurrentAnimation != null)
            {
                chrono += TimeManager.DeltaTime;
                if (chrono >= CurrentAnimation.FrameInterval)
                {
                    chrono = 0;
                    currentStep++;

                    if (currentStep == CurrentAnimation.NbImgs)
                    {
                        currentStep = 0;
                    }
                    imgSource.Source = CurrentAnimation.Imgs[currentStep];
                }
            }
        }
    }

    /////// Exemple utilisation ////////
    /*
     
    class Player : Drawable
    {
        AnimationController Animation { get; set; }

        public Player()
        {
            Animation = new AnimationController(this.img); // Car Hérite de Drawable
        }

        public void Update()
        {
            animation.Update();
        }

        public void MoveLeft()
        {
            animation.SetCurrent("moveLeft");
        }
    }
    
    player.Animation.Add(
                         animationName : "moveLeft",
                         pathImg : "animation/moveLeft",
                         nbFrame : 4,
                         animationSpeed : 0.5
    );

    player.Animation.Add(
                         animationName : "moveRight",
                         pathImg : "animation/moveRight",
                         nbFrame : 4,
                         animationSpeed : 0.5
    );

    */
}
