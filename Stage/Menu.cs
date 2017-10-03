using Battleships.Services;
using Battleships.Services.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Battleships.Stage
{
    class Menu : IStage 
    {
        private Texture2D loadingScreenBG;
        private SpriteBatch spriteBatch;
        private Dialog dialog;
        private float splashAlpha = 1.0f;

        public Menu()
        {
            spriteBatch = new SpriteBatch(Graphics.canvas);
            dialog = new Dialog();
        }

        public void LoadContent()
        {
            loadingScreenBG = Graphics.content.Load<Texture2D>("images/loading");
        }

        public GameState Update(GameTime gameTime)
        {
            if (splashAlpha >= 0.5f)
            {
                splashAlpha -= 0.01f;
            }
            return GameState.Menu;
        }

        public void Draw(GameTime gameTime)
        {
            Graphics.canvas.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            spriteBatch.Draw(loadingScreenBG, new Rectangle(0, 0, Graphics.canvas.Viewport.Width, Graphics.canvas.Viewport.Height), Color.White * splashAlpha);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            dialog.Draw();
            spriteBatch.End();
        }
    }
}
