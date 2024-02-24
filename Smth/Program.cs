//C:\Users\murd3rRRR\source\repos\KDZ2_mod3_Isaev_Kirill\Smth\TestData\18V.JSON
using ClassLib;

namespace StartGame
{
    public class Program
    {
        static void Main(string[] args)
        {            
            do
            {
                Console.Clear();
                ConsoleMenu.StartComputer();
                Console.Clear();
                Console.WriteLine("If you want to close app: input ENTER\n" +
                    "Else another input");
            } while(Console.ReadKey().Key != ConsoleKey.Enter);          
        }
    }
}   