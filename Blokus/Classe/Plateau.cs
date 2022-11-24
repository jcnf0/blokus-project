using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
namespace Blokus
{
    public class Plateau
    {
        // Le plateau de jeu
        public int[,] plateau;
        // Le joueur actuel (pour savoir quelle pièce il peut jouer)
        public int joueur_actuel;
        // la liste des pièces des joueurs
        public List<Piece> pieces_j1;
        public List<Piece> pieces_j2;
        public List<Piece> pieces_j3;
        public List<Piece> pieces_j4;
        // La pièce sélectionnée
        public Piece piece_selectionnee;
        // La position de la pièce sélectionnée
        public Vector2 pos_piece_selec;
        // Si on doit afficher la pièce sélectionnée
        public bool draw_selection;
        // Si la pièce est sur le plateau
        public bool isinplateau;
        // Si on est en train de tourner la pièce
        public bool isrotation;
        // Si on est en train de faire une symétrie de la pièce
        public bool isflip;
        // Si on respecte les règles du jeu
        public bool regle_respectee;

        // Le texte indiquant qui doit jouer
        public Text texte_qui_joue;
        // Le bouton pour abandonner
        public Button skip_button;
        // Le bouton pour rejouer
        public Button replay_button;

        // La liste des joueurs ayant abandonné
        public List<int> abandons;

        // Le score des joueurs
        public Text score1;
        public Text score2;
        public Text score3;
        public Text score4;
        // Le score des équipes
        public Text score_equipe1;
        public Text score_equipe2;

        // Les textes de victoire
        public Text win;
        public Text win_vert_rouge;
        public Text win_vert_rouge_score;

        public Text score_vert;
        public Text score_rouge;
        public Text score_bleu;
        public Text score_jaune;

        public Text win_bleu_jaune;
        public Text win_bleu_jaune_score;

        // La liste des scores des joueurs
        public List<int> scores;

        // Si la partie est finie
        public bool isWin;

        // Si les joueurs sont des IA
        public bool[] isAI;
        // La couleur des joueurs
        public Color[] couleurs_joueurs;
        // La type d'IA
        public List<int> WhatAI;

        public float timer;

        public int nb_coups;


        public Plateau()
        {
            nb_coups = 0;

            timer = 0;
            isWin = false;
            abandons = new List<int>();
            regle_respectee = true;
            isrotation = false;
            isflip = false;
            Pieces.Initialise();
            isinplateau = false;
            couleurs_joueurs = new Color[] { Color.Green, Color.Blue, Color.Yellow, Color.Red };
            // La plateau
            draw_selection = true;
            pos_piece_selec = new Vector2(0, 0);
            plateau = new int[20, 20]{
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
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},};
            // Le joueur actuel est le premier par défaut
            joueur_actuel = 1;
            // Aucune pièce n'est sélectionnée
            piece_selectionnee = null;
            // On crée la liste des pièces de tous les joueurs
            pieces_j1 = new List<Piece>();
            pieces_j2 = new List<Piece>();
            pieces_j3 = new List<Piece>();
            pieces_j4 = new List<Piece>();

            int decal_large = 70;
            int decal_hauteur = 75;

            score1 = new Text(1, new Vector2(decal_large, (Game1.TrueScreenSize.Y / 2) - decal_hauteur), "score : 0", Color.Green, Color.Green * 0, 10000000);
            score2 = new Text(1, new Vector2(Game1.TrueScreenSize.X - decal_large, (Game1.TrueScreenSize.Y / 2) - decal_hauteur), "score : 0", Color.Blue, Color.Blue * 0, 10000000);
            score3 = new Text(1, new Vector2(decal_large, (Game1.TrueScreenSize.Y / 2) + decal_hauteur), "score : 0", Color.Yellow, Color.Yellow * 0, 10000000);
            score4 = new Text(1, new Vector2(Game1.TrueScreenSize.X - decal_large, (Game1.TrueScreenSize.Y / 2) + decal_hauteur), "score : 0", Color.Red, Color.Red * 0, 10000000);

            score_equipe1 = new Text(1, new Vector2(156, (Game1.TrueScreenSize.Y / 2) - 20), "score : 0", Color.White, Color.Red * 0, 10000000);
            score_equipe2 = new Text(1, new Vector2(156, (Game1.TrueScreenSize.Y / 2) + 20), "score : 0", Color.White, Color.Red * 0, 10000000);

