using Battleships.Services.UI.Elements;
using System;
using System.IO;
using System.Xml.Serialization;

namespace Battleships.Services.Stage.Helpers
{
    class XmlStageManager<T>
    {
        public Type Type;

        public XmlStageManager()
        {
            Type = typeof(T);
        }
        /*
        public T Load(string path)
        {
            T instance;
            using (TextReader reader = new StreamReader(path))
            {
                //XmlStageDeserializer<Base> xml = new XmlStageDeserializer<Base>(Type);
                //instance = (T)xml.Deserialize(reader);
            }
            return instance;
        }*/
    }
}
