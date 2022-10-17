using LittleProjects.VigenereEncoder;
using LittleProjects.MatematicalCuriosities;

Console.Clear();
Console.WriteLine("\n"
                + "***********************************************************************\n"
                + "****** Main Menu                                       by Ameaca ******\n"
                + "***********************************************************************\n"
                + "**                                                                   **\n"
                + "**   1 --- Vigenere Encoder                                          **\n"
                + "**   2 --- Math Curiosity (3x+1)                                     **\n"
                + "**   3 --- Math Curiosity (6174)                                     **\n"
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
            VigenereEncoder.Menu();
            break;
        case ConsoleKey.NumPad2:
            _3x1.Menu();
            break;
        default:
            Console.WriteLine("ERROR INPUT: Select a valid number");
            break;
    }
} while (true);
