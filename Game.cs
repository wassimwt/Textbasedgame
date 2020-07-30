using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Threading;

namespace TextBasedGame
{
    internal class Game
    {
        private static bool Correct = false;
        private string input = "";

        public void StartGame(GameState data)
        {
            #region Chapter1

            while (Correct == false)
            {
                Correct = true;

                Console.Clear();

                Console.WriteLine("Enter your gender please:");

                CheckSaves(data, 1, ref input);

                switch (input)
                {
                    case "MALE":
                        data.Gender = "Male";
                        data.GenderNoun = "Boy";
                        break;

                    case "FEMALE":
                        data.Gender = "Female";
                        data.GenderNoun = "Girl";
                        break;

                    case "I":
                        ShowInventory(data);
                        break;

                    default:
                        Console.WriteLine("Invalid input, try again.");
                        Correct = false;
                        Thread.Sleep(2000);
                        break;
                }
            }

            data.Inputs.Add(input);

            Correct = false;

            string name = "";

            if (data.ProtagonistName == null)
            {
                Console.WriteLine("Please enter your name:");
                name = Console.ReadLine();
                data.ProtagonistName = name;
            }
            else
            {
                name = data.ProtagonistName;
            }

            Console.WriteLine($"You're a 16 year old {data.GenderNoun} living in a quiet little town with your family. ");
            Thread.Sleep(500);
            Console.WriteLine("You go to a small high school a couple of minutes far from your house. ");
            Console.WriteLine("Tomorrow is the first day of school. You haven't met your friends for a long time.");
            Console.WriteLine("You're excited to see them and have fun with them. ");
            Thread.Sleep(500);
            Console.WriteLine("But what you don't know is that this year is going to be a lot different from the others...");

            Console.WriteLine("===========================================================================================");
            Thread.Sleep(500);

            Console.WriteLine("You woke up early, took a shower and got dressed then you headed to the living room to have breakfast");
            Thread.Sleep(500);
            Console.WriteLine($"Mom: Good morning {data.ProtagonistName}, I didn't need to come wake you up this time, ");
            Console.WriteLine("it seems like you're quite excited to go back to school huh?");
            Thread.Sleep(500);

            while (Correct == false)
            {
                NoStoryText("1: Yes, I am...");

                NoStoryText("2: Not really...");

                Correct = true;

                CheckSaves(data, 2, ref input);

                switch (input)
                {
                    case "1":
                        PlayerText($"{data.ProtagonistName}: Yes! I can't wait to meet my friends again I missed them a lot.");

                        Thread.Sleep(500);
                        Console.WriteLine("Mom: I'm sure they missed you too.");
                        Thread.Sleep(500);
                        break;

                    case "2":
                        PlayerText($"{data.ProtagonistName}:Not really, I just got bored sitting home all day for like 5 months because of the virus, so maybe school will be interesting? I don't know.");

                        Thread.Sleep(500);
                        Console.WriteLine("Mom: You will have a blast with your friends, I'm sure they missed you.");
                        Thread.Sleep(500);
                        break;

                    case "I":
                        ShowInventory(data);
                        break;

                    default:
                        Console.WriteLine("Invalid input, try again.");
                        Correct = false;
                        Thread.Sleep(1000);
                        break;
                }
            }

            data.Inputs.Add(input);

            Correct = false;

            Console.WriteLine("Mom: Now now, it's getting late, you better get going.");

            Console.WriteLine($"{data.ProtagonistName}: Yeah, you're right. Imma just grab my phone and head out.");

            NoStoryText("You picked up your phone.");
            data.Inventory.Add("Phone");
            Thread.Sleep(2000);

            Console.WriteLine("This is the end of chapter 1");

            SavingAndLoading.Save(data);

            Console.WriteLine("============================");

            #endregion Chapter1

            Chapter2(data);
        }

        #region Chapter2

        public void Chapter2(GameState data)
        {
            Console.WriteLine("You got outside, smelled the fresh air of the morning and headed to your high school.");
            PlayerText($"{data.ProtagonistName}: I'll just take the usual route, it's always empty and calm.");
            Console.WriteLine("Although your mom used to always warn you not to use that route because it's dangerously deserted you still prefer it and it never got you in trouble for years");
            Console.WriteLine("But today something unusual happened, you felt someone following you.");
            Console.WriteLine("You looked behind");
            PlayerText("Huh?");
            Console.WriteLine("You saw the shadow of someone quickly hastily hide behind a wall");

            while (Correct == false)
            {
                NoStoryText("1: Shout at them (Careful)");
                NoStoryText("2: Try to jumpscare them (Confident)");

                Correct = true;

                CheckSaves(data, 3, ref input);

                switch (input)
                {
                    case "1":
                        PlayerText($"{data.ProtagonistName}: HEY! WHO's THERE?");
                        Console.WriteLine("The person slowly came out from hiding");
                        BestFriendText("Random girl: Don't worry it's just me >.>");
                        break;

                    case "2":
                        Console.WriteLine("You slowly approached the wall that they were hiding behind and...");
                        PlayerText($"{data.ProtagonistName}: Boo!");
                        BestFriendText("Random girl: AAH! Jesus, you scared the shit out of me");
                        break;

                    case "I":
                        ShowInventory(data);
                        break;

                    default:
                        Console.WriteLine("Invalid input, try again.");
                        Correct = false;
                        Thread.Sleep(500);
                        break;
                }
            }

            Correct = false;

            Console.WriteLine("It's a short, dark haired girl that looks about your age.");
            BestFriendText("Random girl: Uhm... Hi?");
        }

        #endregion Chapter2

        private static void NoStoryText(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private static void PlayerText(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private static void BestFriendText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private static void CheckSaves(GameState data, int i, ref string input)
        {
            if (data.Inputs.Count < i)
            {
                input = Console.ReadLine().ToUpper();
            }
            else
            {
                input = data.Inputs[i - 1];
            }
        }

        private static void ShowInventory(GameState data)
        {
            if (data.Inventory.Count > 0)
            {
                int i = 1;
                foreach (string item in data.Inventory)
                {
                    Console.WriteLine($"{i}- {item}");
                    i++;
                }
            }
            else
            {
                Console.WriteLine("Your inventory is empty.");
                Thread.Sleep(1000);
                Console.WriteLine("Press a key to continue");
                Console.ReadKey();
            }

            Correct = false;
        }
    }
}