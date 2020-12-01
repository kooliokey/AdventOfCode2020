using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    public class Day1A : IProblemSolution
    {
        public async Task ExecuteAsync()
        {
            var input = await File.ReadAllLinesAsync("./Input/DayOne.txt");
            var integers = input.Select(value => Convert.ToInt32(value));
            var foundValues = false;

            foreach (var number in integers)
            {
                foreach (var otherNumber in integers.Except(new[] { number }))
                {
                    if (number + otherNumber == 2020)
                    {
                        Console.WriteLine(number * otherNumber);
                        foundValues = true;
                        break;
                    }
                }

                if (foundValues)
                {
                    break;
                }
            }

            if (!foundValues)
            {
                Console.WriteLine("Could not find the values!");
            }
        }
    }
}