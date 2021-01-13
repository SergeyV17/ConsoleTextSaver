using System;

namespace Appricot_Test_VlasenkoSA
{
    /// <summary>
    /// Класс старта приложения
    /// </summary>
    class Program
    {
        /// <summary>
        /// Точка входа в приложение
        /// </summary>
        static void Main()
        {
            Console.WriteLine("Enter text line and press Enter for new line. Press Ctrl + S to Save file");

            string text = new TextReader().Read();

            string path = string.Format($"{DateTime.Now:dd-MM-yyyy-HH-mm-ss}.txt");

            new FileWriter().Write(path, text); 
        }
    }
}
