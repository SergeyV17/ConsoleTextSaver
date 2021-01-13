using System;
using System.Text;
using System.Collections.Generic;

namespace Appricot_Test_VlasenkoSA
{
    /// <summary>
    /// Класс обработки текста
    /// </summary>
    class TextReader
    {
        private StringBuilder sb;

        private ConsoleKeyInfo currentKey;
        
        private int currentRowLength;
        private readonly List<int> rows;

        /// <summary>
        /// Конструктор
        /// </summary>
        public TextReader()
        {
            sb = new StringBuilder();

            rows = new List<int>();
            currentRowLength = 0;

            Console.TreatControlCAsInput = true;
        }

        /// <summary>
        /// Метод обработки нажатия клавиши "Enter"
        /// </summary>
        private void EnterBtnHandler()
        {
            sb.Append(currentKey.KeyChar);
            Console.WriteLine();
            currentRowLength++;

            rows.Add(currentRowLength);
            currentRowLength = 0;
        }

        /// <summary>
        /// Метод обработки нажатия клавиши "Backspace"
        /// </summary>
        private void BackspaceBtnHandler()
        {
            if (sb.Length > 0)
            {
                if (sb[sb.Length - 1] == (char)ConsoleKey.Enter)
                {
                    Console.CursorTop--;
                    Console.CursorLeft = rows[rows.Count - 1];

                    currentRowLength = rows[rows.Count - 1];
                    rows.RemoveAt(rows.Count - 1);
                }

                sb = sb.Remove(sb.Length - 1, 1);
                Console.Write(currentKey.KeyChar);
                Console.Write(" ");
                Console.Write(currentKey.KeyChar);
                currentRowLength--;
            }
        }

        /// <summary>
        /// Метод обработки нажатия клавиш не предусмотренных другими методами
        /// </summary>
        private void StandardBtnHandler()
        {
            sb.Append(currentKey.KeyChar);
            Console.Write(currentKey.KeyChar);
            currentRowLength++;
        }

        /// <summary>
        /// Метод обработки вводимого текста
        /// </summary>
        /// <returns>текст</returns>
        public string Read()
        {
            do
            {
                currentKey = Console.ReadKey(true);

                if (currentKey.Modifiers == ConsoleModifiers.Control && currentKey.Key == ConsoleKey.S)
                    return sb.ToString();

                if (currentKey.Key == ConsoleKey.Enter)
                    EnterBtnHandler();
                else if (currentKey.Key == ConsoleKey.Backspace)
                    BackspaceBtnHandler();
                else if ((currentKey.Modifiers & ConsoleModifiers.Alt) != 0)
                    Console.Write("");
                else if ((currentKey.Modifiers & ConsoleModifiers.Control) != 0)
                    Console.Write("");
                else
                    StandardBtnHandler();
            }
            while (true);
        }
    }
}
