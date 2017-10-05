using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Battleships.Services.Stage.Helpers
{
    class XmlStageDeserializer<T> : Collection<T>, IXmlSerializable where T : class
    {
        private string Namespace { get; set; }
        private string Assembly { get; set; }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public XmlStageDeserializer()
        {
        }

        public XmlStageDeserializer(IList<T> list, string namespaceOfInheritedTypes = null, string assemblyOfInheritedTypes = null) : base(list)
    {
            this.Namespace = namespaceOfInheritedTypes ?? null;
            this.Assembly = assemblyOfInheritedTypes ?? null;
        }

        public XmlStageDeserializer(string namespaceOfInheritedTypes, string assemblyOfInheritedTypes = null)
        {
            this.Namespace = namespaceOfInheritedTypes ?? null;
            this.Assembly = assemblyOfInheritedTypes ?? null;
        }


        public void ReadXml(XmlReader reader)
        {
            this.Namespace = reader.GetAttribute("fromNamespace");
            this.Assembly = reader.GetAttribute("fromAssembly");

            reader.MoveToContent();
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    Type type;
                    if (this.Assembly != null)
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
                    }
                }
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("fromNamespace", this.Namespace);
            if (this.Assembly != null) writer.WriteAttributeString("fromAssembly", this.Assembly);
            foreach (T element in this)
            {
                Type type = element.GetType();
                XmlSerializer xs = XmlSerializer.FromTypes(new[] { type })[0];
                xs.Serialize(writer, element);
            }
        }
    }
}
