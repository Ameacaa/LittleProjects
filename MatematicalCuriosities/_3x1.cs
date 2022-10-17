namespace LittleProjects.MatematicalCuriosities
{
    class _3x1
    {
        private static ulong InputNumber(string message)
        {
            string? inputString;
            ulong inputNumber;
            do
            {
                Console.Write(message);
                inputString = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(inputString)) { Console.WriteLine("ERROR: Empty value"); continue; }
            } while (!ulong.TryParse(inputString, out inputNumber));
            return inputNumber;
        }

        private static void NormalMode(ulong min, ulong max)
        {
            for (ulong v = min; v < max; v++)
            {
                int steps = 0;
                ulong t = v;
                DateTime start = DateTime.Now;
                Console.Write("[" + t + "] - ");
                while (t != 1)
                {
                    steps++;
                    if (t % 2 == 0) { t /= 2; }
                    else { t = 3 * t + 1; }
                }
                Console.Write(steps + " - ");
                Console.Write("(" + (DateTime.Now - start) + ")");
                Console.WriteLine();
            }
        }

        private static void DetailMode(ulong min, ulong max)
        {
            for (ulong v = min; v < max; v++)
            {
                int steps = 0;
                ulong t = v;
                DateTime start = DateTime.Now;
                Console.Write("[" + t + "] - ");
                while (t != 1)
                {
                    steps++;
                    if (t % 2 == 0) { t /= 2; }
                    else { t = 3 * t + 1; }
                    Console.Write(t + " - ");
                }
                Console.WriteLine(steps);
                Console.WriteLine  ("(" + (DateTime.Now - start) + ")");
                Console.WriteLine();
            }
        }

        public static void Menu()
        {
            ulong min = 1, max = 100;
            Console.WriteLine("\n"
                + "***********************************************************************\n"
                + "****** Math 3x+1                                       by Ameaca ******\n"
                + "***********************************************************************\n"
                + "**                                                                   **\n"
                + "**   1 --- Change Min value                                          **\n"
                + "**   2 --- Change Max value                                          **\n"
                + "**   3 --- Launch Normal mode                                        **\n"
                + "**   4 --- Launch Detail mode                                        **\n"
                + "**   0 --- Return to Main Menu                                       **\n"
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
                        Console.WriteLine("Returning to Main Menu");
                        return;
                    case ConsoleKey.NumPad1:
                        min = InputNumber("Enter a min value: ");
                        break;
                    case ConsoleKey.NumPad2:
                        max = InputNumber("Enter a Max value: ");
                        break;
                    case ConsoleKey.NumPad3:
                        NormalMode(min, max);
                        break;
                    case ConsoleKey.NumPad4:
                        DetailMode(min, max);
                        break;
                    default:
                        Console.WriteLine("ERROR INPUT: Select a valid number");
                        break;
                }
            } while (true);


            
            
        }

    }
}
