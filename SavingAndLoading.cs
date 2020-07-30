using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Threading;

namespace TextBasedGame
{
    internal static class SavingAndLoading
    {
        private const string jsonFile = "savestate.json";

        public static void Save(GameState savedGame)
        {
            string json = JsonConvert.SerializeObject(savedGame, Formatting.Indented);
            File.WriteAllText(jsonFile, json);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Game has been saved.");
            Thread.Sleep(3000);
            Console.ResetColor();
        }

        public static GameState Load()
        {
            string jsonRead = File.ReadAllText(jsonFile);
            return JsonConvert.DeserializeObject<GameState>(jsonRead);
        }

        public static void ClearSaveFile()
        {
            File.WriteAllText("savestate.json", string.Empty);
        }
    }
}