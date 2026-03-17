using Microsoft.AspNetCore.Mvc;
using BlogAPI.Models;
using BlogAPI.Data;

namespace BlogAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetPosts()
    {
        return Ok(PostRepository.Posts);
    }

    [HttpPost]
    public IActionResult CreatePost(Post post)
    {
        post.Id = PostRepository.Posts.Count + 1;
        PostRepository.Posts.Add(post);
        return Ok(post);
    }
    
}