using Battleships.Services;
using Battleships.Services.UI;
using Battleships.Services.UI.Elements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Battleships.Services.Stage
{
    class Menu : BaseStage
    {
        private SpriteBatch spriteBatch;
        private Texture2D screenBG;
        private Dialog dialog;
        private float stageAlpha = 1.0f;

        public Menu(GraphicsDevice graphicsDevice, ContentManager content, UIManager uiManager) : base(graphicsDevice, content, uiManager) {}

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(_graphicsDevice);
            screenBG = _content.Load<Texture2D>("images/loading");

            dialog = new Dialog(DialogType.Red, new Rectangle(15, 15, 350, 200));
        }

        public override GameStage Update(GameTime gameTime)
        {
            if (stageAlpha >= 0.5f)
            {
                stageAlpha -= 0.01f;
            }
            return GameStage.Menu;
        }

        public override void Draw(GameTime gameTime)
        {
            _graphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            spriteBatch.Draw(screenBG, new Rectangle(0, 0, _graphicsDevice.Viewport.Width, _graphicsDevice.Viewport.Height), Color.White * stageAlpha);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            dialog.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
