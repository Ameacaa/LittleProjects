namespace LittleProjects.VigenereEncoder
{
    class VigenereEncoder
    {
        private static char[] InputText(string message)
        {
            string? inputString;
            do
            {
                Console.Write(message);
                inputString = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(inputString)) { Console.WriteLine("ERROR: Empty value"); }
            } while (string.IsNullOrEmpty(inputString));
            return inputString.ToCharArray();
        }

        private static char[] ArrangeKey(char[] key, int txtlength)
        {
            char[] newKey = new char[txtlength];
            
            if (txtlength == key.Length) { newKey = key; }
            else if (txtlength > key.Length)
            {
                int k = 0; // KeyIndex
                for (int i = 0; i < txtlength; i++) // TextIndex
                {
                    if (k >= key.Length) { k = 0; } // If end of key return to index 0
                    newKey[i] = key[k];
                    k++;
                }
            }
            else if (txtlength < key.Length)
            {
                for (int i = 0; i < txtlength; i++) { newKey[i] = key[i]; }
            }

            return newKey;
        }

        private static void Show1D(char[] txt, string message, bool newline = false)
        {
            if (message.Length > 0 && !newline) { Console.Write(message); }
            if (message.Length > 0 && newline) { Console.WriteLine(message); }
            for (int i = 0; i < txt.Length; i++) { Console.Write(txt[i]); }
            Console.WriteLine();
        }

        private static void Encoder()
        {
            char[] toEncodeText = InputText("Text to encode: ");
            char[] key = ArrangeKey(InputText("Key: "), toEncodeText.Length);
            char[] encodedText = new char[toEncodeText.Length];

            char[,] table = VigenereTable.CreateTable();
            bool advertise = false;

            for (int i = 0; i < encodedText.Length; i++)
            {
                // Search in the first table line the same letter from text and keep the index (do the same for key letter)
                // If the letter is not valid (not in table)
                int tableTextIndex = -1, tableKeyIndex = -1;
                for (int letter = 0; letter < table.GetLength(0); letter++)
                {
                    if (Equals(toEncodeText[i], table[0, letter])) { tableTextIndex = letter; break; }
                }
                for (int letter = 0; letter < table.GetLength(1); letter++)
                {
                    if (Equals(key[i], table[letter, 0])) { tableKeyIndex = letter; break; }
                }
                
                // Write encoded text
                if (tableKeyIndex == -1 || tableTextIndex == -1) { encodedText[i] = VigenereTable.InvalidChar; advertise = true; }
                else { encodedText[i] = table[tableKeyIndex, tableTextIndex]; }
            }
            if (advertise) { Console.WriteLine("Some characters of your text or key have been changed because their are not valid."); }
            
            Show1D(encodedText, "Encoded Text: ");
        }

        private static void Decoder()
        {
            char[] toDecodeText = InputText("Text to decode: ");
            char[] key = ArrangeKey(InputText("Key: "), toDecodeText.Length);
            char[] decodedText = new char[toDecodeText.Length];

            char[,] table = VigenereTable.CreateTable();

            for (int i = 0; i < decodedText.Length; i++)
            {
                // Search in the first table line the same letter from text and keep the index (do the same for key letter)
                // If the letter is not valid (not in table)
                int tableTextIndex = -1, tableKeyIndex = -1;
                for (int letter = 0; letter < table.GetLength(0); letter++)
                {
                    if (Equals(key[i], table[letter, 0])) { tableKeyIndex = letter; break; }
                }
                if (tableKeyIndex == -1) { decodedText[i] = VigenereTable.InvalidChar; continue; }
                for (int letter = 0; letter < table.GetLength(1); letter++)
                {
                    if (Equals(toDecodeText[i], table[tableKeyIndex, letter])) { tableTextIndex = letter; break; }
                }
                
                // Write encoded text
                if (tableKeyIndex == -1 || tableTextIndex == -1) { decodedText[i] = VigenereTable.InvalidChar; }
                else { decodedText[i] = table[0, tableTextIndex]; }
            }

            Show1D(decodedText, "Decoded Text: ");
        }

        public static void Menu()
        {
            Console.WriteLine("\n"
                + "***********************************************************************\n"
                + "****** Vigenere Encoder / Decoder                                ******\n"
                + "***********************************************************************\n"
                + "**                                                                   **\n"
                + "**   1 --- Encoder                                                   **\n"
                + "**   2 --- Decoder                                                   **\n"
                + "**   3 --- Show the Table                                            **\n"
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
                        Encoder();
                        break;
                    case ConsoleKey.NumPad2:
                        Decoder();
                        break;
                    case ConsoleKey.NumPad3:
                        VigenereTable.ShowTable();
                        break;
                    default:
                        Console.WriteLine("ERROR INPUT: Select a valid number");
                        break;
                }
            } while (true);
        }
    }
}