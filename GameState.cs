using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace TextBasedGame
{
    internal class GameState
    {
        public string Gender { get; set; }
        public string GenderNoun { get; set; }

        public string ProtagonistName { get; set; }

        public List<string> Inputs { get; set; }

        public List<string> Questions { get; set; }

        public List<string> Inventory { get; set; }

        // private const string questionsFile = "questionFile.json";

        public GameState()
        {
            Inputs = new List<string>();
            Inventory = new List<string>();
            /**Questions = new List<string>() { "Enter your gender please:", "Please enter your name:", "1: Yes, I am... \n2: Not really..." };
            string json = JsonConvert.SerializeObject(Questions, Formatting.Indented);
            File.WriteAllText(questionsFile, json);**/
        }
    }
}