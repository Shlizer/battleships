using System.Collections.Generic;

namespace Battleships.Services.UI
{
    class HasChildren
    {
        protected List<IElement> children;

        public void AddChild(IElement child)
        {
            children.Add(child);
        }
    }
}
