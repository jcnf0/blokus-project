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
    public class Piece
    {
        // La matrice de la pièce
        public int[,] piece;
        // La couleur
        public Color couleur;
        // La taille de la pièce
        private float size;
        // La position
        private Vector2 position;
        // Si la pièce doit suivre la souris
        public bool dragged;
        // L'espacement pour un meilleur affichage
        public int espacement;
        // L'identifiant de la pièce
        public int ID;
        // Le nombre de points de la pièce (la somme des carrés composant la pièce)
        public int points;

        public Piece(int[,] p, Color _couleur, int _id)
        /*
        * Constructeur de la classe Piece
        */
        {
            points = 0;
            ID = _id;
            espacement = 10;
            position = new Vector2();
            couleur = _couleur;
            piece = p;
            size = 0.5f;
            dragged = false;

            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    points += piece[j, i];
                }
        }

        public void Update(GameTime gameTime, Func<Piece, int> selection, Func<Piece, int> deselection, Piece piece_selec)
        /*
        * Met à jour la pièce
        */
        {
            // On récupère la position de la souris
            var Mstate = Mouse.GetState();
            Vector2 Mpos = new Vector2(Mstate.X, Mstate.Y);
            // Si la souris est sur la pièce
            if (Mpos.X >= position.X && Mpos.X <= position.X + 5 * 11 && Mpos.Y >= position.Y && Mpos.Y <= position.Y + 5 * 11 && !dragged)
            {
                // On grossit la pièce
                size = 0.7f;
                // Si on clique sur la pièce
                if (Mstate.LeftButton == ButtonState.Pressed && !Game1.isClicked)
                {
                    // On indique que la souris à sélectionnée une pièce
                    Game1.isClicked = true;
                    // On copie la pièce pour la faire suivre la souris
                    Piece np = new Piece(piece, couleur, ID);
                    // On augmente la taille de la pièce pour qu'elle rentre dans le plateau
                    np.espacement = 20;
                    np.size = 1;
                    // On sélectionne la pièce
                    if (piece_selec != null)
                    {
                        deselection(piece_selec);
                    }

                    selection(np);
                    dragged = true;
                }
            }
            // Sinon, si la pièce ne doit pas suivre la souris, on la redimensionne normalement
            else
            {
                if (!dragged)
                {
                    size = 0.5f;
                }
            }


        }

        public void Draw(SpriteBatch spriteBatch, Vector2 pos, bool gray = false)
        /*
         * Affiche la pièce
         */
        {
            position = pos;
            // Si la pièce doit suivre la souris, on ne l'affiche pas ici
            if (!dragged)
                // Pour chaque carré de la pièce
                for (int x = 0; x < 5; x++)
                {
                    for (int y = 0; y < 5; y++)
                    {
                        // On calcule la position du carré
                        Vector2 p = new Vector2(position.X + x * (espacement + 1), position.Y + y * (espacement + 1));
                        // Si ce carré est dans la pièce (donc vaut 1)
                        if (piece[y, x] != 0)
                        {
                            // On affiche le carré
                            if (!gray)
                                spriteBatch.Draw(Art.piece, p, null, couleur, 0, new Vector2(0, 0), size, 0, 0);
                            else
                                spriteBatch.Draw(Art.piece, p, null, couleur * 0.5f, 0, new Vector2(0, 0), size, 0, 0);
                        }
                    }
                }
        }

        public void rotation() {
            /*
             * Fait une rotation de la pièce
             */
            int[,] new_piece = new int[5, 5];
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    new_piece[j, 4 - i] = piece[i, j];
                }
            piece = new_piece;
        }

        public void flip() {
            /*
             * Fait une symétrie horizontale de la pièce
             */
            int[,] new_piece = new int[5, 5];
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    new_piece[4 - i, j] = piece[i, j];
                }
            piece = new_piece;
        }
    }
}
