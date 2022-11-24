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
    public static class Pieces
    {
        public static List<int[,]> pieces; // Listes des pièces
        public static void Initialise()
        /*
         * Initialise les pièces
         */
        {
            pieces = new List<int[,]>();
            pieces.Add(new int[5, 5]
            {
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,1,0,0},
                {0,0,0,0,0},
                {0,0,0,0,0}
            });
            pieces.Add(new int[5, 5]
           {
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,1,1,0},
                {0,0,0,0,0},
                {0,0,0,0,0}
           });
            pieces.Add(new int[5, 5]
           {
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,1,1,0},
                {0,0,0,1,0},
                {0,0,0,0,0}
           });
            pieces.Add(new int[5, 5]
           {
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,1,1,1,0},
                {0,0,0,0,0},
                {0,0,0,0,0}
           });
            pieces.Add(new int[5, 5]
           {
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,1,1,0},
                {0,0,1,1,0},
                {0,0,0,0,0}
           });
            pieces.Add(new int[5, 5]
           {
                {0,0,0,0,0},
                {0,0,1,0,0},
                {0,1,1,1,0},
                {0,0,0,0,0},
                {0,0,0,0,0}
           });
            pieces.Add(new int[5, 5]
           {
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,1,1,1,1},
                {0,0,0,0,0},
                {0,0,0,0,0}
           });
            pieces.Add(new int[5, 5]
           {
                {0,0,0,0,0},
                {0,0,0,1,0},
                {0,1,1,1,0},
                {0,0,0,0,0},
                {0,0,0,0,0}
           });
            pieces.Add(new int[5, 5]
           {
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,1,1,0},
                {0,1,1,0,0},
                {0,0,0,0,0}
           });
            pieces.Add(new int[5, 5]
           {
                {0,0,0,0,0},
                {1,0,0,0,0},
                {1,1,1,1,0},
                {0,0,0,0,0},
                {0,0,0,0,0}
           });
            pieces.Add(new int[5, 5]
           {
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,1,0,0},
                {0,0,1,0,0},
                {0,1,1,1,0}
           });
            pieces.Add(new int[5, 5]
           {
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,1,0,0},
                {0,0,1,0,0},
                {0,0,1,1,1}
           });
            pieces.Add(new int[5, 5]
           {
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,1,1,1,0},
                {1,1,0,0,0},
                {0,0,0,0,0}
           });
            pieces.Add(new int[5, 5]
           {
                {0,0,0,0,0},
                {0,0,0,1,0},
                {0,1,1,1,0},
                {0,1,0,0,0},
                {0,0,0,0,0}
           });
            pieces.Add(new int[5, 5]
           {
                {0,0,1,0,0},
                {0,0,1,0,0},
                {0,0,1,0,0},
                {0,0,1,0,0},
                {0,0,1,0,0}
           });
            pieces.Add(new int[5, 5]
       {
                {0,0,0,0,0},
                {0,1,0,0,0},
                {0,1,1,0,0},
                {0,1,1,0,0},
                {0,0,0,0,0}
       });
            pieces.Add(new int[5, 5]
       {
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,1,1,0},
                {0,1,1,0,0},
                {0,1,0,0,0}
       });
            pieces.Add(new int[5, 5]
       {
                {0,0,0,0,0},
                {0,1,1,0,0},
                {0,1,0,0,0},
                {0,1,1,0,0},
                {0,0,0,0,0}
       });
            pieces.Add(new int[5, 5]
       {
                {0,0,0,0,0},
                {0,0,1,1,0},
                {0,1,1,0,0},
                {0,0,1,0,0},
                {0,0,0,0,0}
       });
            pieces.Add(new int[5, 5]
       {
                {0,0,0,0,0},
                {0,0,1,0,0},
                {0,1,1,1,0},
                {0,0,1,0,0},
                {0,0,0,0,0}
       });
            pieces.Add(new int[5, 5]
       {
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,1,0,0},
                {0,1,1,1,1}
       });
        }
    }
}
