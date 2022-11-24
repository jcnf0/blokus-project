using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Blokus
{
    public static class Art
    {
        public static Texture2D logo { get; private set; }
        public static Texture2D backGround { get; private set; }
        public static Texture2D boutonPlay { get; private set; }
        public static Texture2D piece { get; private set; }
        public static Texture2D bouton_abandonner { get; private set; }
        public static Texture2D bouton { get; private set; }
        public static Texture2D piece2 { get; private set; }
        public static Texture2D plateau { get; private set; }

        public static Texture2D playButton { get; private set; }
        public static Texture2D playtexte { get; private set; }
        public static Texture2D quitTexte { get; private set; }
        public static Texture2D tutoTexte { get; private set; }
        public static Texture2D leaveTexte { get; private set; }
        public static Texture2D imgTuto { get; private set; }
        public static void Load(ContentManager Content)
        {
            imgTuto = Content.Load<Texture2D>("Graph/imgTuto");
            leaveTexte = Content.Load<Texture2D>("Graph/leaveTexte");
            quitTexte = Content.Load<Texture2D>("Graph/quitTexte");
            tutoTexte = Content.Load<Texture2D>("Graph/tutoTexte");
            plateau = Content.Load<Texture2D>("Graph/plateau");
            playtexte = Content.Load<Texture2D>("Graph/playtexte");
            playButton = Content.Load<Texture2D>("Graph/playButton");
            bouton = Content.Load<Texture2D>("Graph/bouton");
            bouton_abandonner = Content.Load<Texture2D>("Graph/bouton_abandonner");
            piece2 = Content.Load<Texture2D>("Graph/piece2");
            piece = Content.Load<Texture2D>("Graph/piece");
            boutonPlay = Content.Load<Texture2D>("Graph/boutonPlay");
            logo = Content.Load<Texture2D>("Graph/Blokus");
            backGround = Content.Load<Texture2D>("Graph/backGround");
        }
    }
}
