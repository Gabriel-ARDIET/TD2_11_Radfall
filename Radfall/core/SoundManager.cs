using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Media;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Radfall.core
{
    internal class SoundManager
    {
        public static void Play(string path)
        {
            
        }

        //SoundPlayer player = new SoundPlayer(path);
        //player.Load();
        //player.Play();

        private static Dictionary<string, MediaPlayer> musics = new Dictionary<string, MediaPlayer>();

        public static string SoundRepository { get; set; } = "";

        public static void Update()
        {
            foreach (var player in musics.Values)
            {
                //if (player.MediaEnded == true)
                //    player.Play();
            }


            //bool soundFinished = true;

            //if (soundFinished)
            //{
            //    soundFinished = false;
            //    Task.Factory.StartNew(() => { player.PlaySync(); soundFinished = true; });
            //}
        }

        public static void LoadMusic(string path)
        {
            var uri = new Uri(SoundRepository + path, UriKind.RelativeOrAbsolute);
            var player = new MediaPlayer();
            player.Open(uri);
            musics.Add(SoundRepository + path, player);
        }

        /// <summary>
        /// Note that you need to load a music before playing it.
        /// It loop the music automaticely
        /// </summary>
        public static void PlayMusic(string path)
        {
            if (musics.ContainsKey(path))
            {
                musics[path].Play();
            }
            else if (musics.ContainsKey(SoundRepository + path))
            {
                musics[SoundRepository + path].Play();
            }
        }


        /// <summary>
        /// Technichely you can play a sound by any size, 
        /// but it's not efficient.
        /// Prefer using short audio with this function
        /// </summary>
        public static void PlaySound(string path)
        {
            SoundPlayer player = new SoundPlayer(SoundRepository + path);
            player.Load();
            player.Play();
        }

    }
}
