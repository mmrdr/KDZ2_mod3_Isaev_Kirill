using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public partial class HelpingMethods
    {
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

        internal static ConsoleKey Item()
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
    }
}
