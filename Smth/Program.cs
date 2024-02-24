//C:\Users\murd3rRRR\source\repos\KDZ2_mod3_Isaev_Kirill\Smth\TestData\18V.JSON
/*
 * Isaev Kirill 
 * 2310
 * V18
 */
using ClassLib;
using System.Text.Json;

namespace StartGame
{
    public class Program
    {
        /// <summary>
        /// Start point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                do
                {
                    Console.Clear();
                    ConsoleMenu.StartComputer();
                    Console.Clear();
                    Console.WriteLine("If you want to close app: input ENTER\n" +
                        "Else another input");
                } while (Console.ReadKey().Key != ConsoleKey.Enter);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (JsonException ex) // It's for incorrect json's file format.
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}   