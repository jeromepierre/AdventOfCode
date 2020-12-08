using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = File.ReadAllLines(@"C:\VS-Workspace\AdventOfCode\Day1\expenses.txt");
            List<string> inputList = inputs.OfType<string>().ToList();

            for (int i = 0; i < inputList.Count; i++)
            {
                for (int j = 0; j < inputList.Count; j++)
                {
                    if (Convert.ToInt32(inputList[i]) + Convert.ToInt32(inputList[j]) == 2020)
                    {
                        Console.WriteLine(Convert.ToInt32(inputList[i]) + Convert.ToInt32(inputList[j]));
                        Console.WriteLine(Convert.ToInt32(inputList[i]) * Convert.ToInt32(inputList[j]));
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}
