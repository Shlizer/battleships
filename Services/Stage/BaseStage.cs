using Battleships.Services.Stage.Helpers;
using Battleships.Services.UI.Elements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Battleships.Services.Stage
{
    public abstract class BaseStage : IStage
    {
        public UIScheme uiScheme;
        [XmlIgnore]
        protected ContentManager content;
        [XmlIgnore]
        public Type stageType;
        [XmlIgnore]
        public string XmlPath;

        public BaseStage()
        {
            stageType = GetType();
            XmlPath = "Template/" + stageType.ToString().Replace("Battleships.Services.Stage.", "") + ".xml";
        }

        public virtual void LoadContent()
        {
            content = new ContentManager(GameStageManager.Instance.Content.ServiceProvider, "Content");

            if (File.Exists(XmlPath))
            {
                var xml = File.ReadAllText(XmlPath);
                var xmlSerializer = new XmlSerializer(typeof(UIScheme));
                var xmlReader = XmlReader.Create(new StringReader(xml));
                uiScheme = (UIScheme)xmlSerializer.Deserialize(xmlReader);
                /*
                using (TextReader reader = new StreamReader(XmlPath))
                {
                   var stage =(BaseStage)xmlDeserializer.Deserialize(reader);
                    stage.FromXml();
                    UIScheme = stage.UIScheme;//.FromXml()
                    //UIScheme = (BaseChildren)xmlDeserializer.Deserialize(reader);
                    //UIScheme = xmlDeserializer.ReadXml(reader);
                    //XmlStageDeserializer<Base> xml = new XmlStageDeserializer<Base>(Type);
                    //instance = (T)xml.Deserialize(reader);
                }*/
            }
        }

        public virtual void UnloadContent()
        {
            content.Unload();
        }

        public virtual void Update(GameTime gameTime)
        {
            //InputManager.Instance.Update();
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}
