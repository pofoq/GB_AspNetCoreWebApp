using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeExampleConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start a program!\n");

            // START AsyncApp 
            //AsyncApp.Example1.Start();
            //AsyncApp.Example2.Start();
            //AsyncApp.Example3.Start();
            // END AsyncApp 

            // Start Yield
            IEnumerable<int> numbers = new List<int> { 1, 2, 3, 4, 9, 8, 7, 6 };
            var newNumbers = Yield.YieldClass.GetNewArray(numbers);
            numbers.ToList().ForEach(x => Console.Write($"{x} "));
            Console.WriteLine();
            newNumbers.ToList().ForEach(x => Console.Write($"{x} "));
            // END Yield

            Console.WriteLine("\nEnd of program!");
            Console.Read();
        }
    }
}
