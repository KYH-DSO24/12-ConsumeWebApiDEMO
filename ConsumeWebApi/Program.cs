HttpClient client = new()
{
    BaseAddress = new Uri("https://jsonplaceholder.typicode.com/")
};

var response = await client.GetAsync("posts/1");
var content = await response.Content.ReadAsStringAsync();
Console.WriteLine(content);


