namespace ClassLib
{
    /// <summary>
    /// This class implements user interaction.
    /// </summary>
    public class ConsoleMenu
    {
        /// <summary>
        /// Second start point at this program.
        /// </summary>
        public static void StartComputer()
        {
            HelpingMethods.PrintWithColor("Press SPACEBAR to start app", ConsoleColor.Yellow);
            var startButton = Console.ReadKey().Key;
            if (startButton == ConsoleKey.Spacebar)
            {
                Console.Clear();
                BeginAction();
            }
            else
            {
                Console.Clear();
                HelpingMethods.PrintWithColor("Bye...bye", ConsoleColor.Red);
                Thread.Sleep(2000);
                Console.Clear();
            }
        }

        /// <summary>
        /// This method gives a choice of action.
        /// </summary>
        private static void BeginAction()
        {
            HelpingMethods.PrintWithColor("The first of all - input path to json file", ConsoleColor.Yellow);
            HelpingMethods.GetFilePath(); // Need to take some data from somewhere.
            DataProcessing.DeserializeFromJsonFile(HelpingMethods.file_path);
            HelpingMethods.PrintWithColor("Data loaded", ConsoleColor.Green);
            Thread.Sleep(2000);            
            do // Actually, its pretty simple, user will press action's buttons, when he pressed 6, program will stop. 
            {
                Console.Clear();
                HelpingMethods.ShowMenu();
                Console.CursorVisible = false;
                switch (HelpingMethods.ItemForMenu())
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        HelpingMethods.GetFilePath();
                        DataProcessing.DeserializeFromJsonFile(HelpingMethods.file_path);
                        HelpingMethods.PrintWithColor("Data loaded", ConsoleColor.Green);
                        Thread.Sleep(1000);
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        HelpingMethods.WriteMenu();
                        Thread.Sleep(1000);
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        if (HelpingMethods.currentAppUsers.Count <= 0)
                        {
                            HelpingMethods.PrintWithColor("Cant sort file", ConsoleColor.Red);
                            Thread.Sleep(1000);
                        }                           
                        else
                        {
                            DataProcessing.Sorting();
                            HelpingMethods.PrintWithColor("Data loaded", ConsoleColor.Green);
                            Thread.Sleep(1000);
                        }
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        if (HelpingMethods.currentAppUsers.Count == 0 || HelpingMethods.currentAppUsers.Count < 0)
                        {
                            HelpingMethods.PrintWithColor("Cant edit data", ConsoleColor.Red);
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            DataProcessing.ChangeHero();
                            HelpingMethods.PrintWithColor("Complete!", ConsoleColor.Green);
                            Thread.Sleep(1000);
                        }
                        break;
                    case ConsoleKey.D5:
                        Console.Clear();
                        int amount;
                        HelpingMethods.GetNumber(out amount,"heroes");
                        ManualInput.FillJson(amount);
                        HelpingMethods.PrintWithColor("Data loaded", ConsoleColor.Green);
                        Thread.Sleep(1000);
                        break;
                }
            } while (HelpingMethods.consoleKey != ConsoleKey.D6);
        }
    }
}
