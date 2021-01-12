using System;
using System.Text;

namespace Appricot_Test_VlasenkoSA
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter text line and press Enter for new line. Press Ctrl + S to Save file");

            ConsoleKeyInfo cki;
            Console.TreatControlCAsInput = true;

            do
            {
                cki = Console.ReadKey();

                //if ((cki.Modifiers & ConsoleModifiers.Alt) != 0) Console.Write("ALT+");
                //if ((cki.Modifiers & ConsoleModifiers.Shift) != 0) Console.Write("SHIFT+");
                //if ((cki.Modifiers & ConsoleModifiers.Control) != 0) Console.Write("CTL+");

                if (cki.Key == ConsoleKey.Enter)
                    Console.WriteLine();


            } while (!(cki.Modifiers == ConsoleModifiers.Control &&  cki.Key == ConsoleKey.S));

            Console.WriteLine("File saved");
        }
    }
}
