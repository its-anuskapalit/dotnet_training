using BlogAPI.Models;

namespace BlogAPI.Data;

public static class PostRepository
{
    public static List<Post> Posts = new List<Post>
    {
        new Post { Id = 1, UserId = 1, Title = "First Post", Body = "Hello API" },
        new Post { Id = 2, UserId = 2, Title = "Second Post", Body = "ASP.NET Web API" }
    };
}