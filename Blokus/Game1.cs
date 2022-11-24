using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Input;
using System;
using Microsoft.Xna.Framework.Audio;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using System.IO;
using Keys = Microsoft.Xna.Framework.Input.Keys;
using System.Linq;
using System.Windows.Forms;

namespace Blokus
{
    public enum GameState { menu, play, selection, win }
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static Random aleatoire;
        public static GameState gameState;
        public static bool isClicked = false;
        public static Game1 Instance;
        public RenderTarget2D UIrender;
        public RenderTarget2D Prender;
        public RenderTarget2D Winrender;
        public Plateau plateau;
        public static Viewport Viewport { get { return Instance.GraphicsDevice.Viewport; } }
        public static Vector2 screenSize { get { return new Vector2(Viewport.Width, Viewport.Height); } }
        public static Vector2 TrueScreenSize { get { return new Vector2(Viewport.Width, Viewport.Height); } }
        public static Texture2D placeHolder;
        public static bool isFullscreen = false;
        private Vector2 posBackground1;
        private Vector2 posBackground2;
        private Button boutonPlay;
        private Button boutonQuit;
        private Button boutonQuitSelection;
        private Button boutonTuto;

        private Button boutonPlaySelection;
        private Button boutonJ1;
        private Button boutonJ2;
        private Button boutonJ3;
        private Button boutonJ4;

        private Text texte_tuto_1;
        private Text texte_tuto_2;
        private Text texte_tuto_3;
        private Text texte_tuto_4;
        private Text texte_tuto_5;

        public float testrotation = 0;

