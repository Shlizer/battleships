using Battleships.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Battleships.Stage
{
    class Splash : IStage
    {
        private Texture2D loadingScreenBG;
        private SpriteBatch spriteBatch;
        private float timer = 0.0f;
        private float _delay;
        private float _remainingDelay;

        public Splash()
        {
            _delay = Settings.GfxSplashTime;
            _remainingDelay = _delay;
            spriteBatch = new SpriteBatch(Graphics.canvas);
        }
        
        public void LoadContent()
        {
            loadingScreenBG = Graphics.content.Load<Texture2D>("images/loading");
        }

        public GameState Update(GameTime gameTime)
        {
            if (timer.Equals(0.0f))
                timer = (float)gameTime.ElapsedGameTime.TotalSeconds;

            _remainingDelay -= timer;

            if (_remainingDelay <= 0)
                return GameState.Menu;
            return GameState.Splash;
        }

        public void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(loadingScreenBG, new Rectangle(0, 0, Graphics.canvas.Viewport.Width, Graphics.canvas.Viewport.Height), Color.White);
            spriteBatch.End();
        }
    }
}
