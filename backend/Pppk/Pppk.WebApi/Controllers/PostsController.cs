using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
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
        public async Task<ActionResult<IEnumerable<Post>>> GetAll()
        {
            var posts = await _context.Posts.ToListAsync();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetById(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            return Ok(post);
        }
    }
}
