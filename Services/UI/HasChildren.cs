using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Battleships.Services.UI
{
    class HasChildren : IElement
    {
        protected List<IElement> children = new List<IElement>();

        public virtual void AddChild(IElement child)
        {
            children.Add(child);
        }

        public virtual void Update() {
            foreach(IElement child in children)
            {
                child.Update();
            }
        }

        public virtual void Draw(SpriteBatch canvas)
        {
            foreach (IElement child in children)
            {
                child.Draw(canvas);
            }
        }

        public virtual void HandleEvents()
        {
            foreach (IElement child in children)
            {
                child.HandleEvents();
            }
        }
    }
}
