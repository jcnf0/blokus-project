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
    public class Coup
    {
        // La matrice de la pièce
        public Piece piece;
        // La position
        public Vector2 position;
        // Si le coup est un coup à jouer
        public bool estNul;

        public Coup(Piece _piece, Vector2 _position, bool _estNul = false)
        /*
         * Constructeur de la classe Coup
         */
        {
            piece = _piece;
            position = _position;
            estNul = _estNul;
        }
    }
}
