using Battleships.Services.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Battleships.Services.Stage
{
    abstract class BaseStage
    {
        protected ContentManager _content;
        protected GraphicsDevice _graphicsDevice;
        protected UIManager _uiManager;

        public BaseStage(GraphicsDevice graphicsDevice, ContentManager content, UIManager uiManager)
        {
            _content = content;
            _graphicsDevice = graphicsDevice;
            _uiManager = uiManager;
            LoadContent();
        }

        abstract public GameStage Update(GameTime gameTime);
        abstract public void Draw(GameTime gameTime);
        abstract protected void LoadContent();
    }
}
