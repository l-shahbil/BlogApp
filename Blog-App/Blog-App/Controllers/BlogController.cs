using Blog_App.Models;
using Blog_App.Repository.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IRepository<Blog> _repositoryBlog;

        public BlogController(IRepository<Blog> repository)
        {
            _repositoryBlog = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Blog> blogs =await _repositoryBlog.GetAllAsync();
            return Ok(blogs);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> getById(int id)
        {
            Blog b = await _repositoryBlog.GetByIdAsync(id);
            if (b != null) 
            {
                return Ok(b);
            }
            return NotFound(b);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddBlog(Blog b)
        {
            if (ModelState.IsValid)
            {
               _repositoryBlog.AddAsync(b);
                return StatusCode(StatusCodes.Status201Created);
            }
            return NotFound(ModelState);
        }
        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> updateBlog([FromRoute]int id,[FromBody]Blog b)
        {
            if (ModelState.IsValid) { 
                Blog blog = await _repositoryBlog.GetByIdAsync(id);
                if (blog != null) 
                {
                    blog.Title = b.Title;
                    blog.Description = b.Description;
                    blog.Content = b.Content;
                    blog.image = b.image;
                    blog.IsFeatured = b.IsFeatured;
                    _repositoryBlog.Update(blog);
                    return StatusCode(StatusCodes.Status204NoContent);
                }
                return NotFound(blog);
            }
            return BadRequest(ModelState);
        }
        [Authorize]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            Blog blog = await _repositoryBlog.GetByIdAsync(id);
            if (blog != null) 
            {
                _repositoryBlog.Delete(blog);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("GetBlogFeaturedList")]
        public async Task<IActionResult> GetBlogFeaturedList() 
        {
            var blogIsFeatured=await _repositoryBlog.GetAllAsync(x => x.IsFeatured == true);
            return Ok(blogIsFeatured);
        }
    }
}
