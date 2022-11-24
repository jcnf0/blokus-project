using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Input;
using System;
using Microsoft.Xna.Framework.Audio;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework.Content;

namespace Blokus
{
    public static class Font
    {
        public static SpriteFont police { get; private set; }
        public static float Size = 0.25f;

        public static void Load(ContentManager Content)
        {
            police = Content.Load<SpriteFont>("Font/police");
        }
    }
}
