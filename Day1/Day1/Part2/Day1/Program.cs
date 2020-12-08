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

            for (int i = 0; i < inputs.Length; i++)
            {
                for (int j = 0; j < inputs.Length; j++)
                {
                    for (int k = 0; k < inputs.Length; k++)
                    {
                        if (Convert.ToInt32(inputs[i]) + Convert.ToInt32(inputs[j]) + Convert.ToInt32(inputs[k]) == 2020)
                        {
                            Console.WriteLine(Convert.ToInt32(inputs[i]) + Convert.ToInt32(inputs[j]) + Convert.ToInt32(inputs[k]));
                            Console.WriteLine(Convert.ToInt32(inputs[i]) * Convert.ToInt32(inputs[j]) * Convert.ToInt32(inputs[k]));
                            Console.ReadLine();
                        }
                    }
                }
            }
        }
    }
}
