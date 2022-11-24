using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blokus
{
    public static class BlackScreen
    {
        public static float opacite = 0.001f;
        public static bool isUp = false;
        public static bool isFading = false;
        public static float speed1 = 1.1f;
        public static float speed2 = 0.9f;
        public static GameState nextState = GameState.menu;
        public static bool needState = false;
        public static void Transition(float _speed1, float _speed2)
        {
            speed1 = _speed1;
            speed2 = _speed2;
            isFading = true;
            if (opacite == 0.001f)
            {
                isUp = true;
            }
        }
        public static bool CheckMiddle()
        {
            if (opacite >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void ButtonTransition(GameState state)
        {
            nextState = state;
            needState = true;
        }
        public static void Update(GameTime gameTime)
        {
            if (needState)
            {
                Transition(1.2f, 0.8f);
                if (CheckMiddle())
                {
                    Game1.gameState = nextState;
                    needState = false;
                }
            }
            if (isFading)
            {
                if (isUp)
                {
                    if (opacite > 0.05f)
                        opacite *= speed1;
                    else
                        opacite *= speed1 * 1.8f;
                    opacite = MathHelper.Clamp(opacite, 0.001f, 1);
                    if (opacite >= 1)
                    {
                        isUp = false;
                    }
                }
                else
                {
                    if (opacite > 0.05f)
                        opacite *= speed2;
                    else
                        opacite *= speed2 * 0.2f;
                    opacite = MathHelper.Clamp(opacite, 0.001f, 1);
                    if (opacite <= 0.001f)
                    {
                        isUp = true;
                        isFading = false;
                    }
                }
            }
        }
        public static void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(Art.bar, Game1.TrueScreenSize / 2 + Game1.camera.Centre, null, Color.Black * opacite, 0, new Vector2(Art.bar.Bounds.Center.X, Art.bar.Bounds.Center.Y), 25, 0, 0);
        }
    }
}
