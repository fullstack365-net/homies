using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostService.Data;
using PostService.DTOs;
using PostService.Entities;

namespace PostService.Controllers;

[ApiController]
[Route("api/posts")]
public class PostsController : ControllerBase
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public PostsController(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<PostDto>>> GetAllPosts()
    {
        var posts = await _context.Posts
            .Include(x => x.Comments)
            .OrderBy(x => x.CreatedAt)
            .ToListAsync();

        return _mapper.Map<List<PostDto>>(posts);
        // return Ok(posts);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PostDto>> GetPostById(Guid id)
    {
        var post = await _context.Posts
            .Include(x => x.Comments)
            .FirstOrDefaultAsync(x => x.Id == id);
        
        if (post == null) return NotFound();

        return _mapper.Map<PostDto>(post);
    }

    [HttpPost]
    public async Task<ActionResult<PostDto>> CreateAuction(CreatePostDto postDto)
    {
        var post = _mapper.Map<Post>(postDto);

        _context.Posts.Add(post);

        var result = await _context.SaveChangesAsync() > 0;

        if (!result) return BadRequest("Could not save changes to the DB");

        return CreatedAtAction(nameof(GetPostById), 
            new {post.Id}, _mapper.Map<PostDto>(post));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdatePost(Guid id, UpdatePostDto updatePostDto)
    {
        var post = await _context.Posts
            .FirstOrDefaultAsync(x => x.Id == id);

        if (post == null) return NotFound();

        post.Title = updatePostDto.Title ?? post.Title;
        post.Content = updatePostDto.Content ?? post.Content;
        post.ImageUrl = updatePostDto.ImageUrl ?? post.ImageUrl;
        post.UpdatedAt = updatePostDto.UpdatedAt;

        var result = await _context.SaveChangesAsync() > 0;

        if (result) return Ok();

        return BadRequest("Problem saving changes");
    }

    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePost(Guid id)
    {
        var post = await _context.Posts.FindAsync(id);

        if (post == null) return NotFound();

        // TODO: check seller == username

        _context.Posts.Remove(post);

        var result = await _context.SaveChangesAsync() > 0;

        if (!result) return BadRequest("Could not update DB");

        return Ok();
    }
}