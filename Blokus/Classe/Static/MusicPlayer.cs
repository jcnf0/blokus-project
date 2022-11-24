using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blokus
{
    public static class MusicPlayer
    {
        public static float baseBaseVolume = 0.4f;
        public static float baseVolume = baseBaseVolume;
        public static float volume = 0;
        private static Song currentSong;
        private static string typeSong;
        public static bool isChanging = false;
        private static List<Song> listMenu = new List<Song>();
        private static List<Song> listPlaying = new List<Song>();
        private static List<Song> listBoss = new List<Song>();
        public static void SetList()
        {
        }
        public static void Play()
        {
            volume = MathHelper.Clamp(volume, 0, baseVolume);
            setSound(volume);
            if (isChanging)
            {
                volume -= 0.025f;
                volume = MathHelper.Clamp(volume, 0, baseVolume);
                if (volume <= 0.05f)
                {
                    isChanging = false;
                    MediaPlayer.Stop();
                }
            }
            else
            {
                volume += 0.025f;
                volume = MathHelper.Clamp(volume, 0, baseVolume);
            }
            if (MediaPlayer.State == MediaState.Stopped)
            {
                currentSong = ChooseRandomSong(typeSong);
                MediaPlayer.Play(currentSong);
            }
        }
        public static void setSound(float _volume)
        {
            //baseVolume = _volume;
            MediaPlayer.Volume = _volume;
        }
        public static Song ChooseRandomSong(string type)
        {
            Song retour;
            switch (typeSong)
            {
                case "play":
                    retour = listPlaying[Game1.aleatoire.Next(listPlaying.Count)];
                    break;
                case "menu":
                    retour = listPlaying[Game1.aleatoire.Next(listPlaying.Count)];
                    break;
                case "boss":
                    retour = listBoss[Game1.aleatoire.Next(listBoss.Count)];
                    break;
                default:
                    retour = listPlaying[Game1.aleatoire.Next(listPlaying.Count)];
                    break;
            }
            return retour;
        }
        public static void ChangeMusic(string type)
        {
            typeSong = type;
            isChanging = true;
        }
    }
}
