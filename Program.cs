using System;
using System.IO;
using System.Threading;

namespace TextBasedGame
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var gameLoaded = AskNewOrLoad();
            var game = new Game();
            game.StartGame(gameLoaded);
        }

        public static GameState AskNewOrLoad()
        {
            do
            {
                Console.WriteLine("Start a new game or load a save file:");
                Console.WriteLine("1: Start a new game.");
                Console.WriteLine("2: Load save file.");
                var choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine("Are you sure you want to start a new game? (Previous save files will be deleted)");
                    Console.WriteLine("1: Yes");
                    Console.WriteLine("2: No");
                    string confirmation = Console.ReadLine();
                    switch (confirmation)
                    {
                        case "1":
                            Console.WriteLine("Starting a new game...");
                            Thread.Sleep(1500);
                            Console.WriteLine("Your choices will affect the game's story line, so be careful.");
                            Thread.Sleep(1500);
                            Console.WriteLine("The game will save after each chapter. Do not quit in the middle of the chapter or all of your progress will get deleted. The command prompt will notify you when the game is saved.");
                            Thread.Sleep(1500);
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            SavingAndLoading.ClearSaveFile();
                            return new GameState();

                        case "2":
                            break;

                        default:
                            Console.WriteLine("Invalid input. Try again.");
                            break;
                    }
                }
                else if (new FileInfo("savestate.json").Length > 0 && choice == "2")
                {
                    return SavingAndLoading.Load();
                }
                else if (new FileInfo("savestate.json").Length == 0)
                {
                    Console.WriteLine("Save file is empty");
                    Console.WriteLine("Starting a new game...");
                    return new GameState();
                }
                else
                {
                    Console.WriteLine("Invalid input, try again.");
                }
            } while (true);
        }
    }
}