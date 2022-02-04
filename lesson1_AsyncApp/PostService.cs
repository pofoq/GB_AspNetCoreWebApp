using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;

namespace CodeExamplesConsole.AspNetCoreWebApp._1_async.HomeWork
{
    public static class PostService
    {
        static private HttpClient _httpClient = new HttpClient();
        static private string _baseUrl = "https://jsonplaceholder.typicode.com/todos/";
        static private string _path = "result.txt";

        internal static async ValueTask<Post> GetPostAsync(int postId)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_baseUrl}{postId}");
                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();

                JsonSerializerOptions options = new JsonSerializerOptions();
                options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                var post = JsonSerializer.Deserialize<Post>(json, options);

                return post;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        internal static void Save(Post post)
        {
            File.AppendAllLines(_path, $"{post.UserId}", $"{post.Id}", post.Title, post.Body);
        }
    }
}
