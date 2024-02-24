using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public partial class HelpingMethods
    {
        internal static ConsoleKey consoleKey;

        internal static string file_path;

        internal static List<Hero> currentAppUsers;

        internal static void GetFilePath()
        {
            Console.WriteLine("Input full path to file");
            string path = Console.ReadLine();
            while (!File.Exists(path) || String.IsNullOrEmpty(path) || path.IndexOfAny(Path.GetInvalidPathChars()) != -1)
            {
                PrintWithColor("Wrong file path, try again", ConsoleColor.Red);
                path = Console.ReadLine();
            }
            file_path = path;
        }

        internal static ConsoleKey ItemForSorting()
        {
            var key = Console.ReadKey().Key;
            while (key != ConsoleKey.D1 && key != ConsoleKey.D2 && key != ConsoleKey.D3 && key != ConsoleKey.D4
                && key != ConsoleKey.D5 && key != ConsoleKey.D6)
            {
                Console.WriteLine();
                PrintWithColor("Incorrect input, try again: ", ConsoleColor.Red);
                key = Console.ReadKey().Key;
            }
            return key;
        }

        internal static ConsoleKey ItemForChange()
        {
            var key = Console.ReadKey().Key;
            while (key != ConsoleKey.D1 && key != ConsoleKey.D2 && key != ConsoleKey.D3 && key != ConsoleKey.D4
                && key != ConsoleKey.D5)
            {
                Console.WriteLine();
                PrintWithColor("Incorrect input, try again: ", ConsoleColor.Red);
                key = Console.ReadKey().Key;
            }
            return key;
        }

        internal static ConsoleKey ItemForMenu()
        {
            var key = Console.ReadKey().Key;
            while (key != ConsoleKey.D1 && key != ConsoleKey.D2 && key != ConsoleKey.D3 && key != ConsoleKey.D4 && key != ConsoleKey.D5 && key != ConsoleKey.D6)
            {
                Console.WriteLine();
                PrintWithColor("Incorrect input, try again: ", ConsoleColor.Red);
                key = Console.ReadKey().Key;
            }
            consoleKey = key;
            return key;
        }

        internal static void WriteMenu()
        {
            Console.Clear();
            PrintWithColor("1. Write data to console\n" +
                "2. Write data to current file\n" +
                "3. Write data to new file", ConsoleColor.Yellow);
            switch (ItemForMenu())
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    foreach (var hero in currentAppUsers)
                    {
                        Console.WriteLine(hero.ToJson());
                    }
                    Thread.Sleep(10000);
                    Console.Clear();
                    PrintWithColor("Stop looking at me!", ConsoleColor.Red);
                    Thread.Sleep(1000);
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    DataProcessing.SerializeToJsonFile(currentAppUsers, file_path);
                    PrintWithColor("Data loaded!", ConsoleColor.Green);
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    GetFilePath();
                    DataProcessing.SerializeToJsonFile(currentAppUsers, file_path);
                    PrintWithColor("Data loaded!", ConsoleColor.Green);
                    break;
            }
        }

        internal static void GetNumber(out int n, string name)
        {
            Console.WriteLine($"Input amount of {name}");
            var answer = Console.ReadLine();
            while (answer == null || String.IsNullOrEmpty(answer) || !int.TryParse(answer, out n) || int.Parse(answer) > int.MaxValue || int.Parse(answer) < 0)
            {
                HelpingMethods.PrintWithColor("Incorrect input, try again", ConsoleColor.Red);
                answer = Console.ReadLine();
            }
        }
    }
}
