using System;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var madeSelection = false;
            var selectedIndex = 0;
            var allProblems = new Type[]{
                typeof(Day1A),
                typeof(Day1B)
            };

            Console.WriteLine("Select A Problem:");
            
            while (!madeSelection)
            {
                for (var i = 0; i < allProblems.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.Write(">> ");
                    }
                    else
                    {
                        Console.Write("   ");
                    }

                    Console.WriteLine(allProblems[i].Name);
                }

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex--;

                        if (selectedIndex < 0)
                        {
                            selectedIndex = allProblems.Length - 1;
                        }

                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex++;

                        if (selectedIndex > allProblems.Length - 1)
                        {
                            selectedIndex = 0;
                        }
                        break;
                    case ConsoleKey.Enter:
                        madeSelection = true;
                        break;
                }

                if (!madeSelection)
                {
                    Console.CursorTop = Console.CursorTop - allProblems.Length;
                }
            }
        
            var initialized = (IProblemSolution)Activator.CreateInstance(allProblems[selectedIndex]);
            await initialized.ExecuteAsync();
        }
    }
}
