using System.Collections.Generic;

namespace CodeExamplesConsole.AspNetCoreWebApp._1_async.HomeWork
{
    internal class Post
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public IEnumerable<string> Content => new string[] { $"{UserId}", $"{Id}", Title, Body };
    }
}
