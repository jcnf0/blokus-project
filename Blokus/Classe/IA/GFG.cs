using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace Blokus
{
    public static class GFG
    {
        public static int rotation_joueur(int j)
        {
            int rj = j;
            if (j == 2)
            {
                rj = 4;
            }
            else if (j == 4)
            {
                rj = 3;
            }
            else if (j == 3)
            {
                rj = 1;
            }
            else
            {
                rj += 1;
            }
            if (j == 5)
            {
                rj = 1;
            }
            return rj;
        }

        public static Tuple<double, Coup> Minmax(int depth, Plateau board, bool isMax, int h, Coup meilleurcoupsauvegarde, int joueur_actuel, int joueurPermanent)
        {
            if (depth == 0)
            {
                //return new Tuple<double, Coup>(FE.Naif(joueur_actuel, board.pieces_j1, board.pieces_j2, board.pieces_j3, board.pieces_j4), meilleurcoupsauvegarde);
                int eval = board.coupPossible(joueur_actuel, board.plateau).Count;
                Console.WriteLine(eval);
                return new Tuple<double, Coup>(eval, meilleurcoupsauvegarde);
            }
            if (isMax)
            {
                double best = -1000000;
                Coup meilleurcoup = new Coup(new Piece(Pieces.pieces[0], Color.White, 0), Vector2.Zero, true);
                List<Coup> coups = board.coupPossible(joueur_actuel, board.plateau);
                foreach (Coup coup in coups)
                {
                    board.jouerCoup(coup);
                    Tuple<double, Coup> temp = Minmax(depth - 1, board, false, h, meilleurcoup, rotation_joueur(joueur_actuel), joueurPermanent);
                    board.annulerCoup(joueur_actuel, coup);
                    if (temp.Item1 > best)
                    {
                        best = temp.Item1;
                        meilleurcoup = new Coup(board.copyPiece(coup.piece), coup.position);
                    }
                }
                return new Tuple<double, Coup>(best, meilleurcoup);
            }
            else
            {
                double best = 1000000;
                Coup meilleurcoup = new Coup(new Piece(Pieces.pieces[0], Color.White, 0), Vector2.Zero, true);
                List<Coup> coups = board.coupPossible(joueur_actuel, board.plateau);
                foreach (Coup coup in coups)
                {
                    board.jouerCoup(coup);
                    Tuple<double, Coup> temp = Minmax(depth - 1, board, true, h, meilleurcoup, rotation_joueur(joueur_actuel), joueurPermanent);
                    board.annulerCoup(joueur_actuel, coup);
                    if (temp.Item1 < best)
                    {
                        best = temp.Item1;
                        meilleurcoup = new Coup(board.copyPiece(coup.piece), coup.position);
                    }
                }
                return new Tuple<double, Coup>(best, meilleurcoup);
            }
        }

        // public static Tuple<double, Coup> Minmax(int depth, Plateau board, bool isMax, int h, Coup meilleurcoupsauvegarde, int joueur_actuel, int joueurPermanent)
        // {
        //     List<Coup> coupPossibles = board.coupPossible(joueur_actuel, board.plateau);
        //     if (depth == h || coupPossibles.Count == 0)
        //     {
        //         double rendu = FE.Naif(joueurPermanent, board.pieces_j1, board.pieces_j2, board.pieces_j3, board.pieces_j4);
        //         Console.WriteLine(rendu);
        //         return Tuple.Create(rendu, meilleurcoupsauvegarde);
        //     }

        //     if (depth == 0)
        //     {
        //         double val = -10000.0;
        //         Coup meilleurcoup = new Coup(new Piece(Pieces.pieces[0], Color.White, 1), Vector2.Zero, true);
        //         foreach (Coup newcoup in coupPossibles)
        //         {
        //             Console.WriteLine(depth);
        //             Tuple<double, Coup> couppossible = Minmax(depth + 1, board.ajouter(newcoup), false, h, newcoup, board.joueur_actuel, joueurPermanent);
        //             if (val < couppossible.Item1)
        //             {
        //                 val = couppossible.Item1;
        //                 meilleurcoup = newcoup;
        //             }
        //         }
        //         return Tuple.Create(val, meilleurcoup);
        //     }
        //     else
        //     {
        //         if (isMax)
        //         {
        //             double val = -10000.0;

        //             foreach (Coup newcoup in coupPossibles)
        //             { val = Math.Max(Minmax(depth + 1, board.ajouter(newcoup), false, h, meilleurcoupsauvegarde, rotation_joueur(board.joueur_actuel), joueurPermanent).Item1, val); }
        //             return Tuple.Create(val, meilleurcoupsauvegarde);
        //         }
        //         else
        //         {
        //             double val = 10000.0;
        //             foreach (Coup newcoup in coupPossibles)
        //             { val = Math.Min(Minmax(depth + 1, board.ajouter(newcoup), true, h, meilleurcoupsauvegarde, rotation_joueur(board.joueur_actuel), joueurPermanent).Item1, val); }
        //             return Tuple.Create(val, meilleurcoupsauvegarde);
        //         }
        //     }
        // }
    }
}
