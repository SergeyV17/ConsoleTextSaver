using System;
using System.Text;
using System.IO;

namespace Appricot_Test_VlasenkoSA
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter text line and press Enter for new line. Press Ctrl + S to Save file");

            ConsoleKeyInfo cki;
            Console.TreatControlCAsInput = true;

            StringBuilder sb = new StringBuilder();

            do
            {
                cki = Console.ReadKey(true);

                if ((cki.Modifiers & ConsoleModifiers.Alt) != 0) Console.Write("");
                else if ((cki.Modifiers & ConsoleModifiers.Control) != 0) Console.Write("");
                else
                {
                    Console.Write(cki.KeyChar);
                    sb.Append(cki.KeyChar);
                }

                if (cki.Key == ConsoleKey.Enter)
                    Console.WriteLine();

            } while (!(cki.Modifiers == ConsoleModifiers.Control &&  cki.Key == ConsoleKey.S));


            string path = string.Format($"{DateTime.Now:dd-MM-yyyy-HH-mm-ss}.txt");

            File.WriteAllText(path, sb.ToString());

            Console.WriteLine($"\nFile successfully saved. {new FileInfo(path).Length} bytes");
        }
    }
}
