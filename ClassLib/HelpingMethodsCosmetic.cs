using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    /// <summary>
    /// Another part of partial class "HelpingMethods"
    /// Only cosmetic methods(I mean, a lot of "print" in console).
    /// </summary>
    public partial class HelpingMethods
    {
        /// <summary>
        /// This method makes text more beauty.
        /// </summary>
        /// <param name="text">This text will be modified</param>
        /// <param name="color">Text will be decorated by this color</param>
        internal static void PrintWithColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        internal static void WelcomingForSorting()
        {
            PrintWithColor("Which field should I sort by: ", ConsoleColor.Yellow);
            SortingMenu();
            Console.CursorVisible = false;        
        }

        internal static void SortingMenu()
        {
            Console.WriteLine("1. HeroId\n" +
                "2. HeroName\n" +
                "3. Faction\n" +
                "4. Level\n" +
                "5. CastleLocation\n" +
                "6. Troops");
        }

        internal static void ChangeMenu()
        {
            PrintWithColor("What property should I change?", ConsoleColor.Yellow);
            Console.WriteLine("1. HeroName\n" +
                "2. Faction\n" +
                "3. Level\n" +
                "4. CastleLocation\n" +
                "5. Troops");
        }

        internal static void ShowMenu()
        {
            PrintWithColor("1. Change file path\n" +
                "2. Write data\n" +
                "3. Perform Sorting\n" +
                "4. Change json object\n" +
                "5. Create your own json file(input data manually)\n" +
                "6. Exit", ConsoleColor.Yellow);
        }
    }
}
