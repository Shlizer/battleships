using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;
using System.Diagnostics;
using System;
using Battleships.Services;
using Battleships.Stage;

namespace Battleships
{
    public class Battleships : Game
    {
        private GraphicsDeviceManager canvas;
        private FrameCounter frameCounter = new FrameCounter();
        private GameState gameState;

        private Splash stageSplash;
        private Menu stageMenu;
        private Options stageOptions;
        private Author stageAuthor;
        private Playing stagePlaying;
        private Scoreboard stageScoreboard;

        private SpriteFont font;
        
        /**
         * Constructor - init base app settings
         */
        public Battleships()
        {
            canvas = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.IsBorderless = true;
            Window.Title = "Battleships";
            IsMouseVisible = true;
            //base.IsFixedTimeStep = false;
        }
        
        /**
         * Initialize standard settings for app
         */
        protected override void Initialize()
        {
            LoadSettings();

            Graphics.canvas = GraphicsDevice;
            Graphics.content = Content;

            stageSplash = new Splash();
            stageMenu = new Menu();
            //stageOptions = new Options();
            //stageAuthor = new Author();
            //stagePlaying = new Playing();
            //stageScoreboard = new Scoreboard();

            gameState = GameState.Splash;
            base.Initialize();
        }

        /**
         * Load and apply settings from cfg file
         */
        protected void LoadSettings()
        {
            Settings.LoadSettings();
            canvas.PreferredBackBufferWidth = Settings.GfxResolutionW;
            canvas.PreferredBackBufferHeight = Settings.GfxResolutionH;
            canvas.IsFullScreen = Settings.GfxFullscreen;
            canvas.ApplyChanges();
        }

        /**
         * 
         */
        protected override void LoadContent()
        {
            font = Content.Load<SpriteFont>("font/debug");
            
            //Thread bgLoad = new Thread(new ThreadStart(LoadGame));
            //bgLoad.IsBackground = false;
            //bgLoad.Start();

            stageSplash.LoadContent();
            stageMenu.LoadContent();
            //stageOptions.LoadContent();
            //stageAuthor.LoadContent();
            //stagePlaying.LoadContent();
            //stageScoreboard.LoadContent();
        }

        /**
         * 
         */
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /**
         * 
         */
        protected override void Update(GameTime gameTime)
        {
            switch (gameState)
            {
                case GameState.Splash:
                    gameState = stageSplash.Update(gameTime);
                    break;
                case GameState.Menu:
                    gameState = stageMenu.Update(gameTime);
                    break;
                //case GameState.Options:
                //    gameState = stageOptions.Update(gameTime);
                //    break;
                default:
                    Exit();
                    break;
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                LoadSettings();

            base.Update(gameTime);
        }

        /**
         * 
         */
        protected override void Draw(GameTime gameTime)
        {
            switch (gameState)
            {
                case GameState.Splash:
                    stageSplash.Draw(gameTime);
                    break;
                case GameState.Menu:
                    stageMenu.Draw(gameTime);
                    break;
            }
            
            if (Settings.DebugShow)
                ShowDebugInfo(gameTime);
            
            base.Draw(gameTime);
        }

        /**
         * Showing debug info
         */
        private void ShowDebugInfo(GameTime gameTime)
        {
            int x = 5, y = 5;
            SpriteBatch spriteBatch = new SpriteBatch(GraphicsDevice);
            Process proc = Process.GetCurrentProcess();
            PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            TimeSpan time =  DateTime.UtcNow - Process.GetCurrentProcess().StartTime.ToUniversalTime();

            string debugInfo =
                string.Format("FPS: {0}\n",frameCounter.Draw(gameTime)) +
                string.Format("MEM: {0}MB\n", proc.PrivateMemorySize64 / 1024 / 1024) +
                string.Format("CPU: {0}%\n", cpuCounter.NextValue()) +
                string.Format("TIME: {0:hh\\:mm\\:ss}\n", time) +
                "STAGE: "+gameState;

            spriteBatch.Begin();
            spriteBatch.DrawString(font, debugInfo, new Vector2(x + 0, y + 1), Color.Black);
            spriteBatch.DrawString(font, debugInfo, new Vector2(x + 1, y + 0), Color.Black);
            spriteBatch.DrawString(font, debugInfo, new Vector2(x + 2, y + 1), Color.Black);
            spriteBatch.DrawString(font, debugInfo, new Vector2(x + 1, y + 2), Color.Black);
            spriteBatch.DrawString(font, debugInfo, new Vector2(x + 1, y + 1), Color.White);
            spriteBatch.End();
        }

        /**
         * 
         */
        public void LoadGame()
        {
            //Loading stuff here
            gameState = GameState.Menu; //or GameState.Playing
        }
    }
}
