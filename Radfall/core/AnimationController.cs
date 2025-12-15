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
    /// <summary>
    /// Tool to manage easely animations.
    /// </summary>
    internal class AnimationController
    {
        private Dictionary<string, Animation> animations = new Dictionary<string, Animation>();

        private Image imgSource;

        private double chrono;

        private int currentStep; // Of the current animation

        public Animation CurrentAnimation {  get; set; }

        /// <param name="imgSource">Image that you want to change when the animation happens</param>
        public AnimationController(Image imgSource) 
        {
            this.imgSource = imgSource;
            chrono = 0;
            currentStep = 0;
        }

        /// <summary>
        /// Change the current animation
        /// </summary>
        public void SetCurrent(string animationName)
        {
            // Check if the image exist before set it to current
            if (animations.ContainsKey(animationName))
            {
                CurrentAnimation = animations[animationName];
            }
        }

        /// <summary>
        /// Add an animation
        /// </summary>
        /// <param name="animationName">It's the key that you will need to use for SetCurrent()</param>
        /// <param name="pathImg">Check the animation class for more info</param>
        /// <param name="animationSpeed">In second</param>
        public void Add(string animationName, string pathImg, uint nbFrame, double animationSpeed)
        {
            // Check if an animation with the same key already exist
            if (!animations.ContainsKey(animationName))
            { 
                Animation animation = new Animation(pathImg, nbFrame, animationSpeed);
                animations.Add(animationName, animation);
            }
        }

        /// <summary>
        /// You need to call this function every frame
        /// </summary>
        public void Update()
        {
            // Check if there is a current animation
            // Because if not, there will be an error later
            if (CurrentAnimation != null)
            {
                // Update the chrono
                chrono += TimeManager.DeltaTime;

                // Change the frame 
                if (chrono >= CurrentAnimation.FrameInterval)
                {
                 
                    chrono = 0;
                    currentStep++;

                    // Restart the loop
                    if (currentStep == CurrentAnimation.NbImgs)
                    {
                        currentStep = 0;
                    }
                    imgSource.Source = CurrentAnimation.Imgs[currentStep];
                }
            }
        }
    }

///////////////////////////////////////////////
// EXEMPLE
///////////////////////////////////////////////
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
