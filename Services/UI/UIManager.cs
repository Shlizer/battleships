using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Battleships.Services.UI
{
    class UIManager// : HasChildren
    {
        private static GraphicsDevice _graphicsDevice;
        private static ContentManager _content;
        
        public UIManager(GraphicsDevice graphicsDevice, ContentManager content)
        {
            _graphicsDevice = graphicsDevice;
            _content = content;
        }

        public static GraphicsDevice getGfxDevice()
        {
            return _graphicsDevice;
        }

        public static ContentManager getContent()
        {
            return _content;
        }
    }
}
