using System;
using System.Threading.Tasks;

namespace CodeExampleConsole.AsyncApp
{
    internal static class Example3
    {
        internal static void Start()
        {
            var tasks = Task.WhenAll(MakePizza(PizzaKind.Chili), MakePizza(PizzaKind.Margarita), MakePizza(PizzaKind.Mazarella));
            var result = tasks.Result;
            foreach (var res in result)
            {
                Console.WriteLine(res.Kind);
            }

            GoToWork();
        }

        private static void GoToWork()
        {
            Console.WriteLine();
            Console.WriteLine("Go to Work");
        }

        private static async Task<Pizza> MakePizza(PizzaKind kind)
        {
            Console.WriteLine($"Pizza. Start making a pizza");
            await WorkEmulation.Get(4000);
            Console.WriteLine($"Pizza. Pizza is Ready!");
            return new Pizza(kind);
        }

        internal class Pizza
        {
            public Pizza(PizzaKind kind)
            {
                Kind = kind;
            }

            public PizzaKind Kind { get; }
        }

        public enum PizzaKind
        {
            Margarita,
            Mazarella,
            Chili
        }
    }
}