        public bool isTutorial;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Instance = this;
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1200;
            graphics.PreferredBackBufferHeight = 720;
            changeFullscreen();
        }

        public void changeFullscreen()
        {
            graphics.IsFullScreen = isFullscreen;
            if (isFullscreen)
            {
                graphics.PreferredBackBufferWidth = (int)(Screen.PrimaryScreen.Bounds.Width);
                graphics.PreferredBackBufferHeight = (int)(Screen.PrimaryScreen.Bounds.Height);
            }
            else
            {
                graphics.PreferredBackBufferWidth = (int)(Screen.PrimaryScreen.Bounds.Width);
                graphics.PreferredBackBufferHeight = (int)(Screen.PrimaryScreen.Bounds.Height) - 50;
            }
            graphics.ApplyChanges();
        }
        public void ResetGame()
        {
            plateau = new Plateau();
        }
        protected override void Initialize()
        {
            isTutorial = false;
            base.Initialize();
            gameState = GameState.menu;
            posBackground1 = new Vector2(screenSize.X / 2, screenSize.Y / 2);
            posBackground2 = new Vector2(screenSize.X / 2, screenSize.Y / 2 - Art.backGround.Height);
            boutonPlay = new Button(new Vector2(screenSize.X / 2, screenSize.Y * 2 / 3 + 50), Art.playButton, Art.playtexte, "play", 1, 1.1f);
            boutonTuto = new Button(new Vector2(screenSize.X / 2 - 300, screenSize.Y * 2 / 3 + 50), Art.playButton, Art.tutoTexte, "tuto", 1, 1.1f);
            boutonQuit = new Button(new Vector2(screenSize.X / 2 + 300, screenSize.Y * 2 / 3 + 50), Art.playButton, Art.leaveTexte, "quit", 1, 1.1f);
            boutonQuitSelection = new Button(new Vector2(screenSize.X / 2 + 500, screenSize.Y / 2), Art.playButton, Art.quitTexte, "quitselection", 1, 1.1f);

            Vector2 postuto = new Vector2(Game1.screenSize.X / 3 - 100, 130);
            texte_tuto_1 = new Text(1.3f, postuto, "TUTO", Color.White, Color.Black, 10000000);
            texte_tuto_2 = new Text(1, postuto + new Vector2(0, 110), "a", Color.White, Color.Black, 10000000);
            texte_tuto_3 = new Text(1, postuto + new Vector2(0, 210), "b", Color.White, Color.Black, 10000000);
            texte_tuto_4 = new Text(1, postuto + new Vector2(0, 310), "c", Color.White, Color.Black, 10000000);
            texte_tuto_5 = new Text(1, postuto + new Vector2(0, 410), "d", Color.White, Color.Black, 10000000);

            resetSelection();
            aleatoire = new Random();
            plateau = new Plateau();
        }
        public void resetSelection()
        {
            boutonPlaySelection = new Button(new Vector2(screenSize.X / 2, screenSize.Y / 2), Art.playButton, Art.playtexte, "playSelection", 1, 1.1f);

            int decal = 175;
            boutonJ1 = new Button(new Vector2(screenSize.X / 2 - decal, screenSize.Y / 2 - decal), Art.playButton, null, "J1", 1.1f, 1.2f, "joueur", 1, 1);
            boutonJ2 = new Button(new Vector2(screenSize.X / 2 + decal, screenSize.Y / 2 - decal), Art.playButton, null, "J2", 1.1f, 1.2f, "joueur", 1, 2);
            boutonJ3 = new Button(new Vector2(screenSize.X / 2 + decal, screenSize.Y / 2 + decal), Art.playButton, null, "J3", 1.1f, 1.2f, "joueur", 1, 3);
            boutonJ4 = new Button(new Vector2(screenSize.X / 2 - decal, screenSize.Y / 2 + decal), Art.playButton, null, "J4", 1.1f, 1.2f, "joueur", 1, 4);

        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            placeHolder = new Texture2D(GraphicsDevice, 10, 10);

            Art.Load(Content);
            Font.Load(Content);

            var pp = GraphicsDevice.PresentationParameters;
            UIrender = new RenderTarget2D(GraphicsDevice, pp.BackBufferWidth, pp.BackBufferHeight);
            Prender = new RenderTarget2D(GraphicsDevice, pp.BackBufferWidth, pp.BackBufferHeight);
            Winrender = new RenderTarget2D(GraphicsDevice, pp.BackBufferWidth, pp.BackBufferHeight);
        }
        protected override void UnloadContent()
        {
        }
        public void skip_turn()
        {
            plateau.nextTurn();
        }
        public void quitGame()
        {
            Exit();
        }
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            var mState = Mouse.GetState();
            if (mState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released)
            {
                isClicked = false;
            }
            testrotation += (float)Math.PI * (float)gameTime.ElapsedGameTime.TotalSeconds;

            float vitesse = 0.5f;
            posBackground1.Y += vitesse;
            posBackground2.Y += vitesse;
            if (posBackground1.Y - Art.backGround.Height >= screenSize.Y)
            {
                posBackground1.Y = posBackground2.Y - Art.backGround.Height;
            }
            if (posBackground2.Y - Art.backGround.Height >= screenSize.Y)
            {
                posBackground2.Y = posBackground1.Y - Art.backGround.Height;
            }

            if (gameState == GameState.menu)
            {
                boutonQuit.Update(gameTime);
                if (isTutorial)
                {
                    boutonQuit.imageTXT = Art.quitTexte;
                    boutonQuit.position = new Vector2(screenSize.X / 2 + 300, screenSize.Y * 2 / 3 + 150);
                }
                else
                {
                    boutonQuit.position = new Vector2(screenSize.X / 2 + 300, screenSize.Y * 2 / 3 + 50);
                    boutonQuit.imageTXT = Art.leaveTexte;
                    boutonTuto.Update(gameTime);
                    boutonPlay.Update(gameTime);
                }
            }
            if (gameState == GameState.selection)
            {
                boutonQuitSelection.Update(gameTime);
                boutonJ1.Update(gameTime);
                boutonJ2.Update(gameTime);
                boutonJ3.Update(gameTime);
                boutonJ4.Update(gameTime);
                boutonPlaySelection.Update(gameTime);
            }
            else if (gameState == GameState.play)
            {
                plateau.Update(gameTime);
            }
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);

            if (gameState == GameState.menu)
            {
                GraphicsDevice.SetRenderTarget(UIrender);
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp);
                GraphicsDevice.Clear(Color.White);
                spriteBatch.Draw(Art.backGround, posBackground1, null, Color.White, 0, new Vector2(Art.backGround.Bounds.Center.X, Art.backGround.Bounds.Center.Y), 1, 0, 0);
                spriteBatch.Draw(Art.backGround, posBackground2, null, Color.White, 0, new Vector2(Art.backGround.Bounds.Center.X, Art.backGround.Bounds.Center.Y), 1, 0, 0);
                spriteBatch.Draw(Art.logo, new Vector2(screenSize.X / 2, screenSize.Y / 4), null, Color.White, 0, new Vector2(Art.logo.Bounds.Center.X, Art.logo.Bounds.Center.Y), 1, 0, 0);
                boutonPlay.Draw(spriteBatch);
                boutonTuto.Draw(spriteBatch);
                if (isTutorial)
                {
                    spriteBatch.Draw(Art.piece, TrueScreenSize / 2, null, Color.Black * 0.85f, 0, new Vector2(Art.piece.Bounds.Center.X, Art.piece.Bounds.Center.Y), 300, 0, 0);
                    spriteBatch.Draw(Art.imgTuto, TrueScreenSize / 2 + new Vector2(300, -75), null, Color.White, 0, new Vector2(Art.imgTuto.Bounds.Center.X, Art.imgTuto.Bounds.Center.Y), 1, 0, 0);
                    texte_tuto_1.Draw(spriteBatch);
                    texte_tuto_2.Draw(spriteBatch);
                    texte_tuto_3.Draw(spriteBatch);
                    texte_tuto_4.Draw(spriteBatch);
                    texte_tuto_5.Draw(spriteBatch);
                }
                boutonQuit.Draw(spriteBatch);
                spriteBatch.End();

                GraphicsDevice.SetRenderTarget(null);
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp);
                spriteBatch.Draw(UIrender, screenSize / 2, null, Color.White, 0, new Vector2(UIrender.Bounds.Center.X, UIrender.Bounds.Center.Y), 1, 0, 0);
                spriteBatch.End();
            }
            if (gameState == GameState.selection)
            {
                GraphicsDevice.SetRenderTarget(UIrender);
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp);
                GraphicsDevice.Clear(Color.White);
                spriteBatch.Draw(Art.backGround, posBackground1, null, Color.White, 0, new Vector2(Art.backGround.Bounds.Center.X, Art.backGround.Bounds.Center.Y), 1, 0, 0);
                spriteBatch.Draw(Art.backGround, posBackground2, null, Color.White, 0, new Vector2(Art.backGround.Bounds.Center.X, Art.backGround.Bounds.Center.Y), 1, 0, 0);


                boutonQuitSelection.Draw(spriteBatch);
                boutonPlaySelection.Draw(spriteBatch);
                boutonJ1.Draw(spriteBatch);
                boutonJ2.Draw(spriteBatch);
                boutonJ3.Draw(spriteBatch);
                boutonJ4.Draw(spriteBatch);

                spriteBatch.End();

                GraphicsDevice.SetRenderTarget(null);
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp);
                spriteBatch.Draw(UIrender, screenSize / 2, null, Color.White, 0, new Vector2(UIrender.Bounds.Center.X, UIrender.Bounds.Center.Y), 1, 0, 0);
                spriteBatch.End();
            }
            if (gameState == GameState.play)
            {
                GraphicsDevice.SetRenderTarget(Prender);
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp);
                GraphicsDevice.Clear(Color.White);
                spriteBatch.Draw(Art.backGround, posBackground1, null, Color.White, 0, new Vector2(Art.backGround.Bounds.Center.X, Art.backGround.Bounds.Center.Y), 1, 0, 0);
                spriteBatch.Draw(Art.backGround, posBackground2, null, Color.White, 0, new Vector2(Art.backGround.Bounds.Center.X, Art.backGround.Bounds.Center.Y), 1, 0, 0);
                plateau.Draw(spriteBatch);
                spriteBatch.End();

                GraphicsDevice.SetRenderTarget(null);
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp);
                spriteBatch.Draw(Prender, screenSize / 2, null, Color.White, 0, new Vector2(Prender.Bounds.Center.X, Prender.Bounds.Center.Y), 1, 0, 0);
                spriteBatch.End();
            }
            if (gameState == GameState.win)
            {
                GraphicsDevice.SetRenderTarget(Winrender);
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp);
                GraphicsDevice.Clear(Color.White);
                spriteBatch.Draw(Art.backGround, posBackground1, null, Color.White, 0, new Vector2(Art.backGround.Bounds.Center.X, Art.backGround.Bounds.Center.Y), 1, 0, 0);
                spriteBatch.Draw(Art.backGround, posBackground2, null, Color.White, 0, new Vector2(Art.backGround.Bounds.Center.X, Art.backGround.Bounds.Center.Y), 1, 0, 0);


                spriteBatch.End();

                GraphicsDevice.SetRenderTarget(null);
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp);
                spriteBatch.Draw(Winrender, screenSize / 2, null, Color.White, 0, new Vector2(Winrender.Bounds.Center.X, Prender.Bounds.Center.Y), 1, 0, 0);
                spriteBatch.End();
            }
        }
    }
}
