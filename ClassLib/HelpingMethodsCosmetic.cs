using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public partial class HelpingMethods
    {
        internal static void PrintWithColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        internal static void Welcoming()
        {
            PrintWithColor("Which field will be selectered: ", ConsoleColor.Yellow);
            SelectionSortingMenu();
            Console.CursorVisible = false;
        }

        internal static void SelectionSortingMenu()
        {
            Console.WriteLine("1. HeroId\n" +
                "2. HeroName\n" +
                "3. Fraction\n" +
                "4. Level\n" +
                "5. CastleLocation\n" +
                "6. Troops");
        }
    }
}
