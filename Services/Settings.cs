using System;
using System.IO;
using System.Reflection;

namespace Battleships.Services
{
    public static class Settings
    {
        // Gfx
        public static int GfxResolutionW = 1024;
        public static int GfxResolutionH = 800;
        public static bool GfxFullscreen = true;
        public static int GfxSplashTime = 2;

        // Debug
        public static bool DebugShow = false;

        // Load settings from file
        public static void LoadSettings()
        {
            string fileName = Environment.CurrentDirectory + Path.DirectorySeparatorChar + "config.cfg";
            if (File.Exists(fileName))
            {
                string[] configLines = File.ReadAllLines(@fileName);
                Type className = typeof(Settings);

                foreach (string configLine in configLines)
                {
                    string[] line= configLine.Split('=');
                    FieldInfo property = className.GetField(line[0]);
                    if (property != null)
                    {
                        switch (property.FieldType.ToString())
                        {
                            case "System.Int32":
                                property.SetValue(null, Int32.Parse(line[1]));
                                break;
                            case "System.Boolean":
                                property.SetValue(null, Boolean.Parse(line[1]));
                                break;
                            default:
                                throw new Exception(property.FieldType.ToString());
                        }
                    }
                }
            }
        }
    }
}
