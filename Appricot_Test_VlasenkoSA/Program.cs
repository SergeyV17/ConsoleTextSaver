using System;
using System.Text;
using System.IO;

namespace Appricot_Test_VlasenkoSA
{
    static class TextReader
    {
        internal static string Read()
        {
            Console.TreatControlCAsInput = true;

            StringBuilder sb = new StringBuilder();
            ConsoleKeyInfo cki;

            do
            {
                cki = Console.ReadKey(true);

                if (cki.Modifiers == ConsoleModifiers.Control && cki.Key == ConsoleKey.S)
                    return sb.ToString();

                if (cki.Key == ConsoleKey.Enter)
                {
                    sb.Append(cki.KeyChar);
                    Console.WriteLine();
                }
                else if (cki.Key == ConsoleKey.Backspace)
                {
                    if (sb.Length > 0)
                    {
                        sb = sb.Remove(sb.Length - 1, 1);
                        Console.Write(cki.KeyChar);
                        Console.Write(' ');
                        Console.Write(cki.KeyChar);
                    }
                }
                else if ((cki.Modifiers & ConsoleModifiers.Alt) != 0)
                    Console.Write("");
                else if ((cki.Modifiers & ConsoleModifiers.Control) != 0)
                    Console.Write("");
                else
                {
                    sb.Append(cki.KeyChar);
                    Console.Write(cki.KeyChar);
                }
            }
            while (true);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter text line and press Enter for new line. Press Ctrl + S to Save file");

            string text = TextReader.Read();

            string path = string.Format($"{DateTime.Now:dd-MM-yyyy-HH-mm-ss}.txt");

            File.WriteAllText(path, text);

            Console.WriteLine($"\nFile successfully saved. {new FileInfo(path).Length} bytes");
        }
    }
}
