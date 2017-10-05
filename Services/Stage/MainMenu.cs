using Battleships.Services.Stage.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Battleships.Services.Stage
{
    public class MainMenu : BaseStage
    {
        private Texture2D screenBG;
        private float stageAlpha = 1.0f;
        
        public override void LoadContent()
        {
            base.LoadContent();
            screenBG = content.Load<Texture2D>("image/loading");
            //dialog = new Dialog(DialogType.Red, new Rectangle(15, 15, 350, 200));
        }

        public override void Update(GameTime gameTime)
        {
            if (stageAlpha >= 0.5f)
                stageAlpha -= 0.01f;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            var gfx = GameStageManager.Instance.GraphicsDevice;
            gfx.Clear(Color.White);

            //spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            spriteBatch.Draw(screenBG, new Rectangle(0, 0, gfx.Viewport.Width, gfx.Viewport.Height), Color.White * stageAlpha);
            //spriteBatch.End();

            //spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            //if (UIScheme != null)
            //    UIScheme.Draw(spriteBatch);
            //dialog.Draw(spriteBatch);
            //spriteBatch.End();
        }
    }
}
