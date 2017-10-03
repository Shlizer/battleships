using Microsoft.Xna.Framework;

namespace Battleships.Services.Stage
{
    interface IStage
    {
        void LoadContent();
        GameStage Update(GameTime gameTime);
        void Draw(GameTime gameTime);
    }
}
