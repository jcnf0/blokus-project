using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blokus
{
    public class Animation
    {
        public string tag;
        public float deltaTime;
        public float timer;
        public int avancement;
        public int avancementStart;
        public int ligne;
        public int colone;
        public bool isPlaying;
        public Vector2 size;
        public Rectangle rectangle;
        public Texture2D sprite;
        public bool finished;
        public Animation(string tg, float between, int li, int co, int start, Vector2 siz, Texture2D sprt, bool customSize = false)
        {
            rectangle = new Rectangle();
            tag = tg;
            deltaTime = between;
            timer = 0;
            avancement = start;
            avancementStart = start;
            ligne = li;
            colone = co;
            size = siz;
            sprite = sprt;
            finished = false;
            if (customSize)
                size = new Vector2(sprite.Width / ligne, sprite.Height / colone);
        }

        public void Update(GameTime gameTime)
        {
            if (isPlaying)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (timer >= deltaTime)
                {
                    avancement++;
                    timer = 0;
                }
            }
            else
            {
                avancement = avancementStart;
                timer = 0;
            }
            if (avancement == ligne)
            {
                avancement = avancementStart;
                finished = true;
            }
            rectangle = new Rectangle(avancement * Convert.ToInt32(size.X), (colone - 1) * Convert.ToInt32(size.Y), Convert.ToInt32(size.X), Convert.ToInt32(size.Y));
        }
    }
}
