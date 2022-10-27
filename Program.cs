using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        static List<int> readArrayFromFile(string filename)
        {
            var fileContent = File.ReadAllText(filename);

            var array = fileContent.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
            List<int> result = new List<int>();

            for (int i = 0; i < array.Length; ++i)
            {
                result.Add(Int32.Parse(array[i]));
            }
            return result;
        }

        static void Main(string[] args)
        {
            #region task1
            string filePath = ".\\1.txt ";
            var words = new SortedDictionary<int, List<string>>();

            // create file with random text
            if (!CreateRandomFile(filePath, 30))
            {
                Console.WriteLine("Unable to create file");
                System.Environment.Exit(1);
            }


            var fileContent = File.ReadAllText(filePath);
            Console.WriteLine("===========Source file===========");
            Console.WriteLine(fileContent);
            Console.WriteLine();
            var array = fileContent.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < array.Length; ++i)
            {
                var key = array[i].Length;
                if (!words.ContainsKey(key))
                    words.Add(key, new List<string>());

                words[key].Add(array[i]);
            }
            foreach (var key in words.Keys)
            {
                Console.Write($"Size: {key} ".PadRight(9) + $"(total {words[key].Count}):".PadRight(11));
                foreach (var word in words[key])
                    Console.Write($"{word} ");
                Console.WriteLine();
            }

            #endregion //task1

            #region task2
            var result = readArrayFromFile("../../array.txt");

            Console.WriteLine("Task 2:");
            int min = int.MaxValue;
            int max = int.MinValue;

            for (int i = 0; i < result.Count; ++i)
            {
                if (result[i] < min)
                    min = result[i];
                else if (result[i] > max)
                    max = result[i];
            }

            for (int i = 0; i < result.Count; ++i)
            {
                if (result[i] != min && result[i] != max)
                    Console.WriteLine(result[i]);
            }
            Console.ReadLine();
            #endregion //task2


        }
    }
}