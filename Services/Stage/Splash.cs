using Battleships.Services.Stage.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Battleships.Services.Stage
{
    public class Splash : BaseStage
    {
        private Texture2D loadingScreenBG;

        private float timerExit = 0.0f;
        private float remainingTimeExit;
        
        public override void LoadContent()
        {
            base.LoadContent();
            remainingTimeExit = Settings.GfxSplashTime;
            loadingScreenBG = content.Load<Texture2D>("image/loading");
        }

        public override void Update(GameTime gameTime)
        {
            if (timerExit.Equals(0.0f))
                timerExit = (float)gameTime.ElapsedGameTime.TotalSeconds;

            remainingTimeExit -= timerExit;

            if (remainingTimeExit <= 0)
                GameStageManager.Instance.ChangeStage("MainMenu");
                //GameStageManager.PushStage(new Menu());
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Viewport Viewport = GameStageManager.Instance.GraphicsDevice.Viewport;
            spriteBatch.Draw(loadingScreenBG, new Rectangle(0, 0, Viewport.Width, Viewport.Height), Color.White);
        }
    }
}
