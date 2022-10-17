using LittleProjects.VigenereEncoder;

namespace LittleProjects
{
    class Program
    { 
        static void Main()
        {
            Console.WriteLine("\n"
                + "***********************************************************************\n"
                + "****** Main Menu                                       by Ameaca ******\n"
                + "***********************************************************************\n"
                + "**                                                                   **\n"
                + "**   1 --- Vigenere Encoder                                          **\n"
                + "**   0 --- Quit                                                      **\n"
                + "**                                                                   **\n"
                + "***********************************************************************");
            do
            {
                Console.Write("Menu Choose: ");
                ConsoleKey inputMenu = Console.ReadKey().Key;
                Console.WriteLine();
                switch (inputMenu)
                {
                    case ConsoleKey.NumPad0:
                        Console.WriteLine("Bye-bye");
                        return;
                    case ConsoleKey.NumPad1:
                        VigenereEncoder.VigenereEncoder.Menu();
                        break;

                    default:
                        Console.WriteLine("ERROR INPUT: Select a valid number");
                        break;
                }
            } while (true);
        }
    }
}