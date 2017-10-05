using Battleships.Services.UI.Elements;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace Battleships.Services.Stage.Helpers
{
    public class UIScheme : List<Base>, IXmlSerializable
    {
        public UIScheme() : base() { }

        public List<object> Items = new List<object>();

        #region IXmlSerializable
        public System.Xml.Schema.XmlSchema GetSchema() { return null; }

        public void ReadXml(XmlReader reader)
        {
            Type type = typeof(Base);
            reader.MoveToContent();
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    var elementType = Type.GetType(type.Namespace + "." + reader.Name);
                    if (type != null)
                    {
                        XmlSerializer xs = XmlSerializer.FromTypes(new[] { type })[0];
                        var element = Convert.ChangeType(xs.Deserialize(reader), elementType);
                        Items.Add(element);
                    }
                    /*if (this.Assembly != null)
                    {
                        type = Type.GetType(this.Namespace + "." + reader.Name + ", " + this.Assembly);
                    }
                    else
                    {
                        type = Type.GetType(this.Namespace + "." + reader.Name);
                    }
                    if (type != null)
                    {
                        XmlSerializer xs = XmlSerializer.FromTypes(new[] { type })[0];
                        this.Items.Add((T)xs.Deserialize(reader));
                    }*/
                }
            }

            /*
            reader.ReadStartElement("UIScheme");
            while (reader.IsStartElement("Base"))
            {
                Type type = Type.GetType(reader.GetAttribute("AssemblyQualifiedName"));
                XmlSerializer serial = new XmlSerializer(type);

                reader.ReadStartElement("Base");
                this.Add((Base)serial.Deserialize(reader));
                reader.ReadEndElement(); //Base
            }
            reader.ReadEndElement(); //UIScheme*/
        }

        public void WriteXml(XmlWriter writer)
        {
            foreach (Base uiElement in this)
            {
                writer.WriteStartElement("Base");
                writer.WriteAttributeString("AssemblyQualifiedName", uiElement.GetType().AssemblyQualifiedName);
                XmlSerializer xmlSerializer = new XmlSerializer(uiElement.GetType());
                xmlSerializer.Serialize(writer, uiElement);
                writer.WriteEndElement();
            }
        }
        #endregion
    }
}
