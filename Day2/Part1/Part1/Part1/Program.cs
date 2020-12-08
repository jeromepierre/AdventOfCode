using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] passwords = File.ReadAllLines(@"C:\VS-Workspace\AdventOfCode\Day2\passwords.txt");
            int sum = 0;
            foreach (string password in passwords)
            {
                string policy = password.Split(':')[0];
                string pw = password.Split(':')[1];
                int min = Convert.ToInt32(policy.Split(' ')[0].Split('-')[0]);
                int max = Convert.ToInt32(policy.Split(' ')[0].Split('-')[1]);
                char letter = Convert.ToChar(policy.Split(' ')[1]);
                int count = pw.Count(x => x == letter);
                if (count >= min && count <= max)
                    sum++;
            }

            Console.WriteLine(sum);
        }
    }
}
