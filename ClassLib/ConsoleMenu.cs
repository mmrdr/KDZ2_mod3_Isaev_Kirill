namespace ClassLib
{
    public class ConsoleMenu
    {
        /// <summary>
        /// Second startpoint at this program.
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

        private static void BeginAction()
        {
            HelpingMethods.PrintWithColor("The first of all - input path to json file", ConsoleColor.Yellow);
            HelpingMethods.GetFilePath();
            DataProcessing.DeserializeFromJsonFile(HelpingMethods.file_path);
            HelpingMethods.PrintWithColor("Data loaded", ConsoleColor.Green);
            Thread.Sleep(2000);            
            do
            {
                Console.Clear();
                HelpingMethods.ShowMenu();
                Console.CursorVisible = false;
                switch (HelpingMethods.ItemForMenu())
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        HelpingMethods.GetFilePath();
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
                        DataProcessing.Sorting();
                        HelpingMethods.PrintWithColor("Data loaded", ConsoleColor.Green);
                        Thread.Sleep(1000);
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();                        
                        DataProcessing.ChangeHero();
                        HelpingMethods.PrintWithColor("Complete!", ConsoleColor.Green);
                        Thread.Sleep(1000);
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
