using System;
using System.Threading;
using System.Threading.Tasks;

namespace CodeExamplesConsole.AsyncApp
{
    internal static class Example1
    {
        internal static void Start()
        {
            Console.WriteLine($"{nameof(Start)} of {nameof(Example1)}");
            // myTask and myTask2 are the same methods
            var myTask_1 = new Task<int>(() =>
            {
                Console.WriteLine("Start 1");
                Thread.Sleep(4000);
                Console.WriteLine("End 1");
                return 1;
            });

            var myTask_2 = new Task<int>(MyMethod2);
            var myTask_3 = new Task(MyMethod3);

            myTask_3.Start();
            myTask_1.Start();
            myTask_1.Wait();
            myTask_2.Start();
            myTask_2.Wait();

            Console.WriteLine(myTask_1.Result);
            Console.WriteLine(myTask_2.Result);
            Console.WriteLine(myTask_1.Exception is null ? "null" : myTask_1.Exception);
            Console.WriteLine(myTask_2.Exception is null ? "null" : myTask_2.Exception);
            Console.WriteLine(myTask_3.Exception is null ? "null" : myTask_3.Exception);
        }

        private static int MyMethod2()
        {
            Console.WriteLine("Start 2");
            Thread.Sleep(3000);
            Console.WriteLine("End 2");
            return 2;
        }

        private static void MyMethod3()
        {
            Console.WriteLine("Start 3");
            Thread.Sleep(1000);
            Console.WriteLine("End 3");
        }
    }
}
