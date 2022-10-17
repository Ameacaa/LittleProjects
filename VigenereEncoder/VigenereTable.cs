namespace LittleProjects.VigenereEncoder
{
    class VigenereTable
    {
        public static char[] ValidChar { get; } =
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ' '
        };
        public static char invalidChar = '.';
        public static int CharLength => ValidChar.Length;
        public static char InvalidChar { get => invalidChar; set => invalidChar = value; }
        public static char[,] CreateTable()
        {
            char[,] table = new char[CharLength, CharLength];

            for (int l = 0; l < CharLength; l++)
            {
                int charI = l;
                for (int c = 0; c < CharLength; c++)
                {
                    table[l, c] = ValidChar[charI];
                    if (charI >= CharLength - 1) { charI = 0; }
                    else { charI++; }
                }
            }
            return table;
        }
        public static void ShowTable()
        {
            char[,] table = CreateTable();
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++) { Console.Write($"{table[i, j]}  "); }
                Console.WriteLine();
            }
        }
    }
}
