using Battleships.Services.UI.Elements;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Battleships.Services.UI.Elements
{
    public class BaseChildren : Base
    {
        public List<Base> Children = new List<Base>();

        public virtual void AddChild(Base child)
        {
            Children.Add(child);
        }

        public override void Update() {
            foreach(Base child in Children)
            {
                child.Update();
            }
        }

        public override void Draw(SpriteBatch canvas)
        {
            foreach (Base child in Children)
            {
                child.Draw(canvas);
            }
        }

        public override void HandleEvents()
        {
            foreach (Base child in Children)
            {
                child.HandleEvents();
            }
        }
    }
}
