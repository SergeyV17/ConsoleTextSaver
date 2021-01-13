using System;
using System.IO;

namespace Appricot_Test_VlasenkoSA
{
    class FileWriter
    {
        public void Write(string path, string text)
        {
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