            win_vert_rouge = new Text(1, new Vector2(Game1.TrueScreenSize.X / 2, (Game1.TrueScreenSize.Y / 2) - 150), "vert rouge", Color.Purple, Color.Red * 0, 10000000);
            win_vert_rouge_score = new Text(1, new Vector2(Game1.TrueScreenSize.X / 2, (Game1.TrueScreenSize.Y / 2) - 100), "vert rouge", Color.White, Color.Red * 0, 10000000);
            score_vert = new Text(1, new Vector2(Game1.TrueScreenSize.X / 2, (Game1.TrueScreenSize.Y / 2) + 100), "vert rouge", Color.Green, Color.Red * 0, 10000000);
            score_rouge = new Text(1, new Vector2(Game1.TrueScreenSize.X / 2, (Game1.TrueScreenSize.Y / 2) + 50), "vert rouge", Color.Red, Color.Red * 0, 10000000);
            score_bleu = new Text(1, new Vector2(Game1.TrueScreenSize.X / 2, (Game1.TrueScreenSize.Y / 2) - 50), "vert rouge", Color.Blue, Color.Red * 0, 10000000);
            score_jaune = new Text(1, new Vector2(Game1.TrueScreenSize.X / 2, (Game1.TrueScreenSize.Y / 2) - 0), "vert rouge", Color.Yellow, Color.Red * 0, 10000000);
            win_bleu_jaune = new Text(1, new Vector2(Game1.TrueScreenSize.X / 2, (Game1.TrueScreenSize.Y / 2) - 150), "bleu jaune", Color.Purple, Color.Red * 0, 10000000);
            win_bleu_jaune_score = new Text(1, new Vector2(Game1.TrueScreenSize.X / 2, (Game1.TrueScreenSize.Y / 2) - 100), "bleu jaune", Color.Blue, Color.Red * 0, 10000000);
            win = new Text(1, new Vector2(Game1.TrueScreenSize.X / 2, (Game1.TrueScreenSize.Y / 2) - 200), "La partie est finie !", Color.White, Color.Red * 0, 10000000);

            //texte affichant à qui c'est le tour
            texte_qui_joue = new Text(1.3f, new Vector2(Game1.TrueScreenSize.X / 2, 40), "", Color.White, Color.Black, 10000000);
            skip_button = new Button(new Vector2(Game1.TrueScreenSize.X - 50 - 35 - 75, (Game1.TrueScreenSize.Y / 2)), Art.bouton_abandonner, null, "skip", 1, 1.1f, "je ne peux plus jouer");

            //replay
            replay_button = new Button(new Vector2(Game1.TrueScreenSize.X / 2, (Game1.TrueScreenSize.Y / 2) + 150), Art.bouton_abandonner, null, "rejouer", 1, 1.1f, "Rejouer");

