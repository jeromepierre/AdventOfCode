using System;
using System.IO;
using System.Linq;

namespace Part2
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
                string pw = password.Split(':')[1].Trim();
                int pos1 = Convert.ToInt32(policy.Split(' ')[0].Split('-')[0]) - 1;
                int pos2 = Convert.ToInt32(policy.Split(' ')[0].Split('-')[1]) - 1;
                char letter = Convert.ToChar(policy.Split(' ')[1]);
                if (pw[pos1] == letter && pw[pos2] != letter || pw[pos1] != letter && pw[pos2] == letter)
                    sum++;
            }

            Console.WriteLine(sum);
        }
    }
}
