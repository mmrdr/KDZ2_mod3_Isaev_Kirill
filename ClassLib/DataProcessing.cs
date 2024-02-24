using System.Text.Json;

namespace ClassLib
{
    /// <summary>
    /// This class implements all hard work with data.
    /// </summary>
    public class DataProcessing
    {
        public static List<Hero> SelectedHeroes;

        /// <summary>
        /// This method serialize data to some file.
        /// </summary>
        /// <param name="heroes">This is list, that gives method data to serialize it to the file.</param>
        /// <param name="filePath">This path refer to file, that will take data from method.</param>
        public static void SerializeToJsonFile(List<Hero> heroes, string filePath)
        {
            var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(heroes, jsonOptions);
            File.WriteAllText(filePath, json);
        }
        /// <summary>
        /// This method deserialize data from json file to C# object(Hero,Units).
        /// </summary>
        /// <param name="filePath">This path refer to file, that will gives data to this method.</param>
        /// <returns>List with json's data.</returns>
        public static List<Hero> DeserializeFromJsonFile(string filePath)
        {
            string json = File.ReadAllText(filePath);
            var heroesFromJson = JsonSerializer.Deserialize<List<Hero>>(json);
            HelpingMethods.currentAppUsers = heroesFromJson;
            return heroesFromJson;
        }
        /// <summary>
        /// This method will sort objects in list with data.
        /// </summary>
        /// <returns>Sorted list(by any choosen field).</returns>
        public static List<Hero> Sorting()
        {
            if (HelpingMethods.currentAppUsers == null)
            {
                HelpingMethods.PrintWithColor("No data error, try again", ConsoleColor.Red);
                return new List<Hero>(0);
            }
            HelpingMethods.WelcomingForSorting(); 
            var tempSelectedUsers = new Hero[HelpingMethods.currentAppUsers.Count()];
            switch (HelpingMethods.ItemForSorting()) // Pretty simple, if user press 1 - will sort by 1st field...And that's all.
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    HelpingMethods.currentAppUsers.CopyTo(tempSelectedUsers, 0);
                    tempSelectedUsers = tempSelectedUsers.OrderBy(x => x.HeroId).ToArray();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    HelpingMethods.currentAppUsers.CopyTo(tempSelectedUsers, 0);
                    tempSelectedUsers = tempSelectedUsers.OrderBy(x => x.HeroName).ToArray();
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    HelpingMethods.currentAppUsers.CopyTo(tempSelectedUsers, 0);
                    tempSelectedUsers = tempSelectedUsers.OrderBy(x => x.Fraction).ToArray();
                    break;
                case ConsoleKey.D4:
                    Console.Clear();
                    HelpingMethods.currentAppUsers.CopyTo(tempSelectedUsers, 0);
                    tempSelectedUsers = tempSelectedUsers.OrderBy(x => x.Level).ToArray();
                    break;
                case ConsoleKey.D5:
                    Console.Clear();
                    HelpingMethods.currentAppUsers.CopyTo(tempSelectedUsers, 0);
                    tempSelectedUsers = tempSelectedUsers.OrderBy(x => x.CastleLocation).ToArray();
                    break;
                case ConsoleKey.D6:
                    Console.Clear();
                    HelpingMethods.currentAppUsers.CopyTo(tempSelectedUsers, 0);
                    tempSelectedUsers = tempSelectedUsers.OrderBy(x => x.Troops).ToArray();
                    break;
            }
            SelectedHeroes = new List<Hero>(tempSelectedUsers.Length);
            foreach (var user in tempSelectedUsers)
            {
                SelectedHeroes.Add(user);
            }
            HelpingMethods.currentAppUsers = SelectedHeroes;
            return SelectedHeroes;
        }
        /// <summary>
        /// This beauty method allow user to change hero's data manually.
        /// </summary>
        /// <returns>List with some changed data.</returns>
        public static List<Hero> ChangeHero()
        {
            if (HelpingMethods.currentAppUsers == null)
            {
                HelpingMethods.PrintWithColor("No data error, try again", ConsoleColor.Red);
                return new List<Hero>(0);
            }
            HelpingMethods.PrintWithColor("Which hero I should edit?\n" +
                "Please, input hero number: ", ConsoleColor.Yellow);
            var id = Console.ReadLine();
            while (id == null || String.IsNullOrEmpty(id) || !int.TryParse(id, out int x) 
                || int.Parse(id) >= HelpingMethods.currentAppUsers.Count() || int.Parse(id) < 0)
            {
                HelpingMethods.PrintWithColor("There is no hero with this number, try again", ConsoleColor.Red);
                id = Console.ReadLine();
            }
            var tempSelectedUsers = new Hero[HelpingMethods.currentAppUsers.Count()];
            HelpingMethods.ChangeMenu();
            switch (HelpingMethods.ItemForChange()) // Ok, that works the same, like in Sorting() method.
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    HelpingMethods.currentAppUsers.CopyTo(tempSelectedUsers, 0);
                    Console.WriteLine($"Input new data for heroName");
                    var heroNameData = Console.ReadLine();
                    while (heroNameData == null || String.IsNullOrEmpty(heroNameData))
                    {
                        HelpingMethods.PrintWithColor("Incorrect input, try again: ", ConsoleColor.Red);
                        heroNameData = Console.ReadLine();
                    }
                    tempSelectedUsers[int.Parse(id)].HeroName = heroNameData;
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    HelpingMethods.currentAppUsers.CopyTo(tempSelectedUsers, 0);
                    Console.WriteLine($"Input new data for fraction");
                    var fractionData = Console.ReadLine();
                    while (fractionData == null || String.IsNullOrEmpty(fractionData))
                    {
                        HelpingMethods.PrintWithColor("Incorrect input, try again: ", ConsoleColor.Red);
                        fractionData = Console.ReadLine();
                    }
                    tempSelectedUsers[int.Parse(id)].Fraction = fractionData;
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    HelpingMethods.currentAppUsers.CopyTo(tempSelectedUsers, 0);
                    Console.WriteLine($"Input new data for level");
                    var levelData = Console.ReadLine();
                    while (levelData == null || String.IsNullOrEmpty(levelData) || !int.TryParse(levelData, out int x)
                        || int.Parse(levelData) > int.MaxValue || int.Parse(levelData) < 0)
                    {
                        HelpingMethods.PrintWithColor("Incorrect input, try again: ", ConsoleColor.Red);
                        levelData = Console.ReadLine();
                    }
                    tempSelectedUsers[int.Parse(id)].Level = int.Parse(levelData);
                    break;
                case ConsoleKey.D4:
                    Console.Clear();
                    HelpingMethods.currentAppUsers.CopyTo(tempSelectedUsers, 0);
                    Console.WriteLine($"Input new data for castleLocation");
                    var castleLocationData = Console.ReadLine();
                    while (castleLocationData == null || String.IsNullOrEmpty(castleLocationData))
                    {
                        HelpingMethods.PrintWithColor("Incorrect input, try again: ", ConsoleColor.Red);
                        castleLocationData = Console.ReadLine();
                    }
                    tempSelectedUsers[int.Parse(id)].CastleLocation = castleLocationData;
                    break;
                case ConsoleKey.D5:
                    Console.Clear();
                    HelpingMethods.currentAppUsers.CopyTo(tempSelectedUsers, 0);
                    Console.WriteLine($"Input new data for troops");
                    var troopsData = Console.ReadLine();
                    while (troopsData == null || String.IsNullOrEmpty(troopsData) || !int.TryParse(troopsData, out int x)
                        || int.Parse(troopsData) > int.MaxValue || int.Parse(troopsData) < 0)
                    {
                        HelpingMethods.PrintWithColor("Incorrect input, try again: ", ConsoleColor.Red);
                        troopsData = Console.ReadLine();
                    }
                    tempSelectedUsers[int.Parse(id)].Troops = int.Parse(troopsData);
                    break;
            }
            SelectedHeroes = new List<Hero>(tempSelectedUsers.Length);
            foreach (var user in tempSelectedUsers)
            {
                SelectedHeroes.Add(user);
            }
            HelpingMethods.currentAppUsers = SelectedHeroes;
            return SelectedHeroes;
        }
    }
}
