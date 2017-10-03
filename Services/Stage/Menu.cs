using Battleships.Services;
using Battleships.Services.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Battleships.Services.Stage
{
    class Menu : BaseStage
    {
        private SpriteBatch spriteBatch;
        private Texture2D loadingScreenBG;
        private Dialog dialog;
        private float splashAlpha = 1.0f;

        public Menu(GraphicsDevice graphicsDevice, ContentManager content, UIManager uiManager) : base(graphicsDevice, content, uiManager) {}

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(_graphicsDevice);
            dialog = new Dialog();
            loadingScreenBG = _content.Load<Texture2D>("images/loading");
        }

        public override GameStage Update(GameTime gameTime)
        {
            if (splashAlpha >= 0.5f)
            {
                splashAlpha -= 0.01f;
            }
            return GameStage.Menu;
        }

        public override void Draw(GameTime gameTime)
        {
            _graphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            spriteBatch.Draw(loadingScreenBG, new Rectangle(0, 0, _graphicsDevice.Viewport.Width, _graphicsDevice.Viewport.Height), Color.White * splashAlpha);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            dialog.Draw();
            spriteBatch.End();
        }
    }
}
