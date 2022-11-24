using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blokus
{
    public static class FE
    {
        public static double Naif(int id_joueur, List<Piece> pj1, List<Piece> pj2, List<Piece> pj3, List<Piece> pj4)
        {
            List<double> poids = new List<double>() { 2, 3, 4, 3.75, 4.67, 5, 4.67, 5, 5, 5.89, 6, 6, 5.89, 6, 5.56, 5.67, 6, 5.67, 6, 6, 5.89 };
            double somme = 0;
            List<int[,]> pj1_piece = new List<int[,]>();
            foreach (Piece item in pj1)
            {
                pj1_piece.Add(item.piece);
            }
            List<int[,]> pj2_piece = new List<int[,]>();
            foreach (Piece item in pj2)
            {
                pj2_piece.Add(item.piece);
            }
            List<int[,]> pj3_piece = new List<int[,]>();
            foreach (Piece item in pj3)
            {
                pj3_piece.Add(item.piece);
            }
            List<int[,]> pj4_piece = new List<int[,]>();
            foreach (Piece item in pj4)
            {
                pj1_piece.Add(item.piece);
            }
            List<int[,]> pj1_eff = new List<int[,]>();
            List<int[,]> pj2_eff = new List<int[,]>();
            List<int[,]> pj3_eff = new List<int[,]>();
            List<int[,]> pj4_eff = new List<int[,]>();
            foreach (int[,] item in Pieces.pieces)
            {
                if (!pj1_piece.Contains(item))
                {
                    pj1_eff.Add(item);
                }
                if (!pj2_piece.Contains(item))
                {
                    pj2_eff.Add(item);
                }
                if (!pj3_piece.Contains(item))
                {
                    pj3_eff.Add(item);
                }
                if (!pj4_piece.Contains(item))
                {
                    pj4_eff.Add(item);
                }
            }



            for (int i = 0; i < pj1_eff.Count; i++)
            {
                int forme_ind = Pieces.pieces.IndexOf(pj1_eff[i]);
                somme += poids[forme_ind] * Math.Pow(-1, id_joueur + 1);

            }
            for (int i = 0; i < pj2_eff.Count; i++)
            {
                int forme_ind = Pieces.pieces.IndexOf(pj2_eff[i]);
                somme += poids[forme_ind] * Math.Pow(-1, id_joueur);
            }
            for (int i = 0; i < pj3_eff.Count; i++)
            {
                int forme_ind = Pieces.pieces.IndexOf(pj3_eff[i]);
                somme += poids[forme_ind] * Math.Pow(-1, id_joueur + 1);
            }
            for (int i = 0; i < pj4_eff.Count; i++)
            {
                int forme_ind = Pieces.pieces.IndexOf(pj4_eff[i]);
                somme += poids[forme_ind] * Math.Pow(-1, id_joueur);
            }
            Console.WriteLine((float)somme);
            return (float)somme;
        }
    }
}