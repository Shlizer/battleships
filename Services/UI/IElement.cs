using Microsoft.Xna.Framework.Graphics;

namespace Battleships.Services.UI
{
    public interface IElement
    {
        //void Update(Rectangle parentRect);
        void Update();
        void Draw(SpriteBatch canvas);
        void HandleEvents();
    }
}
