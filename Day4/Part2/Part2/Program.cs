using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputString = File.ReadAllText(@"C:\VS-Workspace\AdventOfCode\Day4\passports.txt");
            var passports = inputString.Split(new string[] { "\r\n\r\n" },
                               StringSplitOptions.RemoveEmptyEntries);
            int sum = 0;

            Regex reg = new Regex("[a-z]{3}:.*?[\\s\\n\\r]");

            foreach (var passport in passports)
            {
                var matches = reg.Matches(passport + "\n");
                if (matches.Count == 8)
                {
                    if (ValidatePassport(matches))
                        sum++;
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
                    if (!hasCid && ValidatePassport(matches))
                        sum++;
                }
                continue;
            }

            Console.WriteLine(sum);

        }
        private static bool ValidatePassport(MatchCollection passport)
        {
            foreach (var match in passport)
            {
                var matchValues = match.ToString().Replace("\n", "").Replace("\r", "").Split(':');
                switch (matchValues[0])
                {
                    case "byr":
                        int byr = 0;
                        if (int.TryParse(matchValues[1], out byr))
                            if (byr < 1920 || byr > 2002)
                                return false;
                        break;
                    case "iyr":
                        int iyr;
                        if (int.TryParse(matchValues[1], out iyr))
                            if (iyr < 2010 || iyr > 2020) 
                                return false;
                        break;
                    case "eyr":
                        int eyr;
                        if (int.TryParse(matchValues[1], out eyr))
                            if (eyr < 2020 || eyr > 2030)
                                return false;
                        break;
                    case "hgt":
                        Regex reg = new Regex("\\d[in|cm]");
                        if (!reg.IsMatch(match.ToString()))
                            return false;
                        int hgt = int.Parse(new Regex("\\d{1,3}").Match(matchValues[1].ToString()).ToString());
                        string si = new Regex("\\D{2}").Match(matchValues[1].ToString()).ToString();
                        if (si == "cm")
                        {
                            if (hgt < 150 || hgt > 193)
                                return false;
                            break;
                        }
                        if (hgt < 59 || hgt > 76)
                            return false;
                        break;
                    case "ecl":
                        List<string> colours = new List<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                        if (!colours.Contains(matchValues[1].Trim()))
                            return false;
                        break;
                    case "hcl":
                        if (!new Regex("^#([A-Fa-f0-9]{6})$").IsMatch(matchValues[1].Trim()))
                            return false;
                        break;
                    case "pid":
                        if (!new Regex("^[0-9]{9}$").IsMatch(matchValues[1].Trim()))
                            return false;
                        break;
                    default:
                        break;
                }
            }
            return true;
        }
    }
}

