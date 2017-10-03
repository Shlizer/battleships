using Battleships.Services.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Battleships.Services.Stage
{
    class GameStageManager
    {
        private Splash stageSplash;
        private Menu stageMenu;
        
        private GameStage _gameStage;
        private GraphicsDevice _graphicsDevice;
        private ContentManager _content;
        private UIManager _uiManager;

        public GameStageManager(GraphicsDevice graphicsDevice, ContentManager content, UIManager uiManager)
        {
            _uiManager = uiManager;
            _graphicsDevice = graphicsDevice;
            _content = content;

            stageSplash = new Splash(graphicsDevice, content, uiManager);
            stageMenu = new Menu(graphicsDevice, content, uiManager);

            _gameStage = GameStage.Splash;
        }

        public string GetStage()
        {
            return _gameStage.ToString();
        }

        public bool Update(GameTime gameTime)
        {
            switch (_gameStage)
            {
                case GameStage.Splash:
                    _gameStage = stageSplash.Update(gameTime);
                    break;
                case GameStage.Menu:
                    _gameStage = stageMenu.Update(gameTime);
                    break;
                case GameStage.Exit:
                default:
                    return false;
            }
            return true;
        }

        public void Draw(GameTime gameTime)
        {
            switch (_gameStage)
            {
                case GameStage.Splash:
                    stageSplash.Draw(gameTime);
                    break;
                case GameStage.Menu:
                    stageMenu.Draw(gameTime);
                    break;
            }
        }
    }
}
