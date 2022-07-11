using System;
using System.IO;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;

// This config file does nothing, just dont want to delete it for some reason
namespace CMusicPlanet
{
    public static class Config
    {
        public static bool PlanetoidMusic = true;
        public static bool WyrmMusic = true;

        //The file will be stored in "Terraria/ModLoader/Mod Configs/Example Mod.json"
        static string ConfigPath = Path.Combine(Main.SavePath, "Mod Configs", "CMusicPlanet.json");

        static Preferences Configuration = new Preferences(ConfigPath);

        public static void Load()
        {
            //Reading the config file
            bool success = ReadConfig();

            if (!success)
            {
                ErrorLogger.Log("Failed to read Calamity Music: Planetoids & Abyss Miniboss's config file! Recreating config...");
                CreateConfig();
            }
        }

        //Returns "true" if the config file was found and successfully loaded.
        static bool ReadConfig()
        {
            if (Configuration.Load())
            {
                Configuration.Get("PlanetoidMusic", ref PlanetoidMusic);
                Configuration.Get("WyrmMusic", ref WyrmMusic);
                //We don't want Plantera to have negative HP :P
                return true;
            }
            return false;
        }

        //Creates a config file. This will only be called if the config file doesn't exist yet or it's invalid. 
        static void CreateConfig()
        {
            Configuration.Clear();
            Configuration.Put("PlanetoidMusic", PlanetoidMusic);
            Configuration.Put("WyrmMusic", WyrmMusic);
            Configuration.Save();
        }
    }

}