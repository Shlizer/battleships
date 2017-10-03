using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System;
using Battleships.Services;
using Battleships.Services.UI;
using Battleships.Services.Stage;

namespace Battleships
{
    public class Battleships : Game
    {
        private GraphicsDeviceManager canvas;
        private FrameCounter frameCounter = new FrameCounter();
        private GameStageManager gameStateManager;
        private UIManager uiManager;
        private SpriteFont debugFont;
        
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
            uiManager = new UIManager(GraphicsDevice, Content);
            gameStateManager = new GameStageManager(GraphicsDevice, Content, uiManager);
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
            debugFont = Content.Load<SpriteFont>("font/debug");
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
            if (!gameStateManager.Update(gameTime))
                Exit();

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
            gameStateManager.Draw(gameTime);

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
                "STAGE: "+gameStateManager.GetStage();

            spriteBatch.Begin();
            spriteBatch.DrawString(debugFont, debugInfo, new Vector2(x + 0, y + 1), Color.Black);
            spriteBatch.DrawString(debugFont, debugInfo, new Vector2(x + 1, y + 0), Color.Black);
            spriteBatch.DrawString(debugFont, debugInfo, new Vector2(x + 2, y + 1), Color.Black);
            spriteBatch.DrawString(debugFont, debugInfo, new Vector2(x + 1, y + 2), Color.Black);
            spriteBatch.DrawString(debugFont, debugInfo, new Vector2(x + 1, y + 1), Color.White);
            spriteBatch.End();
        }
    }
}