            // On crée les pièces de tous les joueurs
            for (int i = 0; i < Pieces.pieces.Count; i++)
            {
                pieces_j1.Add(new Piece(Pieces.pieces[i], Color.Green, i));
                pieces_j2.Add(new Piece(Pieces.pieces[i], Color.Blue, i));
                pieces_j3.Add(new Piece(Pieces.pieces[i], Color.Yellow, i));
                pieces_j4.Add(new Piece(Pieces.pieces[i], Color.Red, i));
            }
            scores = new List<int>();
            scores.Add(0);
            scores.Add(0);
            scores.Add(0);
            scores.Add(0);
            //IA
            isAI = new bool[4];
            isAI[0] = false;
            isAI[1] = false;
            isAI[2] = false;
            isAI[3] = false;
            WhatAI = new List<int>();
            int ia = 0;
            WhatAI.Add(ia);
            WhatAI.Add(ia);
            WhatAI.Add(ia);
            WhatAI.Add(ia);
        }
        public void Update(GameTime gameTime)
        /*
         * Met à jour le plateau
         */
        {
            if (!isWin) //si la partie n'est pas finie
            {
                skip_button.Update(gameTime);
            }
            else //si la partie est finie
            {
                replay_button.Update(gameTime);
            }
            var Kstate = Keyboard.GetState(); //on récupère les touches
            if (Kstate.IsKeyDown(Keys.R) && !isrotation) //si on appuie sur R
            {
                piece_selectionnee.rotation();
                isrotation = true;
            }
            if (Kstate.IsKeyUp(Keys.R))
            {
                isrotation = false;
            }
            if (Kstate.IsKeyDown(Keys.M) && !isflip)
            {
                piece_selectionnee.flip();
                isflip = true;
            }
            if (Kstate.IsKeyUp(Keys.M))
            {
                isflip = false;
            }
            // Pour chaque pièce
            if (!isWin)
            {
                for (int i = 0; i < 21; i++)
                {
                    // On ne la met à jour que si elle appartient au joueur qui doit jouer
                    switch (joueur_actuel)
                    {
                        case 1:
                            pieces_j1[i].Update(gameTime, selection, deselection, piece_selectionnee);
                            break;
                        case 2:
                            pieces_j2[i].Update(gameTime, selection, deselection, piece_selectionnee);
                            break;
                        case 3:
                            pieces_j3[i].Update(gameTime, selection, deselection, piece_selectionnee);
                            break;
                        case 4:
                            pieces_j4[i].Update(gameTime, selection, deselection, piece_selectionnee);
                            break;
                    }
                }
            }
            if (!isAI[joueur_actuel - 1])
            {
                var Mstate = Mouse.GetState();
                if (piece_selectionnee != null && !isWin)
                {
                    regle_respectee = respecte_regle(piece_selectionnee.piece, pos_piece_selec);
                    if (Mstate.LeftButton == ButtonState.Pressed && !Game1.isClicked)
                    {
                        if (draw_selection && isinplateau && regle_respectee)
                        {
                            poserPiece(piece_selectionnee.piece, pos_piece_selec, plateau);
                        }
                    }
                }
            }
            else
            {
                if (timer >= 0.1f || true)
                {
                    if (!isWin)
                    {
                        chooseAI(WhatAI[joueur_actuel - 1]);
                        timer = 0;
                    }
                }
            }
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        public void chooseAI(int typeAI)
        {
            List<Coup> coups = coupPossible(joueur_actuel, plateau);
            switch (typeAI)
            {
                case 0:
                    random_coup(coups);
                    //random_piece(joueur_actuel, plateau);
                    break;
                case 1:
                    meilleurs_coup(coups);
                    //piece_optimale(joueur_actuel, plateau);
                    break;
                case 2:
                    if (nb_coups <= 2)
                    {
                        meilleurs_coup(coups);
                        nb_coups++;
                    }
                    else
                    {
                        minmax_coup(coups);
                    }
                    break;
            }
        }
        public void minmax_coup(List<Coup> coups)
        {
            if (coups.Count == 0)
            {
                if (!abandons.Contains(joueur_actuel))
                    nextTurn();
            }
            else
            {
                int profondeur = 2;
                Coup coup = GFG.Minmax(profondeur, copier(), true, profondeur, new Coup(new Piece(Pieces.pieces[0], Color.White, 1), Vector2.Zero, true), joueur_actuel, joueur_actuel).Item2;
                jouerCoup(coup);
            }
        }
        public void meilleurs_coup(List<Coup> coups)
        {
            if (coups.Count == 0)
            {
                if (!abandons.Contains(joueur_actuel))
                    nextTurn();
            }
            else
            {
                List<double> poids = new List<double>() { 2, 3, 4, 3.75, 4.67, 5, 4.67, 5, 5, 5.89, 6, 6, 5.89, 6, 5.56, 5.67, 6, 5.67, 6, 6, 5.89 };
                Coup coup = new Coup(pieces_j1[0], Vector2.Zero, true);
                foreach (var c in coups)
                {
                    if (poids[coup.piece.ID] <= poids[c.piece.ID])
                    {
                        coup = new Coup(copyPiece(c.piece), c.position);
                    }
                }
                if (!coup.estNul)
                    jouerCoup(coup);
            }
        }
        public void random_coup(List<Coup> coups)
        {
            if (coups.Count == 0)
            {
                if (!abandons.Contains(joueur_actuel))
                    nextTurn();
            }
            else
            {
                Coup coup = coups[Game1.aleatoire.Next(coups.Count)];
                jouerCoup(coup);
            }
        }
        public void annulerCoup(int joueur, Coup coup)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (coup.piece.piece[j, i] == 1)
                    {
                        int ti = i + (int)coup.position.X;
                        int tj = j + (int)coup.position.Y;
                        if (ti >= 0 && tj >= 0 && ti < 20 && tj < 20)
                        {
                            plateau[tj, ti] = 0;
                            scores[joueur_actuel - 1] -= 1;
                        }
                    }
                }
            }
            for (int i = 0; i < pieces_j1.Count; i++)
            {
                switch (joueur)
                {
                    case 1:
                        if (pieces_j1[i].ID == coup.piece.ID)
                        {
                            pieces_j1[i].dragged = false;
                        }
                        break;
                    case 2:
                        if (pieces_j2[i].ID == coup.piece.ID)
                        {
                            pieces_j2[i].dragged = false;
                        }
                        break;
                    case 3:
                        if (pieces_j3[i].ID == coup.piece.ID)
                        {
                            pieces_j3[i].dragged = false;
                        }
                        break;
                    case 4:
                        if (pieces_j4[i].ID == coup.piece.ID)
                        {
                            pieces_j4[i].dragged = false;
                        }
                        break;
                }
            }
        }
        public void jouerCoup(Coup coup)
        {
            Piece piece_jouee = coup.piece;
            selection(piece_jouee);

            for (int i = 0; i < pieces_j1.Count; i++)
            {
                switch (joueur_actuel)
                {
                    case 1:
                        if (pieces_j1[i].ID == piece_jouee.ID)
                        {
                            pieces_j1[i].dragged = true;
                        }
                        break;
                    case 2:
                        if (pieces_j2[i].ID == piece_jouee.ID)
                        {
                            pieces_j2[i].dragged = true;
                        }
                        break;
                    case 3:
                        if (pieces_j3[i].ID == piece_jouee.ID)
                        {
                            pieces_j3[i].dragged = true;
                        }
                        break;
                    case 4:
                        if (pieces_j4[i].ID == piece_jouee.ID)
                        {
                            pieces_j4[i].dragged = true;
                        }
                        break;
                }
            }

            poserPiece(piece_jouee.piece, coup.position, plateau);
            piece_selectionnee = null;
        }
        public Plateau copier()
        {
            Plateau copie = new Plateau();
            copie.plateau = new int[20, 20];
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    copie.plateau[i, j] = plateau[i, j];
                }
            }
            copie.pieces_j1 = new List<Piece>();
            copie.pieces_j2 = new List<Piece>();
            copie.pieces_j3 = new List<Piece>();
            copie.pieces_j4 = new List<Piece>();

            for (int i = 0; i < Pieces.pieces.Count; i++)
            {
                copie.pieces_j1.Add(copyPiece(pieces_j1[i]));
            }
            for (int i = 0; i < Pieces.pieces.Count; i++)
            {
                copie.pieces_j2.Add(copyPiece(pieces_j2[i]));
            }
            for (int i = 0; i < Pieces.pieces.Count; i++)
            {
                copie.pieces_j3.Add(copyPiece(pieces_j3[i]));
            }
            for (int i = 0; i < Pieces.pieces.Count; i++)
            {
                copie.pieces_j4.Add(copyPiece(pieces_j4[i]));
            }

            copie.abandons = new List<int>();
            copie.abandons.AddRange(abandons);
            copie.joueur_actuel = joueur_actuel;
            copie.scores = new List<int>();
            copie.scores.AddRange(scores);
            return copie;
        }
        public Piece copyPiece(Piece piece)
        {
            int[,] nforme = new int[5, 5];
            for (int u = 0; u < 5; u++)
            {
                for (int w = 0; w < 5; w++)
                {
                    nforme[u, w] = piece.piece[u, w];
                }
            }
            return new Piece(nforme, piece.couleur, piece.ID);
        }
        public Plateau ajouter(Coup coup)
        {
            Plateau copie = copier();
            copie.piece_selectionnee = copyPiece(coup.piece);
            copie.poserPiece(coup.piece.piece, coup.position, copie.plateau);
            return copie;
        }
        public List<Coup> coupPossible(int joueur, int[,] p)
        {
            List<Coup> coups = new List<Coup>();
            List<Tuple<int, int>> coins = Coin.TousLesCoins(p, joueur);

            List<Piece> liste_pieces = new List<Piece>();
            if (scores[joueur - 1] == 0)
            {
                switch (joueur)
                {
                    case 1:
                        coins = new List<Tuple<int, int>> { new Tuple<int, int>(0, 0) };

                        break;
                    case 2:
                        coins = new List<Tuple<int, int>> { new Tuple<int, int>(0, 19) };
                        break;
                    case 3:
                        coins = new List<Tuple<int, int>> { new Tuple<int, int>(19, 0) };
                        break;
                    case 4:
                        coins = new List<Tuple<int, int>> { new Tuple<int, int>(19, 19) };
                        break;
                }
            }
            switch (joueur)
            {
                case 1:
                    liste_pieces = pieces_j1;
                    break;
                case 2:
                    liste_pieces = pieces_j2;
                    break;
                case 3:
                    liste_pieces = pieces_j3;
                    break;
                case 4:
                    liste_pieces = pieces_j4;
                    break;
            }

            int pieces_restantes = 0;
            foreach (var piece in liste_pieces)
            {
                if (!piece.dragged)
                    pieces_restantes++;
            }
            if (pieces_restantes == 0)
            {
                if (!abandons.Contains(joueur))
                    nextTurn();
            }
            //Console.WriteLine("coins dispo : " + coins.Count.ToString() + " | pieces dispo : " + pieces_restantes);
            foreach (var coin in coins)
            {
                for (int k = 0; k < 21; k++)
                {
                    Piece piece = liste_pieces[k];
                    if (!piece.dragged)
                    {
                        for (int m = 0; m < 2; m++)
                        {
                            for (int r = 0; r < 4; r++)
                            {
                                int decal = 5;
                                for (int i = -decal; i < decal; i++)
                                {
                                    for (int j = -decal; j < decal; j++)
                                    {
                                        bool respecte = respecte_regle(piece.piece, new Vector2(coin.Item2 + i, coin.Item1 + j));
                                        if (respecte && is_in_plateau(piece.piece, new Vector2(coin.Item2 + i, coin.Item1 + j)))
                                        {
                                            Piece npiece = copyPiece(piece);
                                            coups.Add(new Coup(npiece, new Vector2(coin.Item2 + i, coin.Item1 + j)));
                                        }
                                    }
                                }
                                piece.rotation();
                            }
                            piece.flip();
                        }
                    }
                }
            }
            //string printcoins = "";
            //foreach (var coup in coups)
            //{
            //    printcoins += "id piece : " + coup.piece.ID;
            //    printcoins += "  - emplacement : " + coup.position;
            //    printcoins += "\n";
            //}
            //printcoins += "--------------------------";
            //Console.WriteLine(printcoins);

            return coups;
        }
        public bool respecte_regle(int[,] p, Vector2 pos)
        {
            bool respecte = true;
            bool iscoin = false;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (p[j, i] == 1)
                    {
                        int ti = i + (int)pos.X;
                        int tj = j + (int)pos.Y;
                        if (ti >= 0 && tj >= 0 && ti < 20 && tj < 20)
                        {
                            if (p[j, i] != 0)
                            {
                                //pas de superposition
                                if (plateau[tj, ti] != 0)
                                {
                                    respecte = false;
                                }
                                //piece adjascente de meme couleur
                                if (tj - 1 >= 0)
                                    if (plateau[tj - 1, ti] == p[j, i] * joueur_actuel)
                                    {
                                        respecte = false;
                                    }
                                if (ti - 1 >= 0)
                                    if (plateau[tj, ti - 1] == p[j, i] * joueur_actuel)
                                    {
                                        respecte = false;
                                    }
                                if (tj + 1 <= 19)
                                    if (plateau[tj + 1, ti] == p[j, i] * joueur_actuel)
                                    {
                                        respecte = false;
                                    }
                                if (ti + 1 <= 19)
                                    if (plateau[tj, ti + 1] == p[j, i] * joueur_actuel)
                                    {
                                        respecte = false;
                                    }
                                //doit toucher une piece dans le coin
                                if (tj - 1 >= 0 && ti - 1 >= 0)
                                    if (plateau[tj - 1, ti - 1] == joueur_actuel)
                                    {
                                        iscoin = true;
                                    }
                                if (tj + 1 <= 19 && ti - 1 >= 0)
                                    if (plateau[tj + 1, ti - 1] == joueur_actuel)
                                    {
                                        iscoin = true;
                                    }
                                if (tj - 1 >= 0 && ti + 1 <= 19)
                                    if (plateau[tj - 1, ti + 1] == joueur_actuel)
                                    {
                                        iscoin = true;
                                    }
                                if (tj + 1 <= 19 && ti + 1 <= 19)
                                    if (plateau[tj + 1, ti + 1] == joueur_actuel)
                                    {
                                        iscoin = true;
                                    }
                                switch (joueur_actuel)
                                {
                                    case 1:
                                        if (tj == 0 && ti == 0)
                                        {
                                            iscoin = true;
                                        }
                                        break;
                                    case 2:
                                        if (tj == 0 && ti == 19)
                                        {
                                            iscoin = true;
                                        }
                                        break;
                                    case 3:
                                        if (tj == 19 && ti == 0)
                                        {
                                            iscoin = true;
                                        }
                                        break;
                                    case 4:
                                        if (tj == 19 && ti == 19)
                                        {
                                            iscoin = true;
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
            }

            return respecte && iscoin;
        }
        public bool is_in_plateau(int[,] p, Vector2 pos)
        {
            bool yes = true;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Vector2 true_pos = new Vector2(pos.X + i, pos.Y + j);
                    if (p[j, i] != 0)
                    {
                        if (true_pos.X < 0 || true_pos.X > 19 || true_pos.Y < 0 || true_pos.Y > 19)
                            yes = false;
                    }
                }
            }
            return yes;
        }
        public void poserPiece(int[,] p, Vector2 pos, int[,] cplateau)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (p[j, i] == 1)
                    {
                        int ti = i + (int)pos.X;
                        int tj = j + (int)pos.Y;
                        if (ti >= 0 && tj >= 0 && ti < 20 && tj < 20)
                        {
                            cplateau[tj, ti] = p[j, i] * joueur_actuel;
                        }
                    }
                }
            }
            piece_selectionnee.dragged = false;
            scores[joueur_actuel - 1] += piece_selectionnee.points;

            if (abandons.Count < 4)
            {
                rotation_joueur();
                while (abandons.Contains(joueur_actuel))
                {
                    rotation_joueur();
                }
            }

            piece_selectionnee = null;
            reset_selection();

        }
        public void rotation_joueur()
        {
            if (joueur_actuel == 2)
            {
                joueur_actuel = 4;
            }
            else if (joueur_actuel == 4)
            {
                joueur_actuel = 3;
            }
            else if (joueur_actuel == 3)
            {
                joueur_actuel = 1;
            }
            else
            {
                joueur_actuel += 1;
            }
            if (joueur_actuel == 5)
            {
                joueur_actuel = 1;
            }

            if (!isAI[joueur_actuel - 1])
            {
                List<Coup> coups = coupPossible(joueur_actuel, plateau);
                if (coups.Count == 0)
                {
                    nextTurn();
                }
            }
        }
        public void nextTurn()
        {
            abandons.Add(joueur_actuel);
            isWin = abandons.Count == 4;

            if (abandons.Count < 4)
            {
                rotation_joueur();
                while (abandons.Contains(joueur_actuel))
                {
                    rotation_joueur();
                }
            }

            piece_selectionnee = null;
            reset_selection();
        }
        public void reset_selection()
        {
            switch (joueur_actuel)
            {
                case 1:
                    foreach (var p in pieces_j1)
                    {
                        if (p == piece_selectionnee)
                        {
                            p.dragged = false;
                        }
                    }
                    break;
                case 2:
                    foreach (var p in pieces_j2)
                    {
                        if (p == piece_selectionnee)
                        {
                            p.dragged = false;
                        }
                    }
                    break;
                case 3:
                    foreach (var p in pieces_j3)
                    {
                        if (p == piece_selectionnee)
                        {
                            p.dragged = false;
                        }
                    }
                    break;
                case 4:
                    foreach (var p in pieces_j4)
                    {
                        if (p == piece_selectionnee)
                        {
                            p.dragged = false;
                        }
                    }
                    break;
            }
        }
        public int selection(Piece p)
        /*
         * Permet de changer la pièce sélectionnée (on retourne un int, car void n'est pas accepté comme paramètre de sortie)
         */
        {
            piece_selectionnee = p;
            return 2;
        }
        public int deselection(Piece p)
        /*
         * Permet de changer la pièce sélectionnée (on retourne un int, car void n'est pas accepté comme paramètre de sortie)
         */
        {

            for (int i = 0; i < pieces_j1.Count; i++)
            {
                switch (joueur_actuel)
                {
                    case 1:
                        if (pieces_j1[i].ID == p.ID)
                        {
                            pieces_j1[i] = new Piece(p.piece, Color.Green, p.ID);
                            piece_selectionnee = null;
                        }
                        break;
                    case 2:
                        if (pieces_j2[i].ID == p.ID)
                        {
                            pieces_j2[i] = new Piece(p.piece, Color.Blue, p.ID);
                            piece_selectionnee = null;
                        }
                        break;
                    case 3:
                        if (pieces_j3[i].ID == p.ID)
                        {
                            pieces_j3[i] = new Piece(p.piece, Color.Yellow, p.ID);
                            piece_selectionnee = null;
                        }
                        break;
                    case 4:
                        if (pieces_j4[i].ID == p.ID)
                        {
                            pieces_j4[i] = new Piece(p.piece, Color.Red, p.ID);
                            piece_selectionnee = null;
                        }
                        break;
                }
            }
            return 2;
        }

        public void Draw(SpriteBatch spriteBatch)
        /*
         * Affiche le plateau
         */
        {
            // Le fond
            spriteBatch.Draw(Art.piece, Game1.TrueScreenSize / 2, null, Color.Black, 0, new Vector2(Art.piece.Bounds.Center.X, Art.piece.Bounds.Center.Y), 300, 0, 0);

            spriteBatch.Draw(Art.plateau, Game1.TrueScreenSize / 2, null, Color.White, 0, new Vector2(Art.plateau.Bounds.Center.X, Art.plateau.Bounds.Center.Y), 1.05f, 0, 0);


            // Le couleur de fond
            Color couleur = Color.White;
            // La taille des pièces
            int taille_piece = 30;
            // La taille du plateau
            int taille = taille_piece * 20;
            // La position
            Vector2 pos = new Vector2();
            // On crée le plateau
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    // On change la position du centre de la pièce
                    pos.X = i * taille_piece;
                    pos.Y = j * taille_piece;
                    // On change la couleur en fonction de la valeur de la pièce posée
                    Texture2D texture = Art.piece;
                    float t = 1.5f;
                    switch (plateau[j, i])
                    {
                        case 0:
                            texture = Art.piece2;
                            couleur = new Color(205, 209, 220);
                            t = 1.45f;
                            break;
                        case 1:
                            couleur = Color.Green;
                            break;
                        case 2:
                            couleur = Color.Blue;
                            break;
                        case 3:
                            couleur = Color.Yellow;
                            break;
                        case 4:
                            couleur = Color.Red;
                            break;
                    }
                    // On centre la position
                    pos += Game1.TrueScreenSize / 2 - new Vector2(taille, taille) / 2;
                    // On affiche un carré
                    spriteBatch.Draw(texture, pos, null, couleur, 0, new Vector2(0, 0), t, 0, 0);
                }
            }

            // L'escpace entre les pièces des joueurs que l'on affiche dans les coins
            int decalX = 20 * 3;
            int decalY = 20 * 3;
            // On itère sur l'index des pièces
            for (int i = 0; i < 21; i++)
            {
                // On calcule sa position
                Vector2 pos2 = new Vector2(decalX * (i % 6), decalY * (i / 6));
                // On vérifie que le joueur possède assez de pièce
                if (pieces_j1.Count > i)
                {
                    // On affiche la ièce
                    pieces_j1[i].Draw(spriteBatch, pos2, joueur_actuel != 1);
                }
                else
                {
                    continue;
                }
                if (pieces_j2.Count > i)
                {
                    pieces_j2[i].Draw(spriteBatch, pos2 + new Vector2(Game1.TrueScreenSize.X - 357, 0), joueur_actuel != 2);
                }
                else
                {
                    continue;
                }
                if (pieces_j3.Count > i)
                {
                    pieces_j3[i].Draw(spriteBatch, pos2 + new Vector2(0, Game1.TrueScreenSize.Y - 250), joueur_actuel != 3);
                }
                else
                {
                    continue;
                }
                if (pieces_j4.Count > i)
                {
                    pieces_j4[i].Draw(spriteBatch, pos2 + new Vector2(Game1.TrueScreenSize.X - 357, Game1.TrueScreenSize.Y - 250), joueur_actuel != 4);
                }
                else
                {
                    continue;
                }
            }

            // Si une pièce est sélectionnée
            if (piece_selectionnee != null)
            {
                // On affiche la pièce au niveau de la souris
                var Mstate = Mouse.GetState();
                Vector2 pos_plateau = Game1.TrueScreenSize / 2 - new Vector2(taille, taille) / 2;
                if (Mstate.X >= pos_plateau.X && Mstate.X <= pos_plateau.X + taille - 10 && Mstate.Y >= pos_plateau.Y && Mstate.Y <= pos_plateau.Y + taille - 10)
                {
                    isinplateau = true;
                    Vector2 posRelative = new Vector2(Mstate.X, Mstate.Y) - pos_plateau;
                    posRelative = new Vector2((int)posRelative.X / taille_piece, (int)posRelative.Y / taille_piece);

                    List<Vector2> listePos = new List<Vector2>();
                    bool dodraw = true;
                    draw_selection = true;

                    pos_piece_selec = posRelative - new Vector2(2, 2);
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (piece_selectionnee.piece[j, i] == 1)
                            {
                                Vector2 pos3 = new Vector2();
                                pos3.X = i * taille_piece;
                                pos3.Y = j * taille_piece;
                                listePos.Add(pos3);
                                Vector2 true_pos = pos3 + posRelative * taille_piece - new Vector2(taille_piece, taille_piece) * 2;
                                if (true_pos.X < 0 || true_pos.Y < 0 || true_pos.X > taille - taille_piece || true_pos.Y > taille - taille_piece)
                                {
                                    draw_selection = false;
                                    dodraw = false;
                                }
                            }
                        }
                    }
                    if (dodraw)
                    {
                        Color c = piece_selectionnee.couleur;
                        if (!regle_respectee)
                        {
                            c = Color.Purple;
                        }

                        for (int i = 0; i < listePos.Count; i++)
                        {
                            spriteBatch.Draw(Art.piece, listePos[i] + posRelative * taille_piece + pos_plateau - new Vector2(taille_piece, taille_piece) * 2, null, c, 0, new Vector2(0, 0), 1.5f, 0, 0);
                        }
                    }
                    //spriteBatch.Draw(Art.piece, posRelative * taille_piece + pos_plateau - new Vector2(taille_piece, taille_piece) * 2, null, piece_selectionnee.couleur, 0, new Vector2(0, 0), 1, 0, 0);
                }
                else
                {
                    isinplateau = false;
                }
            }
            score1.text = "score : " + scores[0].ToString();
            score2.text = "score : " + scores[1].ToString();
            score3.text = "score : " + scores[2].ToString();
            score4.text = "score : " + scores[3].ToString();

            score_equipe1.text = "score vert + rouge : " + (scores[0] + scores[3]).ToString();
            score_equipe2.text = "score bleu + jaune : " + (scores[1] + scores[2]).ToString();

            texte_qui_joue.text = "c'est au tour du ";
            switch (joueur_actuel)
            {
                case 0:
                    texte_qui_joue.couleurInterieur = Color.White;
                    texte_qui_joue.text += "";
                    break;
                case 1:
                    texte_qui_joue.couleurInterieur = Color.Green;
                    texte_qui_joue.text += "vert";
                    break;
                case 2:
                    texte_qui_joue.couleurInterieur = Color.Blue;
                    texte_qui_joue.text += "bleu";
                    break;
                case 3:
                    texte_qui_joue.couleurInterieur = Color.Yellow;
                    texte_qui_joue.text += "jaune";
                    break;
                case 4:
                    texte_qui_joue.couleurInterieur = Color.Red;
                    texte_qui_joue.text += "rouge";
                    break;
            }
            texte_qui_joue.Draw(spriteBatch);
            skip_button.Draw(spriteBatch);

            score1.Draw(spriteBatch);
            score2.Draw(spriteBatch);
            score3.Draw(spriteBatch);
            score4.Draw(spriteBatch);

            score_equipe1.Draw(spriteBatch);
            score_equipe2.Draw(spriteBatch);

            if (isWin)
            {
                spriteBatch.Draw(Art.piece, Game1.TrueScreenSize / 2, null, Color.Black * 0.9f, 0, new Vector2(Art.piece.Bounds.Center.X, Art.piece.Bounds.Center.Y), 300, 0, 0);

                //List<int> indices_triee = new List<int>();
                win.Draw(spriteBatch);
                if (scores[0] + scores[3] >= scores[1] + scores[2])
                {
                    win_vert_rouge.text = "l'equipe 1 gagne ! (vert et rouge)";
                    win_vert_rouge_score.text = "avec un score de : " + (scores[0] + scores[3]).ToString();
                    win_vert_rouge_score.Draw(spriteBatch);
                    win_vert_rouge.Draw(spriteBatch);

                }
                else
                {
                    win_bleu_jaune.text = "l'equipe 2 gagne ! (bleu et jaune)";
                    win_bleu_jaune.Draw(spriteBatch);

                    win_bleu_jaune_score.text = "avec un score de : " + (scores[1] + scores[2]).ToString();
                    win_bleu_jaune_score.Draw(spriteBatch);

                }

                score_bleu.text = "score bleu : " + scores[1].ToString();
                score_bleu.Draw(spriteBatch);
                score_jaune.text = "score jaune : " + scores[2].ToString();
                score_jaune.Draw(spriteBatch);
                score_rouge.text = "score rouge : " + scores[3].ToString();
                score_rouge.Draw(spriteBatch);
                score_vert.text = "score vert : " + scores[0].ToString();
                score_vert.Draw(spriteBatch);

                replay_button.Draw(spriteBatch);
            }
        }
    }
}
