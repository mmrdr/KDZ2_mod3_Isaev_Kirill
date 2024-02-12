using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    internal class DataProcessing
    {
        internal static List<Hero> SelectedHeroes;

        public static List<Hero> Sorting()
        {
            if (HelpingMethods.currentAppUsers == null)
            {
                HelpingMethods.PrintWithColor("No data error, try again", ConsoleColor.Red);
                return new List<Hero>(0);
            }
            HelpingMethods.Welcoming(); 
            var tempSelectedUsers = new Hero[HelpingMethods.currentAppUsers.Count()];
            switch (HelpingMethods.Item())
            {
                case ConsoleKey.D1:
                    HelpingMethods.currentAppUsers.CopyTo(tempSelectedUsers, 0);
                    tempSelectedUsers = tempSelectedUsers.OrderBy(x => x.HeroId).ToArray();
                    break;
                case ConsoleKey.D2:
                    HelpingMethods.currentAppUsers.CopyTo(tempSelectedUsers, 0);
                    tempSelectedUsers = tempSelectedUsers.OrderBy(x => x.HeroName).ToArray();
                    break;
                case ConsoleKey.D3:
                    HelpingMethods.currentAppUsers.CopyTo(tempSelectedUsers, 0);
                    tempSelectedUsers = tempSelectedUsers.OrderBy(x => x.Fraction).ToArray();
                    break;
                case ConsoleKey.D4:
                    HelpingMethods.currentAppUsers.CopyTo(tempSelectedUsers, 0);
                    tempSelectedUsers = tempSelectedUsers.OrderBy(x => x.Level).ToArray();
                    break;
                case ConsoleKey.D5:
                    HelpingMethods.currentAppUsers.CopyTo(tempSelectedUsers, 0);
                    tempSelectedUsers = tempSelectedUsers.OrderBy(x => x.CastleLocation).ToArray();
                    break;
                case ConsoleKey.D6:
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
    }
}
