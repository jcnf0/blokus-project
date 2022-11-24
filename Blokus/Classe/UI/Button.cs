using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blokus
{
    public class Button
    {
        public string effet;
        public Vector2 position;
        public Texture2D image;
        public Texture2D imageTXT;
        public Vector2 origin;
        public float size;
        public float sizeBase;
        public float sizeAnim;
        public bool isFlipped;
        public bool isSoundPlayed;
        public Text texte;
        public int joueur;
        public Button(Vector2 pos, Texture2D img, Texture2D imgTXT, string effect, float sz, float szAnim, string txt = "", float sizetxt = 1, int _joueur = 0)
        {
            joueur = _joueur;
            texte = new Text(sizetxt, pos + new Vector2(0, 5), txt, Color.Black, Color.Transparent, 25000);
            isSoundPlayed = false;
            position = pos;
            effet = effect;
            image = img;
            imageTXT = imgTXT;
            size = sz;
            sizeBase = sz;
            sizeAnim = szAnim;
            origin = new Vector2(image.Bounds.Center.X, image.Bounds.Center.Y);
            isFlipped = false;

        }
        private void ApplyEffect()
        {
            int player = 0;
            switch (effet)
            {
                case "quitselection":
                    Game1.gameState = GameState.menu;
                    break;
                case "tuto":
                    Game1.Instance.isTutorial = true;
                    break;
                case "quit":
                    if (Game1.Instance.isTutorial)
                    {
                        Game1.Instance.isTutorial = false;
                    }
                    else
                        Game1.Instance.quitGame();
                    break;
                case "play":
                    Game1.Instance.resetSelection();
                    Game1.gameState = GameState.selection;
                    break;
                case "playSelection":
                    Game1.gameState = GameState.play;
                    break;
                case "skip":
                    Game1.Instance.skip_turn();
                    break;
                case "rejouer":
                    Game1.Instance.ResetGame();
                    Game1.gameState = GameState.menu;
                    break;
                case "J1":
                    player = 0;
                    if (texte.text == "joueur")
                    {
                        texte.text = "IA facile";
                        Game1.Instance.plateau.WhatAI[player] = 0;
                        Game1.Instance.plateau.isAI[player] = true;
                    }
                    else if (texte.text == "IA facile")
                    {
                        texte.text = "IA intermediaire";
                        Game1.Instance.plateau.WhatAI[player] = 1;
                        Game1.Instance.plateau.isAI[player] = true;
                    }
                    else if (texte.text == "IA intermediaire")
                    {
                        texte.text = "IA difficile";
                        Game1.Instance.plateau.WhatAI[player] = 2;
                        Game1.Instance.plateau.isAI[player] = true;
                    }
                    else
                    {
                        texte.text = "joueur";
                        Game1.Instance.plateau.isAI[player] = false;
                    }
                    break;
                case "J2":
                    player = 1;
                    if (texte.text == "joueur")
                    {
                        texte.text = "IA facile";
                        Game1.Instance.plateau.WhatAI[player] = 0;
                        Game1.Instance.plateau.isAI[player] = true;
                    }
                    else if (texte.text == "IA facile")
                    {
                        texte.text = "IA intermediaire";
                        Game1.Instance.plateau.WhatAI[player] = 1;
                        Game1.Instance.plateau.isAI[player] = true;
                    }
                    else if (texte.text == "IA intermediaire")
                    {
                        texte.text = "IA difficile";
                        Game1.Instance.plateau.WhatAI[player] = 2;
                        Game1.Instance.plateau.isAI[player] = true;
                    }
                    else
                    {
                        texte.text = "joueur";
                        Game1.Instance.plateau.isAI[player] = false;
                    }
                    break;
                case "J3":
                    player = 3;
                    if (texte.text == "joueur")
                    {
                        texte.text = "IA facile";
                        Game1.Instance.plateau.WhatAI[player] = 0;
                        Game1.Instance.plateau.isAI[player] = true;
                    }
                    else if (texte.text == "IA facile")
                    {
                        texte.text = "IA intermediaire";
                        Game1.Instance.plateau.WhatAI[player] = 1;
                        Game1.Instance.plateau.isAI[player] = true;
                    }
                    else if (texte.text == "IA intermediaire")
                    {
                        texte.text = "IA difficile";
                        Game1.Instance.plateau.WhatAI[player] = 2;
                        Game1.Instance.plateau.isAI[player] = true;
                    }
                    else
                    {
                        texte.text = "joueur";
                        Game1.Instance.plateau.isAI[player] = false;
                    }
                    break;
                case "J4":
                    player = 2;
                    if (texte.text == "joueur")
                    {
                        texte.text = "IA facile";
                        Game1.Instance.plateau.WhatAI[player] = 0;
                        Game1.Instance.plateau.isAI[player] = true;
                    }
                    else if (texte.text == "IA facile")
                    {
                        texte.text = "IA intermediaire";
                        Game1.Instance.plateau.WhatAI[player] = 1;
                        Game1.Instance.plateau.isAI[player] = true;
                    }
                    else if (texte.text == "IA intermediaire")
                    {
                        texte.text = "IA difficile";
                        Game1.Instance.plateau.WhatAI[player] = 2;
                        Game1.Instance.plateau.isAI[player] = true;
                    }
                    else
                    {
                        texte.text = "joueur";
                        Game1.Instance.plateau.isAI[player] = false;
                    }
                    break;
            }
        }

        public void Update(GameTime gameTime, bool TrueScreenSize = false)
        {
            var Mstate = Mouse.GetState();
            Vector2 mousePosition = new Vector2(Mstate.X, Mstate.Y);
            if (!TrueScreenSize)
                if (MathOperation.Collision(position /*+ (Game1.TrueScreenSize - Game1.ScreenSize) / 2*/, mousePosition, origin.X, origin.Y))
                {
                    if (!isSoundPlayed)
                    {
                        isSoundPlayed = true;
                    }
                    size += 0.05f;
                    if (Mstate.LeftButton == ButtonState.Pressed && Game1.isClicked == false)
                    {
                        ApplyEffect();
                        Game1.isClicked = true;
                    }
                }
                else
                {
                    size -= 0.05f;
                    isSoundPlayed = false;
                }
            else if (MathOperation.Collision(position, mousePosition, origin.X, origin.Y))
            {
                if (!isSoundPlayed)
                {
                    isSoundPlayed = true;
                }
                size += 0.05f;
                if (Mstate.LeftButton == ButtonState.Pressed && Game1.isClicked == false)
                {
                    ApplyEffect();
                    Game1.isClicked = true;
                }
            }
            else
            {
                size -= 0.05f;
                isSoundPlayed = false;
            }
            size = MathHelper.Clamp(size, sizeBase, sizeAnim);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Color couleur = Color.Black;
            switch (joueur)
            {
                case 1:
                    couleur = Color.Green;
                    break;
                case 2:
                    couleur = Color.Blue;
                    break;
                case 3:
                    couleur = Color.Red;
                    break;
                case 4:
                    couleur = Color.Yellow;
                    break;
            }
            if (isFlipped)
            {
                spriteBatch.Draw(image, position, null, Color.White, (float)Math.PI, origin, size, 0, 0);
            }
            else
            {
                spriteBatch.Draw(image, position, null, Color.White, 0, origin, size, 0, 0);
            }
            if (imageTXT != null)
            {
                spriteBatch.Draw(imageTXT, position, null, Color.White, 0, new Vector2(imageTXT.Bounds.Center.X, imageTXT.Bounds.Center.Y), sizeBase, 0, 0);
            }
            else
            {
                texte.couleurInterieur = couleur;
                texte.Draw(spriteBatch);
            }
        }
    }
}