using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputString = File.ReadAllText(@"C:\VS-Workspace\AdventOfCode\Day4\passports.txt");
            var passports = inputString.Split(new string[] { "\r\n\r\n" },
                               StringSplitOptions.RemoveEmptyEntries);
            int sum = 0;

            Regex reg = new Regex("[a-z]{3}:");

            foreach (var passport in passports)
            {
                var matches = reg.Matches(passport);
                if (matches.Count == 8)
                {
                    sum++;
                    continue;
                }
                if (matches.Count == 7)
                {
                    bool hasCid = false;
                    foreach (var match in matches)
                    {
                        if (match.ToString() == "cid:")
                        {
                            hasCid = true;
                            break;
                        }
                    }
                    if (!hasCid)
                        sum++;
                }
                continue;
            }

            Console.WriteLine(sum);
        }
    }
}
