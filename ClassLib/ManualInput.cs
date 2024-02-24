using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class ManualInput
    {
        private static List<Hero> heroes;

        private static int currentHeroPos;

        private static int currentUnitPos;

        private static string BeautyMenuForHero()
        {
            string[] menuItems = { "1. Hero Id\n", "2. Hero Name\n", "3. Fraction\n", "4. Level\n", "5. Castle Location\n", "6. Troops\n", "7. Units\n" };
            int selectedItemIndex = 0;
            Console.CursorVisible = false;
            while (true)
            {
                Console.Clear();
                HelpingMethods.PrintWithColor("Choose field to fill\n", ConsoleColor.Green);
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (i == selectedItemIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(menuItems[i]);
                    Console.ResetColor();
                }
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.UpArrow)
                {
                    selectedItemIndex = (selectedItemIndex - 1 + menuItems.Length) % menuItems.Length;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedItemIndex = (selectedItemIndex + 1) % menuItems.Length;
                }
                else if (key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    HelpingMethods.PrintWithColor("Choose field to fill\n", ConsoleColor.Green);
                    for (int i = 0; i < menuItems.Length; i++)
                    {
                        if (i == selectedItemIndex)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        Console.WriteLine(menuItems[i]);
                        Console.ResetColor();
                    }
                    HelpingMethods.PrintWithColor("\nSelected: " + menuItems[selectedItemIndex], ConsoleColor.Green);
                    return menuItems[selectedItemIndex];
                }
            }
        }

        private static string BeautyMenuForUnit()
        {
            string[] menuItems = { "1. Unit Name\n", "2. Quantity\n", "3. Experience\n", "4. Current Location\n" };
            int selectedItemIndex = 0;
            Console.CursorVisible = false;
            while (true)
            {
                Console.Clear();
                HelpingMethods.PrintWithColor("Choose field to fill\n", ConsoleColor.Green);
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (i == selectedItemIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(menuItems[i]);
                    Console.ResetColor();
                }
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.UpArrow)
                {
                    selectedItemIndex = (selectedItemIndex - 1 + menuItems.Length) % menuItems.Length;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedItemIndex = (selectedItemIndex + 1) % menuItems.Length;
                }
                else if (key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    HelpingMethods.PrintWithColor("Choose field to fill\n", ConsoleColor.Green);
                    for (int i = 0; i < menuItems.Length; i++)
                    {
                        if (i == selectedItemIndex)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        Console.WriteLine(menuItems[i]);
                        Console.ResetColor();
                    }
                    HelpingMethods.PrintWithColor("\nSelected: " + menuItems[selectedItemIndex], ConsoleColor.Green);
                    return menuItems[selectedItemIndex];
                }
            }
        }

        private static void Statistics(string pressed, List<string> isPressed, int number)
        {
            Console.Clear();
            for (int i = 0; i < isPressed.Count; i++)
            {
                if (isPressed[i].Equals(pressed)) isPressed.RemoveAt(i);
            }
            HelpingMethods.PrintWithColor($"Hero number: {currentHeroPos}\n" +
                $"Need to fill: {number}",ConsoleColor.Green);
            if (isPressed.Count != 0)
            {
                HelpingMethods.PrintWithColor("You dont fill", ConsoleColor.Red);
                Console.WriteLine("================");
                foreach (var pressedField in isPressed)
                {
                    Console.WriteLine(pressedField);
                }
                Console.WriteLine("================");
            }
            else HelpingMethods.PrintWithColor("You fill all fields", ConsoleColor.Yellow);
        }

        private static void StatisticsForUnit(string pressed, List<string> unitIsPressed, int number)
        {
            Console.Clear();
            for (int i = 0; i < unitIsPressed.Count; i++)
            {
                if (unitIsPressed[i].Equals(pressed)) unitIsPressed.RemoveAt(i);
            }
            HelpingMethods.PrintWithColor($"Unit number: {currentUnitPos}\n" +
                $"Need to fill: {number}",ConsoleColor.Green);
            if (unitIsPressed.Count != 0)
            {
                HelpingMethods.PrintWithColor("You dont fill", ConsoleColor.Red);
                Console.WriteLine("================");
                foreach (var pressedField in unitIsPressed)
                {
                    Console.WriteLine(pressedField);
                }
                Console.WriteLine("================");
            }
            else HelpingMethods.PrintWithColor("You fill all fields", ConsoleColor.Yellow);
        }

        private static void FillUnit(int unitCount)
        {
            currentUnitPos = 0;
            for (int currentUnit = 0; currentUnit < unitCount; currentUnit++)
            {
                currentUnitPos++;
                try
                {
                    List<string> unitIsPressed = new List<string> { "Unit Name", "Quantity", "Experience", "Current Location" };

                    heroes[heroes.Count - 1].Units.Add(new Units());
                    heroes[heroes.Count - 1].Units[currentUnit].Quantity = -1;
                    heroes[heroes.Count - 1].Units[currentUnit].Experience = -1;
                    while (heroes[heroes.Count - 1].Units[currentUnit].Quantity == -1 || heroes[heroes.Count - 1].Units[currentUnit].Experience == -1 ||
                        heroes[heroes.Count - 1].Units[currentUnit].UnitName == null || heroes[heroes.Count - 1].Units[currentUnit].CurrentLocation == null)
                    {
                        var choosenField = BeautyMenuForUnit();
                        Thread.Sleep(1000);
                        switch (choosenField)
                        {
                            case "1. Unit Name\n":
                                Console.Clear();
                                HelpingMethods.PrintWithColor("Input unit name", ConsoleColor.Yellow);
                                var name = Console.ReadLine();
                                while (name == null || String.IsNullOrEmpty(name))
                                {
                                    HelpingMethods.PrintWithColor("Incorrect input, try again", ConsoleColor.Red);
                                    name = Console.ReadLine();
                                }
                                heroes[heroes.Count - 1].Units[currentUnit].UnitName = name;
                                StatisticsForUnit("Unit Name", unitIsPressed, unitCount);
                                Thread.Sleep(2000);
                                break;
                            case "2. Quantity\n":
                                Console.Clear();
                                HelpingMethods.PrintWithColor("Input quantity", ConsoleColor.Yellow);
                                var quantity = Console.ReadLine();
                                while (quantity == null || String.IsNullOrEmpty(quantity) || !int.TryParse(quantity, out int x)
                                    || int.Parse(quantity) > int.MaxValue || int.Parse(quantity) < 0)
                                {
                                    HelpingMethods.PrintWithColor("Incorrect input, try again", ConsoleColor.Red);
                                    quantity = Console.ReadLine();
                                }
                                heroes[heroes.Count - 1].Units[currentUnit].Quantity = int.Parse(quantity);
                                StatisticsForUnit("Quantity", unitIsPressed, unitCount);
                                Thread.Sleep(2000);
                                break;
                            case "3. Experience\n":
                                Console.Clear();
                                HelpingMethods.PrintWithColor("Input experience", ConsoleColor.Yellow);
                                var experience = Console.ReadLine();
                                while (experience == null || String.IsNullOrEmpty(experience) || !int.TryParse(experience, out int x)
                                    || int.Parse(experience) > int.MaxValue || int.Parse(experience) < 0)
                                {
                                    HelpingMethods.PrintWithColor("Incorrect input, try again", ConsoleColor.Red);
                                    experience = Console.ReadLine();
                                }
                                heroes[heroes.Count - 1].Units[currentUnit].Experience = int.Parse(experience);
                                StatisticsForUnit("Experience", unitIsPressed, unitCount);
                                Thread.Sleep(2000);
                                break;
                            case "4. Current Location\n":
                                Console.Clear();
                                HelpingMethods.PrintWithColor("Input unit's current location", ConsoleColor.Yellow);
                                var currentLocation = Console.ReadLine();
                                while (currentLocation == null || String.IsNullOrEmpty(currentLocation))
                                {
                                    HelpingMethods.PrintWithColor("Incorrect input, try again", ConsoleColor.Red);
                                    currentLocation = Console.ReadLine();
                                }
                                heroes[heroes.Count - 1].Units[currentUnit].CurrentLocation = currentLocation;
                                StatisticsForUnit("Current Location", unitIsPressed, unitCount);
                                Thread.Sleep(2000);
                                break;
                            default:
                                HelpingMethods.PrintWithColor("Incorrect input, try again", ConsoleColor.Red);
                                break;
                        }
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    HelpingMethods.PrintWithColor(ex.Message, ConsoleColor.Red);
                }
                catch (StackOverflowException ex)
                {
                    HelpingMethods.PrintWithColor(ex.Message, ConsoleColor.Red);
                }
                catch(Exception ex)
                {
                    HelpingMethods.PrintWithColor(ex.Message,ConsoleColor.Red);
                }
            } 
        }

        public static void FillJson(int heroCount)
        {
            currentHeroPos = 0;
            heroes = new List<Hero>();
            for (int currentHero = 0; currentHero < heroCount; currentHero++)
            {
                currentHeroPos++;
                try
                {
                    List<string> isPressed = new List<string> {  "Hero Id", "Hero Name", "Fraction", "Level",
                        "Castle Location", "Troops", "Units"};

                    heroes.Add(new Hero());
                    heroes[currentHero].Level = -1;
                    heroes[currentHero].Troops = -1;
                    bool IsUnitPressed = false;
                    while (heroes[currentHero].HeroId == null || heroes[currentHero].HeroName == null || heroes[currentHero].Fraction == null ||
                        heroes[currentHero].Level == -1 || heroes[currentHero].CastleLocation == null || heroes[currentHero].Troops == -1
                        || IsUnitPressed == false)
                    {
                        var choosenField = BeautyMenuForHero();
                        Thread.Sleep(1000);
                        switch (choosenField)
                        {
                            case "1. Hero Id\n":
                                Console.Clear();
                                HelpingMethods.PrintWithColor("Input id for hero", ConsoleColor.Yellow);
                                var id = Console.ReadLine();
                                while (id == null || String.IsNullOrEmpty(id))
                                {
                                    HelpingMethods.PrintWithColor("Incorrect input, try again", ConsoleColor.Red);
                                    id = Console.ReadLine();
                                }
                                heroes[currentHero].HeroId = id;
                                Statistics("Hero Id", isPressed, heroCount);
                                Thread.Sleep(2000);
                                break;
                            case "2. Hero Name\n":
                                Console.Clear();
                                HelpingMethods.PrintWithColor("Input name for hero", ConsoleColor.Yellow);
                                var name = Console.ReadLine();
                                while (name == null || String.IsNullOrEmpty(name))
                                {
                                    HelpingMethods.PrintWithColor("Incorrect input, try again", ConsoleColor.Red);
                                    name = Console.ReadLine();
                                }
                                heroes[currentHero].HeroName = name;
                                Statistics("Hero Name", isPressed, heroCount);
                                Thread.Sleep(2000);
                                break;
                            case "3. Fraction\n":
                                Console.Clear();
                                HelpingMethods.PrintWithColor("Input hero's fraction", ConsoleColor.Yellow);
                                var fraction = Console.ReadLine();
                                while (fraction == null || String.IsNullOrEmpty(fraction))
                                {
                                    HelpingMethods.PrintWithColor("Incorrect input, try again", ConsoleColor.Red);
                                    fraction = Console.ReadLine();
                                }
                                heroes[currentHero].Fraction = fraction;
                                Statistics("Fraction", isPressed, heroCount);
                                Thread.Sleep(2000);
                                break;
                            case "4. Level\n":
                                Console.Clear();
                                HelpingMethods.PrintWithColor("Input hero's level", ConsoleColor.Yellow);
                                var level = Console.ReadLine();
                                while (level == null || String.IsNullOrEmpty(level) || !int.TryParse(level, out int x)
                                    || int.Parse(level) > int.MaxValue || int.Parse(level) < 0)
                                {
                                    HelpingMethods.PrintWithColor("Incorrect input, try again", ConsoleColor.Red);
                                    level = Console.ReadLine();
                                }
                                heroes[currentHero].Level = int.Parse(level);
                                Statistics("Level", isPressed, heroCount);
                                Thread.Sleep(2000);
                                break;
                            case "5. Castle Location\n":
                                Console.Clear();
                                HelpingMethods.PrintWithColor("Input hero's castle location", ConsoleColor.Yellow);
                                var castleLocation = Console.ReadLine();
                                while (castleLocation == null || String.IsNullOrEmpty(castleLocation))
                                {
                                    HelpingMethods.PrintWithColor("Incorrect input, try again", ConsoleColor.Red);
                                    castleLocation = Console.ReadLine();
                                }
                                heroes[currentHero].CastleLocation = castleLocation;
                                Statistics("Castle Location", isPressed, heroCount);
                                Thread.Sleep(2000);
                                break;
                            case "6. Troops\n":
                                Console.Clear();
                                HelpingMethods.PrintWithColor("Input amount of troops", ConsoleColor.Yellow);
                                var troops = Console.ReadLine();
                                while (troops == null || String.IsNullOrEmpty(troops) || !int.TryParse(troops, out int x)
                                    || int.Parse(troops) > int.MaxValue || int.Parse(troops) < 0)
                                {
                                    HelpingMethods.PrintWithColor("Incorrect input, try again", ConsoleColor.Red);
                                    troops = Console.ReadLine();
                                }
                                heroes[currentHero].Troops = int.Parse(troops);
                                Statistics("Troops", isPressed, heroCount);
                                Thread.Sleep(2000);
                                break;
                            case "7. Units\n":
                                Console.Clear();
                                IsUnitPressed = true;
                                int amount;
                                HelpingMethods.GetNumber(out amount, "units");
                                FillUnit(amount);
                                Statistics("Units", isPressed, heroCount);
                                break;
                            default:
                                HelpingMethods.PrintWithColor("Incorrect input, try again", ConsoleColor.Red);
                                break;
                        }
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    HelpingMethods.PrintWithColor(ex.Message, ConsoleColor.Red);
                }
                catch (StackOverflowException ex)
                {
                    HelpingMethods.PrintWithColor(ex.Message, ConsoleColor.Red);
                }
                catch (Exception ex)
                {
                    HelpingMethods.PrintWithColor(ex.Message, ConsoleColor.Red);
                }
            }
            HelpingMethods.currentAppUsers = heroes;
        }      
    }
}
