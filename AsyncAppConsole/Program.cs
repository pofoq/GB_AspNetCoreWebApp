using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAppConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start\n");

            PostService.DeleteFile();

            IList<Task<Post>> tasks = new List<Task<Post>>();

            CancellationTokenSource tokenSource = new CancellationTokenSource(2000);

            for (int id = 4; id < 14; id++)
            {
                var task = PostService.GetPostAsync(id, tokenSource.Token);
                tasks.Add(task);
            }

            var result = Task.WhenAll(tasks);
            foreach (var post in result.Result)
            {
                if (post != null)
                {
                    PostService.Save(post);
                }
            }

            Console.WriteLine("\nEnd");
        }
    }
}
