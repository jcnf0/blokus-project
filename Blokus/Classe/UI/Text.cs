using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blokus
{
    public class Text
    {
        public float size;
        public Vector2 position;
        public string text;
        public Color couleurInterieur;
        public Color couleurExterieur;
        private List<string> listChar;
        private float timerLife;
        public float lifeTime;
        public float opacite;
        private Vector2 tailleChar;
        public float rotation;
        public bool isExpired;
        public Text(float _size, Vector2 _position, string _text, Color _colInt, Color _colExt, float _lifeTime)
        {
            rotation = 0;
            isExpired = false;
            opacite = 1;
            lifeTime = _lifeTime;
            timerLife = 0;
            size = _size;
            position = _position;
            text = _text;
            tailleChar = new Vector2(60, 40);
            listChar = new List<string>();
            listChar = text.Split().ToList();
            couleurInterieur = _colInt;
            couleurExterieur = _colExt;
            //if (size >= 3)
            //    position -= new Vector2(listChar.Count * (tailleChar.X * 0.85f) * size, tailleChar.Y * size) / 2;
            //else
            //    position -= new Vector2(listChar.Count * (tailleChar.X * 1.1f) * size, tailleChar.Y * size) / 2;
        }

        public void Update(GameTime gameTime)
        {
            opacite *= 1.2f;
            opacite = MathHelper.Clamp(opacite, 0, 1);
            timerLife += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timerLife >= lifeTime)
            {
                opacite *= 0.7f;
                if (opacite < 0.05f)
                    isExpired = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //for (int i = 0; i < listChar.Count; i++)
            //{
            //    spriteBatch.DrawString(Font.police, listChar[i], position + (new Vector2(i * tailleChar.X, tailleChar.Y) - new Vector2(5, 3)) * size, couleurExterieur * opacite, 0, Vector2.Zero, size * Font.Size * 1.125f, 0, 0);
            //    spriteBatch.DrawString(Font.police, listChar[i], position + new Vector2(i * tailleChar.X, tailleChar.Y) * size, couleurInterieur * opacite, 0, Vector2.Zero, size * Font.Size, 0, 0);
            //}
            spriteBatch.DrawString(Font.police, text, position + new Vector2(3, 3) * size, couleurExterieur*opacite, rotation, Font.police.MeasureString(text) / 2, size * Font.Size, 0, 0);
            spriteBatch.DrawString(Font.police, text, position, couleurInterieur*opacite, rotation, Font.police.MeasureString(text) / 2, size * Font.Size, 0, 0);
        }
    }
}
