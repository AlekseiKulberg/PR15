using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {

        static string RandomText(int words)
        {
            Random random = new Random();
            var builder = new StringBuilder();

            for (int i = 0; i < words; ++i)
            {
                var size = random.Next(1, 20);
                var word_builder = new StringBuilder();
                for (var j = 0; j < size; j++)
                {
                    var @char = random.Next(1, 3) == 2 ? (char)random.Next(65, 90) : (char)random.Next(97, 122);
                    word_builder.Append(@char);
                }
                word_builder.Append(' ');
                builder.Append(word_builder.ToString());
            }
            return builder.ToString();
        }

        static bool CreateRandomFile(string path, int words = 10)
        {
            FileStream fileStream = null;

            try
            {
                fileStream = File.Open(path, FileMode.Create);

                StreamWriter output = new StreamWriter(fileStream);
                output.Write(RandomText(words));
                output.Close();
                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine(RandomText(10));
            Console.ReadLine();
        }
    }
}