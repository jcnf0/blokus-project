using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blokus
{
    public class AnimationManager
    {
        public List<Animation> animation;
        public float timerTransition = 0;
        public AnimationManager()
        {
            animation = new List<Animation>();
        }
        public void Update(GameTime gameTime)
        {
            foreach (var anim in animation)
            {
                anim.Update(gameTime);
            }
        }
        public void Play(string tag)
        {
            foreach (var anim in animation)
            {
                if (anim.tag == tag)
                {
                    anim.isPlaying = true;
                }
                else
                {
                    anim.isPlaying = false;
                }
            }
        }

        public void ADDAnimation(string tg, float between, int li, int co, int start, Vector2 siz, Texture2D sprt, bool sizeFit = false)
        {
            animation.Add(new Animation(tg, between, li, co, start, siz, sprt, sizeFit));
        }

        public Rectangle RectangleAnimation(string tag)
        {
            Rectangle retour = new Rectangle();
            foreach (var anim in animation)
            {
                if (anim.tag == tag)
                {
                    retour = anim.rectangle;
                }
            }
            return retour;
        }

        public Vector2 OriginAnimation(string tag)
        {
            Vector2 retour = new Vector2();
            foreach (var anim in animation)
            {
                if (anim.tag == tag)
                {
                    retour = anim.size / 2;
                }
            }
            return retour;
        }

        public Texture2D SpriteAnimation(string tag)
        {
            Texture2D sprite = Game1.placeHolder;
            foreach (var anim in animation)
            {
                if (anim.tag == tag)
                {
                    sprite = anim.sprite;
                }
            }
            return sprite;
        }
    }
}
