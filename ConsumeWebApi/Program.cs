// Koden finns i Github. Klona från https://github.com/KYH-DSO24/12-ConsumeWebApiDEMO.git



using ConsumeWebApi;

using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

HttpClient client = new()
{
    BaseAddress = new Uri("https://jsonplaceholder.typicode.com/")
};

Console.WriteLine("Hämta en post");
var post = await GetPostAsync(client);

Console.WriteLine(post);

Console.WriteLine("\n\nHämta alla poster:");
var posts = await GetPostsAsync(client);
//foreach (var p  in posts)
//{
//    Console.WriteLine(p);
//}
for (int i = 0; i < 5; i++)
{
    Console.WriteLine(posts[i]);
    Console.WriteLine();
}

Console.WriteLine("\n\nSkapa en post");
post = new Post()
{
    UserId = 1,
    Title = "Test",
    Body = "Test kropp med lite mer text\noch en radbrytning, bara för att vi kan"
};
var response = await SendPostAsync(client, post);
Console.WriteLine(response);

Console.Write("\n\nTryck på en tangent för att stänga fönstret...");
Console.ReadKey();


async Task<Post> GetPostAsync(HttpClient client)
{
    await using Stream stream =
        await client.GetStreamAsync("posts/1");
    var result = await JsonSerializer.DeserializeAsync<Post>(stream);

    return result ?? new();
}

static async Task<List<Post>> GetPostsAsync(HttpClient client)
{
    await using Stream stream =
        await client.GetStreamAsync("posts");
    var result = await JsonSerializer.DeserializeAsync<List<Post>>(stream);

    return result ?? new();
}

static async Task<Post> SendPostAsync(HttpClient client, Post post)
{
    string jsonString = JsonSerializer.Serialize(post);
    HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
    var response = await client.PostAsync("/posts", content);

    response.EnsureSuccessStatusCode();

    var result = await response.Content.ReadFromJsonAsync<Post>();
    return result;
}


