using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blokus
{
    public class SoundEffectList
    {
        public List<SoundEffectInstance> List;
        public int max;
        public SoundEffect sound;
        public SoundEffectList(SoundEffect _sound, int _max)
        {
            max = _max;
            sound = _sound;
            List = new List<SoundEffectInstance>();
        }
        public void Add()
        {
            List = new List<SoundEffectInstance>(max);

            for (int i = 0; i < max; i++)
            {
                List.Add(sound.CreateInstance());
            }
        }

        public void Play(float volume, float pitch, float pan)
        {

            ClampSoundValues(ref volume, ref pitch, ref pan);

            for (int i = 0; i < List.Count; i++)
            {
                if (List[i].State == SoundState.Stopped)
                {
                    List[i].Volume = volume / (i + 1);
                    List[i].Pitch = pitch;
                    List[i].Pan = pan;
                    List[i].Play();
                    return;
                }

            }

            return;
        }

        private void ClampSoundValues(ref float volume, ref float pitch, ref float pan)
        {
            volume = MathHelper.Clamp(volume, -1f, 1f);
            pitch = MathHelper.Clamp(pitch, -1f, 1f);
            pan = MathHelper.Clamp(pan, -1f, 1f);
        }
    }
}
