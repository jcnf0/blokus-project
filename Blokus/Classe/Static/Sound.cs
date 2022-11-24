using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blokus
{
    public static class Sound
    {
        public static float VolumeLevel = 0.5f;
        //public static SoundEffect sleepNose { get; private set; }
        //public static SoundEffectInstance sleepNoseInstance { get; private set; }
        //public static Song musiqueBoss { get; private set; }
        public static void Load(ContentManager Content)
        {
            //sleepNose = Content.Load<SoundEffect>("Son/Effect/sleepNose");
            //sleepNoseInstance = sleepNose.CreateInstance();
            //musiqueBody = Content.Load<Song>("Son/Musique/A New Way to Die ");

            SetVolume();
        }
        public static void SetVolume()
        {
            MusicPlayer.baseVolume = MusicPlayer.baseBaseVolume * VolumeLevel;
        }
    }
}
