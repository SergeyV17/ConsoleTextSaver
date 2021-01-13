using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace Appricot_Test_VlasenkoSA
{
    static class TextReader
    {
        internal static string Read()
        {
            Console.TreatControlCAsInput = true;

            StringBuilder sb = new StringBuilder();
            ConsoleKeyInfo currentKey;

            List<int> rowsLengths = new List<int>();
            int currentRowLength = 0;

            do
            {
                currentKey = Console.ReadKey(true);

                if (currentKey.Modifiers == ConsoleModifiers.Control && currentKey.Key == ConsoleKey.S)
                    return sb.ToString();

                if (currentKey.Key == ConsoleKey.Enter)
                {
                    sb.Append(currentKey.KeyChar);
                    Console.WriteLine();
                    currentRowLength++;

                    rowsLengths.Add(currentRowLength);

                    currentRowLength = 0;
                }
                else if (currentKey.Key == ConsoleKey.Backspace)
                {
                    if (sb.Length > 0)
                    {
                        if (sb[sb.Length - 1] == (char)ConsoleKey.Enter)
                        {
                            Console.CursorTop--;
                            Console.CursorLeft = rowsLengths[rowsLengths.Count - 1];

                            currentRowLength = rowsLengths[rowsLengths.Count - 1];
                            rowsLengths.RemoveAt(rowsLengths.Count - 1);
                        }

                        sb = sb.Remove(sb.Length - 1, 1);
                        Console.Write(currentKey.KeyChar);
                        Console.Write(" ");
                        Console.Write(currentKey.KeyChar);
                        currentRowLength--;
                    }
                }
                else if ((currentKey.Modifiers & ConsoleModifiers.Alt) != 0)
                    Console.Write("");
                else if ((currentKey.Modifiers & ConsoleModifiers.Control) != 0)
                    Console.Write("");
                else
                {
                    sb.Append(currentKey.KeyChar);
                    Console.Write(currentKey.KeyChar);
                    currentRowLength++;
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

            try
            {
                File.WriteAllText(path, text);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine($"{ex.Message} \nCheck the directory path.");
                throw;
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine($"\nFile successfully saved. {new FileInfo(path).Length} bytes");
            }
        }
    }
}
