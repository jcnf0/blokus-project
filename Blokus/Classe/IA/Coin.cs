using System;
using System.Collections.Generic;
using System.Linq;

namespace Blokus
{
    public static class Coin
    {
        public static void Main2(string[] args)
        {
            int[,] P = new int[20, 20]
            {
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            };
            //Liste des coins du joueurs 1 :


            List<Tuple<int, int>> list_j1 = TousLesCoins(P, 1);
            Console.WriteLine("le joueur 1 a");
            Console.WriteLine(list_j1.Count);
            for (int i = 0; i < list_j1.Count; i++)
            {
                Console.WriteLine(list_j1[i]);
            }
            //liste des coins du joueurs 2 :
            List<Tuple<int, int>> list_j2 = TousLesCoins(P, 2);
            Console.WriteLine("le joueur 2 a");
            Console.WriteLine(list_j2.Count);
            for (int i = 0; i < list_j2.Count; i++)
            {
                Console.WriteLine(list_j2[i]);
            }

            if (list_j1.Count > list_j2.Count)
            {
                Console.WriteLine("le joueur 1 a le plus de coins");
            }
            else
            {
                Console.WriteLine("le joueur 2 a le plus de coins");
            }

        }
        public static List<Tuple<int, int>> IsUnCoin(int i, int j, int[,] plateau)
        {
            int s1;
            int s2;
            int s3;
            int s4;
            var res = new List<Tuple<int, int>> { };
            //cas limite sur les coins
            if (i == 0 && j == 0)//coin en haut à gauche
            {
                s3 = plateau[i, j + 1] + plateau[i + 1, j + 1] + plateau[i + 1, j];
                if (s3 == 0)/*coin en bas à droite*/
                {
                    res.Add(Tuple.Create(i + 1, j + 1));
                }
                return res;
            }

            if (i == 0 && j == 19)//coin en haut à droite
            {
                s2 = plateau[i, j - 1] + plateau[i + 1, j - 1] + plateau[i + 1, j];
                if (s2 == 0)/*coin en bas à gauche*/
                {
                    res.Add(Tuple.Create(i + 1, j - 1));
                }
                return res;
            }

            if (i == 19 && j == 0)//coin en bas à gauche
            {
                s4 = plateau[i - 1, j] + plateau[i - 1, j + 1] + plateau[i, j + 1];
                if (s4 == 0)/*coin en haut à droite*/
                {
                    res.Add(Tuple.Create(i - 1, j + 1));
                }
                return res;
            }

            if (i == 19 && j == 19)//coin en bas à droite
            {
                s1 = plateau[i - 1, j - 1] + plateau[i - 1, j] + plateau[i, j - 1];
                if (s1 == 0)/*coin en haut à gauche*/
                {
                    res.Add(Tuple.Create(i - 1, j - 1));
                }
                return res;
            }

            //cas limite sur les bords
            if (i == 0)//cas limite où on est sur le bord en haut
            {
                s2 = plateau[i, j - 1] + plateau[i + 1, j - 1] + plateau[i + 1, j];
                s3 = plateau[i, j + 1] + plateau[i + 1, j + 1] + plateau[i + 1, j];
                if (s2 == 0)/*coin en bas à gauche*/
                {
                    res.Add(Tuple.Create(i + 1, j - 1));
                }
                if (s3 == 0)/*coin en bas à droite*/
                {
                    res.Add(Tuple.Create(i + 1, j + 1));
                }
                return res;
            }

            if (i == 19)//cas limite où on est sur le bord en bas
            {
                s1 = plateau[i - 1, j - 1] + plateau[i - 1, j] + plateau[i, j - 1];
                s4 = plateau[i - 1, j] + plateau[i - 1, j + 1] + plateau[i, j + 1];
                if (s1 == 0)/*coin en haut à gauche*/
                {
                    res.Add(Tuple.Create(i - 1, j - 1));
                }
                if (s4 == 0)/*coin en haut à droite*/
                {
                    res.Add(Tuple.Create(i - 1, j + 1));
                }
                return res;
            }

            if (j == 0)//cas limite où on est sur le bord à gauche
            {
                s3 = plateau[i, j + 1] + plateau[i + 1, j + 1] + plateau[i + 1, j];
                s4 = plateau[i - 1, j] + plateau[i - 1, j + 1] + plateau[i, j + 1];
                if (s3 == 0)/*coin en bas à droite*/
                {
                    res.Add(Tuple.Create(i + 1, j + 1));
                }
                if (s4 == 0)/*coin en haut à droite*/
                {
                    res.Add(Tuple.Create(i - 1, j + 1));
                }
                return res;
            }

            if (j == 19)//cas où on est sur le bord ) droite
            {
                s1 = plateau[i - 1, j - 1] + plateau[i - 1, j] + plateau[i, j - 1];
                s2 = plateau[i, j - 1] + plateau[i + 1, j - 1] + plateau[i + 1, j];
                if (s1 == 0)/*coin en haut à gauche*/
                {
                    res.Add(Tuple.Create(i - 1, j - 1));
                }
                if (s2 == 0)/*coin en bas à gauche*/
                {
                    res.Add(Tuple.Create(i + 1, j - 1));
                }
                return res;
            }
            //hors cas limite:

            s1 = plateau[i - 1, j - 1] + plateau[i - 1, j] + plateau[i, j - 1];
            s2 = plateau[i, j - 1] + plateau[i + 1, j - 1] + plateau[i + 1, j];
            s3 = plateau[i, j + 1] + plateau[i + 1, j + 1] + plateau[i + 1, j];
            s4 = plateau[i - 1, j] + plateau[i - 1, j + 1] + plateau[i, j + 1];

            if (s1 == 0)/*coin en haut à gauche*/
            {
                res.Add(Tuple.Create(i - 1, j - 1));
            }
            if (s2 == 0)/*coin en bas à gauche*/
            {
                res.Add(Tuple.Create(i + 1, j - 1));
            }
            if (s3 == 0)/*coin en bas à droite*/
            {
                res.Add(Tuple.Create(i + 1, j + 1));
            }
            if (s4 == 0)/*coin en haut à droite*/
            {
                res.Add(Tuple.Create(i - 1, j + 1));
            }
            return res;
        }

        public static List<Tuple<int, int>> TousLesCoins(int[,] P, int CouleurJoueur)
        {
            int[,] plateau = new int[20, 20];
            for (int k = 0; k < 20; k++)
            {
                for (int l = 0; l < 20; l++)
                {
                    plateau[k, l] = P[k, l];
                    if (P[k, l] != CouleurJoueur)
                    {
                        plateau[k, l] = 0;
                    }
                }
            }
            var res = new List<Tuple<int, int>> { };
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (plateau[i, j] == CouleurJoueur)
                    {
                        List<Tuple<int, int>> liste_coins = IsUnCoin(i, j, plateau);
                        if (liste_coins.Count > 0)
                        {
                            for (int k = 0; k < liste_coins.Count; k++)
                            {
                                res.Add(liste_coins[k]);
                            }
                        }
                    }

                }
            }
            return res;
        }





    }
}