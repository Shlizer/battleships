using Battleships.Services.UI.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Battleships.Services.UI.Elements
{
    public enum DialogType
    {
        Raw,
        Blue,
        Green,
        Red,
        Yellow
    }

    public class Dialog : BaseChildren
    {
        public DialogType Type = DialogType.Raw;
        public Rectangle Position = new Rectangle(0, 0, 0, 0);

        private Texture2D[] _texture = new Texture2D[9];

        private Dialog() { }

        public Dialog(Rectangle position)
        {
            Type = DialogType.Raw;
            Position = position;
            GetTextures();
        }

        public Dialog(DialogType type, Rectangle position)
        {
            Type = type;
            Position = position;
            GetTextures();
        }

        public void GetTextures() {
            Texture2D textureFull = UIManager.getContent().Load<Texture2D>(GetTextureName());
            _texture[0] = Image.Crop(textureFull, new Rectangle(0, 0, 10, 30));
            _texture[1] = Image.Crop(textureFull, new Rectangle(11, 0, 1, 30));
            _texture[2] = Image.Crop(textureFull, new Rectangle(textureFull.Width - 10, 0, 10, 30));
            _texture[3] = Image.Crop(textureFull, new Rectangle(0, 31, 10, 1));
            _texture[4] = Image.Crop(textureFull, new Rectangle(11, 31, 1, 1));
            _texture[5] = Image.Crop(textureFull, new Rectangle(textureFull.Width - 10, 31, 10, 1));
            _texture[6] = Image.Crop(textureFull, new Rectangle(0, textureFull.Height-12, 10, 12));
            _texture[7] = Image.Crop(textureFull, new Rectangle(11, textureFull.Height - 12, 10, 12));
            _texture[8] = Image.Crop(textureFull, new Rectangle(textureFull.Width - 10, textureFull.Height - 12, 10, 12));
        }

        protected string GetTextureName()
        {
            switch (Type)
            {
                case DialogType.Blue:
                    return "image/ui/metalPanel_blue";
                case DialogType.Green:
                    return "image/ui/metalPanel_green";
                case DialogType.Red:
                    return "image/ui/metalPanel_red";
                case DialogType.Yellow:
                    return "image/ui/metalPanel_yellow";
            }

            return "image/ui/metalPanel";
        }

        public override void Draw(SpriteBatch canvas)
        {
            // Center
            Image.TileInXYAsis(canvas, _texture[4], Position.X+_texture[3].Width, Position.Y+_texture[1].Height, Position.Width-_texture[3].Width-_texture[5].Width, Position.Height-_texture[1].Height-_texture[7].Height);
            // Borders
            Image.TileInXAsis(canvas, _texture[1], Position.X + _texture[0].Width, Position.Y, Position.Width - _texture[0].Width - _texture[2].Width);
            Image.TileInXAsis(canvas, _texture[7], Position.X + _texture[6].Width, Position.Y+Position.Height-_texture[7].Height, Position.Width - _texture[6].Width - _texture[8].Width);
            Image.TileInYAsis(canvas, _texture[3], Position.X, Position.Y + _texture[0].Height, Position.Height - _texture[0].Height - _texture[6].Height);
            Image.TileInYAsis(canvas, _texture[5], Position.X + Position.Width-_texture[3].Width, Position.Y + _texture[1].Height, Position.Height - _texture[2].Height - _texture[8].Height);
            // Corners
            canvas.Draw(_texture[0], new Rectangle(Position.X, Position.Y, _texture[0].Width, _texture[0].Height), Color.White);
            canvas.Draw(_texture[2], new Rectangle(Position.X+Position.Width-_texture[2].Width, Position.Y, _texture[2].Width, _texture[2].Height), Color.White);
            canvas.Draw(_texture[6], new Rectangle(Position.X, Position.Y+Position.Height-_texture[6].Height, _texture[6].Width, _texture[6].Height), Color.White);
            canvas.Draw(_texture[8], new Rectangle(Position.X + Position.Width - _texture[8].Width, Position.Y + Position.Height - _texture[8].Height, _texture[8].Width, _texture[8].Height), Color.White);
        }
    }
}
