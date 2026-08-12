using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Pppk.WebApi.Dtos;
using Pppk.WebApi.Mappings;
using Pppk.WebApi.Models;

namespace Pppk.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly HealthcareContext _context;

        public PostsController(HealthcareContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetAll()
        {
            var posts = await _context.Posts.ToListAsync();
            var dto = posts.Select(p => p.ToDto());
            
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> GetById(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            var dto = post.ToDto();

            return Ok(dto);
        }



        [HttpPost]
        public async Task<ActionResult<PostDto>> Create(CreatePostDto dto)
        {
            var post = new Post
            {
                PostalCode = dto.PostalCode,
                City = dto.City
            };

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = post.Id }, post.ToDto());
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdatePostDto dto)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null) return NotFound();

            post.City = dto.City;

            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null) return NotFound();

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
