using System.Collections.Generic;

namespace AsyncAppConsole
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
