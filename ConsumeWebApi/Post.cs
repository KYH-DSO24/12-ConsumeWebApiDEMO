using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsumeWebApi;
public class Post
{
    [property: JsonPropertyName("userId")]
    public int UserId { get; set; }

    [property: JsonPropertyName("id")]
    public int Id { get; set; }

    [property: JsonPropertyName("title")]
    public string Title { get; set; }

    [property: JsonPropertyName("body")]
    public string Body { get; set; }

    public override string ToString()
    {
        return $"Post Id:{this.Id} \n UserId:{this.UserId} \n Title: {this.Title} \n Body: {this.Body}";
    }
}
