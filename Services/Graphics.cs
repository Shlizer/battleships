using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Battleships.Services
{
    static class Graphics
    {
        public static GraphicsDevice canvas;
        public static ContentManager content;

        public static Texture2D Crop(string textureName)
        {
            Texture2D originalTexture = content.Load<Texture2D>(textureName);
            Rectangle sourceRectangle = new Rectangle(10, 10, originalTexture.Width - 20, originalTexture.Height - 20);

            Texture2D cropTexture = new Texture2D(canvas, sourceRectangle.Width, sourceRectangle.Height);
            Color[] data = new Color[sourceRectangle.Width * sourceRectangle.Height];
            originalTexture.GetData(0, sourceRectangle, data, 0, data.Length);
            cropTexture.SetData(data);
            return cropTexture;
        }
    }
}
