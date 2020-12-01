using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    public class Day1B : IProblemSolution
    {
        public async Task ExecuteAsync()
        {
            var input = await File.ReadAllLinesAsync("./Input/DayOne.txt");
            var integers = input.Select(value => Convert.ToInt32(value));
            var foundValues = false;

            foreach (var firstNumber in integers)
            {
                foreach (var secondNumber in integers.Except(new[] { firstNumber }))
                {
                    foreach (var thirdNumber in integers.Except(new[] { firstNumber, secondNumber }))
                    {
                        if (firstNumber + secondNumber + thirdNumber == 2020)
                        {
                            Console.WriteLine(firstNumber * secondNumber * thirdNumber);
                            foundValues = true;
                            break;
                        }
                    }

                    if (foundValues)
                    {
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