using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System;
using Battleships.Services;
using Battleships.Services.Stage.Helpers;

namespace Battleships
{
    public class Battleships : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private FrameCounter frameCounter = new FrameCounter();
        private SpriteFont debugFont;
        
        /**
         * Constructor - init base app settings
         */
        public Battleships()
        {
            graphics = new GraphicsDeviceManager(this);
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
            base.Initialize();
        }

        /**
         * Load and apply settings from cfg file
         */
        protected void LoadSettings()
        {
            Settings.LoadSettings();
            graphics.PreferredBackBufferWidth = Settings.GfxResolutionW;
            graphics.PreferredBackBufferHeight = Settings.GfxResolutionH;
            graphics.IsFullScreen = Settings.GfxFullscreen;
            graphics.ApplyChanges();
        }

        /**
         * 
         */
        protected override void LoadContent()
        {
            debugFont = Content.Load<SpriteFont>("font/debug");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            GameStageManager.Instance.GraphicsDevice = GraphicsDevice;
            GameStageManager.Instance.SpriteBatch = spriteBatch;
            GameStageManager.Instance.Content = Content;
            GameStageManager.Instance.ChangeStage("Splash");
        }

        /**
         * 
         */
        protected override void UnloadContent()
        {
            GameStageManager.Instance.Content.Unload();
        }

        /**
         * 
         */
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                LoadSettings();

            GameStageManager.Instance.Update(gameTime);

            base.Update(gameTime);
        }

        /**
         * 
         */
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            GameStageManager.Instance.Draw(spriteBatch);
            spriteBatch.End();


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
                string.Format("FPS: {0}\n", frameCounter.Draw(gameTime)) +
                string.Format("MEM: {0}MB\n", proc.PrivateMemorySize64 / 1024 / 1024) +
                string.Format("CPU: {0}%\n", cpuCounter.NextValue()) +
                string.Format("TIME: {0:hh\\:mm\\:ss}\n", time);// +
                //"STAGE: "+ GameStageManager..GetStage();

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
