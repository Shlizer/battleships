using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using System.Xml.Serialization;

namespace Battleships.Services.Stage.Helpers
{
    public class GameStageManager
    {
        private static GameStageManager instance;
        [XmlIgnore]
        public ContentManager Content;
        [XmlIgnore]
        public GraphicsDevice GraphicsDevice;
        [XmlIgnore]
        public SpriteBatch SpriteBatch;
        [XmlIgnore]
        public bool IsTransitioning { get; private set; }

        XmlStageManager<BaseStage> xmlStageManager;
        BaseStage currentScreen, newScreen;

        public static GameStageManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameStageManager();
                    //instance.xmlStageManager = new XmlStageManager();
                }

                return instance;
            }
        }

        private GameStageManager()
        {
            //currentScreen = xmlStageManager.Load("Load/SplashScreen.xml");
            //xmlStageManager = new XmlManager<BaseStage>();
            //xmlStageManager.Type = currentScreen.Type;
            //ChangeStage("Splash");
            //currentScreen = new Splash();
        }
        
        public void ChangeStage(string screenName)
        {
            if (currentScreen != null)
                currentScreen.UnloadContent();
            
            currentScreen = (BaseStage)Activator.CreateInstance(Type.GetType("Battleships.Services.Stage." + screenName));
            currentScreen.LoadContent();
        }

        public void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
            //Transition(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
            //if (IsTransitioning)
                //Image.Draw(spriteBatch);
        }
    }
}
