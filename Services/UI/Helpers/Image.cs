using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Battleships.Services.UI.Helpers
{
    class Image
    {
        public static Texture2D Crop(Texture2D originalTexture, Rectangle source)
        {
            Texture2D cropTexture = new Texture2D(UIManager.getGfxDevice(), source.Width, source.Height);
            Color[] data = new Color[source.Width * source.Height];
            originalTexture.GetData(0, source, data, 0, data.Length);
            cropTexture.SetData(data);
            return cropTexture;
        }

        public static void TileInXAsis(SpriteBatch canvas, Texture2D texture, int x, int y, int width)
        {
            for(int i = x; i < x + width; i += texture.Width)
            {
                canvas.Draw(texture, new Rectangle(i, y, texture.Width, texture.Height), Color.White); // @todo: tu jeszcze może wystąpić błąd - sprawdzanie dla niepełnej szerokości tile'a
            }
        }

        public static void TileInYAsis(SpriteBatch canvas, Texture2D texture, int x, int y, int height)
        {
            for (int i = y; i < y + height; i += texture.Height)
            {
                canvas.Draw(texture, new Rectangle(x, i, texture.Width, texture.Height), Color.White); // @todo: tu jeszcze może wystąpić błąd - sprawdzanie dla niepełnej szerokości tile'a
            }
        }

        public static void TileInXYAsis(SpriteBatch canvas, Texture2D texture, int x, int y, int width, int height)
        {
            for (int i = x; i < x + width; i += texture.Width)
            {
                for (int j = y; j < y + height; j += texture.Height)
                {
                    canvas.Draw(texture, new Rectangle(i, j, texture.Width, texture.Height), Color.White); // @todo: tu jeszcze może wystąpić błąd - sprawdzanie dla niepełnej szerokości tile'a
                }
            }
        }
    }
}
