using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Battleships.Services.UI
{
    class Dialog
    {
        private Texture2D[] texture = new Texture2D[9];
        private SpriteBatch spriteBatch;

        public Dialog()
        {
            spriteBatch = new SpriteBatch(Graphics.canvas);
            texture[0] = Graphics.Crop("images/ui/metalPanel");
        }

        public void Draw()
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture[0], new Rectangle(0, 0, texture[0].Width, texture[0].Height), Color.White);
            spriteBatch.End();
        }
    }
}
