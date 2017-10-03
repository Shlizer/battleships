using Battleships.Services.UI.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Battleships.Services.UI.Elements
{
    enum DialogType
    {
        Raw,
        Blue,
        Green,
        Red,
        Yellow
    }

    class Dialog : HasChildren
    {
        private DialogType _textureType = DialogType.Raw;
        private Texture2D[] _texture = new Texture2D[9];
        private Rectangle _position = new Rectangle(0, 0, 0, 0);

        public Dialog(Rectangle position)
        {
            _textureType = DialogType.Raw;
            _position = position;
            GetTextures();
        }

        public Dialog(DialogType type, Rectangle position)
        {
            _textureType = type;
            _position = position;
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
            switch (_textureType)
            {
                case DialogType.Blue:
                    return "images/ui/metalPanel_blue";
                case DialogType.Green:
                    return "images/ui/metalPanel_green";
                case DialogType.Red:
                    return "images/ui/metalPanel_red";
                case DialogType.Yellow:
                    return "images/ui/metalPanel_yellow";
            }

            return "images/ui/metalPanel";
        }

        public override void Draw(SpriteBatch canvas)
        {
            // Center
            Image.TileInXYAsis(canvas, _texture[4], _position.X+_texture[3].Width, _position.Y+_texture[1].Height, _position.Width-_texture[3].Width-_texture[5].Width, _position.Height-_texture[1].Height-_texture[7].Height);
            // Borders
            Image.TileInXAsis(canvas, _texture[1], _position.X + _texture[0].Width, _position.Y, _position.Width - _texture[0].Width - _texture[2].Width);
            Image.TileInXAsis(canvas, _texture[7], _position.X + _texture[6].Width, _position.Y+_position.Height-_texture[7].Height, _position.Width - _texture[6].Width - _texture[8].Width);
            Image.TileInYAsis(canvas, _texture[3], _position.X, _position.Y + _texture[0].Height, _position.Height - _texture[0].Height - _texture[6].Height);
            Image.TileInYAsis(canvas, _texture[5], _position.X + _position.Width-_texture[3].Width, _position.Y + _texture[1].Height, _position.Height - _texture[2].Height - _texture[8].Height);
            // Corners
            canvas.Draw(_texture[0], new Rectangle(_position.X, _position.Y, _texture[0].Width, _texture[0].Height), Color.White);
            canvas.Draw(_texture[2], new Rectangle(_position.X+_position.Width-_texture[2].Width, _position.Y, _texture[2].Width, _texture[2].Height), Color.White);
            canvas.Draw(_texture[6], new Rectangle(_position.X, _position.Y+_position.Height-_texture[6].Height, _texture[6].Width, _texture[6].Height), Color.White);
            canvas.Draw(_texture[8], new Rectangle(_position.X + _position.Width - _texture[8].Width, _position.Y + _position.Height - _texture[8].Height, _texture[8].Width, _texture[8].Height), Color.White);
        }
    }
}
