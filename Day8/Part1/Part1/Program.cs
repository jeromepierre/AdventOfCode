using System;
using System.Collections.Generic;
using System.IO;

namespace Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] gameInstructions = File.ReadAllLines(@"C:\VS-Workspace\AdventOfCode\Day8\game.txt");
            List<Instructions> instructions = new List<Instructions>();
            foreach (var item in gameInstructions)
            {
                var values = item.Split(' ');
                instructions.Add(new Instructions { Action = values[0], Count = Convert.ToInt32(values[1]) });
            }

            foreach (var item in instructions)
            {
                if (item.Action == "jmp" || item.Action == "nop")
                    ChangeAction(item);
                int index = 0;
                int acc = 0;
                bool isFinished = false;
                while (!isFinished)
                {
                    if (index > instructions.Count - 1)
                        break;
                    switch (instructions[index].Action)
                    {
                        case "acc":
                            if (!instructions[index].HasBeenVisited)
                            {
                                acc += instructions[index].Count;
                                instructions[index].HasBeenVisited = true;
                                index++;
                                break;
                            }
                            isFinished = true;
                            break;
                        case "jmp":
                            if (!instructions[index].HasBeenVisited)
                            {
                                instructions[index].HasBeenVisited = true;
                                index += instructions[index].Count;
                                break;
                            }
                            isFinished = true;
                            break;
                        case "nop":
                            if (!instructions[index].HasBeenVisited)
                            {
                                instructions[index].HasBeenVisited = true;
                                index++;
                                break;
                            }
                            isFinished = true;
                            break;
                        default:
                            break;
                    }

                }
                foreach (var x in instructions)
                {
                    x.HasBeenVisited = false;
                }
                if (item.Action == "jmp" || item.Action == "nop")
                    ChangeAction(item);
                if (index >= instructions.Count - 1)
                    Console.WriteLine(acc);
            }
        }

        private static void ChangeAction(Instructions item)
        {
            bool hasChanged = false;
            if (item.Action == "jmp")
            {
                item.Action = "nop";
                hasChanged = true;
            }
            if (item.Action == "nop" && !hasChanged)
                item.Action = "jmp";
        }
    }

    public class Instructions
    {
        public string Action { get; set; }
        public int Count { get; set; }
        public bool HasBeenVisited { get; set; }
    }
}
