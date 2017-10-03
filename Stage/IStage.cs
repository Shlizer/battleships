using Battleships.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Battleships.Stage
{
    interface IStage
    {
        GameState Update(GameTime gameTime);
        void Draw(GameTime gameTime);
        void LoadContent();
    }
}
