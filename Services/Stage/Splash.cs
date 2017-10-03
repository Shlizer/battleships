using Battleships.Services.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Battleships.Services.Stage
{
    class Splash : BaseStage
    {
        private Texture2D loadingScreenBG;
        private SpriteBatch spriteBatch;

        private float timerExit = 0.0f;
        private float _remainingTimeExit;
        
        public Splash(GraphicsDevice graphicsDevice, ContentManager content, UIManager uiManager) : base(graphicsDevice, content, uiManager) { }
        
        protected override void LoadContent()
        {
            _remainingTimeExit = Settings.GfxSplashTime;
            spriteBatch = new SpriteBatch(_graphicsDevice);
            loadingScreenBG = _content.Load<Texture2D>("images/loading");
        }

        public override GameStage Update(GameTime gameTime)
        {
            if (timerExit.Equals(0.0f))
                timerExit = (float)gameTime.ElapsedGameTime.TotalSeconds;

            _remainingTimeExit -= timerExit;

            if (_remainingTimeExit <= 0)
                return GameStage.Menu;
            return GameStage.Splash;
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(loadingScreenBG, new Rectangle(0, 0, Graphics.canvas.Viewport.Width, Graphics.canvas.Viewport.Height), Color.White);
            spriteBatch.End();
        }
    }
}
