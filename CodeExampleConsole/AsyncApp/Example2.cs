using System;
using System.Threading.Tasks;

namespace CodeExampleConsole.AsyncApp
{
    internal static class Example2
    {
        internal static void Start()
        {
            Task.WaitAll(MakeCoffe(), MakePizza(), TakeShower());

            GoToWork();
        }

        private static void GoToWork()
        {
            Console.WriteLine();
            Console.WriteLine("Go to Work");
        }

        private static async Task MakeCoffe()
        {
            Console.WriteLine($"Coffe. Warm water");
            await WorkEmulation.Get(3000);
            Console.WriteLine($"Coffe. Make coffee");
            await WorkEmulation.Get(2000);
            Console.WriteLine($"Coffe. It's too hot!!!");
            await WorkEmulation.Get(1000);
            Console.WriteLine($"Coffe. Done!");
        }

        private static async Task MakePizza()
        {
            Console.WriteLine($"Pizza. Start making a pizza");
            await WorkEmulation.Get(4000);
            Console.WriteLine($"Pizza. Pizza is Ready!");
        }

        private static async Task TakeShower()
        {
            Console.WriteLine($"Shower. Start taking a shower");
            await WorkEmulation.Get(6000);
            Console.WriteLine($"Shower. Finish taking a shower!");
        }
    }
}
