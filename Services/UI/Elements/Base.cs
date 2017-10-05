using Microsoft.Xna.Framework.Graphics;

namespace Battleships.Services.UI.Elements
{
    public class Base
    {
        public virtual void Update() { }
        public virtual void Draw(SpriteBatch canvas) { }
        public virtual void HandleEvents() { }
    }
}
