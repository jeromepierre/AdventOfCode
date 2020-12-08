using System;
using System.IO;

namespace Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] steps = new int[,] { { 1, 1 }, { 3, 1 }, { 5, 1 }, { 7, 1 }, { 1, 2 } };
            long allTress = 1;
            int stepsLen = steps.Length / 2;
            for (int i = 0; i < stepsLen; i++)
            {
                int trees = 0;
                int top = steps[i, 1];
                int left = steps[i, 0];
                int topDir = top;
                int leftDir = left;
                string[] input = File.ReadAllLines(@"C:\VS-Workspace\AdventOfCode\Day3\maze.txt");

                while (top < input.Length)
                {
                    int len = input[top].Length;
                    if (input[top][left % len] == '#')
                        trees++;
                    top += topDir;
                    left += leftDir;
                }
                allTress *= trees;
            }
            Console.WriteLine(allTress);
        }
    }
}
