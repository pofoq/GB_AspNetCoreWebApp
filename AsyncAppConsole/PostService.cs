using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Threading;

namespace AsyncAppConsole
{
    public static class PostService
    {
        static private string _baseUrl = "https://jsonplaceholder.typicode.com/posts/";
        static private string _path = "result.txt";

        internal static async Task<Post> GetPostAsync(int postId, CancellationToken token)
        {
            Console.WriteLine($"Get post {postId}");

            HttpClient _httpClient = new HttpClient();

            // Delay Task for test CancelationToken
            Random random = new Random();
            int rnd = random.Next(10, 30) * 100;
            await Task.Delay(rnd);

            int i = 0;

            try
            {
                CheckToken(ref i);

                HttpResponseMessage response = await _httpClient.GetAsync($"{_baseUrl}{postId}");
                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();

                CheckToken(ref i);

                JsonSerializerOptions options = new JsonSerializerOptions();
                options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                var post = JsonSerializer.Deserialize<Post>(json, options);

                CheckToken(ref i);

                Console.WriteLine($"End Get post {postId}. Timeout {rnd}");

                return post;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            void CheckToken(ref int count)
            {
                count++;
                if (token.IsCancellationRequested)
                {
                    throw new TaskCanceledException($"Task Canceled. Post {postId}. Timeout {rnd}. Count {count}");
                }
            }
        }

        internal static void Save(Post post)
        {
            File.AppendAllLines(_path, post.Content);
            File.AppendAllText(_path, Environment.NewLine);
        }

        internal static void DeleteFile()
        {
            if (File.Exists(_path))
            {
                File.Delete(_path);
            }
        }
    }
}
