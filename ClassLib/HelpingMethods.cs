using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    /// <summary>
    /// This partial class makes all "dirty work".
    /// Check for correctness, a lot of "prints" in console.
    /// </summary>
    public partial class HelpingMethods
    {
        internal static ConsoleKey consoleKey;

        internal static string file_path;

        internal static List<Hero> currentAppUsers;

        /// <summary>
        /// This method check for correctness user's input(actually - path for file) and allow record this path to static field in class (file_path).
        /// </summary>
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
        /// <summary>
        /// Check for correctness and return user's input.
        /// </summary>
        /// <returns>So useful ConsoleKey from user's input.</returns>
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
        /// <summary>
        /// Like...another version of ItemForSorting().
        /// Actually, this method has "Talking" name.
        /// </summary>
        /// <returns>So useful ConsoleKey from user's input.</returns>
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

        /// <summary>
        /// I told you, that this class makes all "dirty" work.
        /// </summary>
        /// <returns>So useful ConsoleKey from user's input.</returns>
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
        /// <summary>
        /// Useful class. It implements menu, that have 3 options: write data to console, write data to current file, write data to new file.
        /// </summary>
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
        /// <summary>
        /// Method check user's input for correctness and (by mod out) return it.
        /// </summary>
        /// <param name="n">Data for return</param>
        /// <param name="name">Type of data</param>
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
