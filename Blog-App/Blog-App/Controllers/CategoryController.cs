using Blog_App.Models;
using Blog_App.Repository.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category> _repoCategory;

        public CategoryController(IRepository<Category> repoCategory)
        {
            _repoCategory = repoCategory;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory() 
        {
            var categories = await _repoCategory.GetAllAsync();
            return Ok(categories);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddCategory(Category ct)
        {
            if (ModelState.IsValid) 
            {
                _repoCategory.AddAsync(ct);
                return StatusCode(StatusCodes.Status201Created);
            }
            return BadRequest();
        }
        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCategory([FromRoute]int id,[FromBody]Category ct) 
        {
            
                Category c =await _repoCategory.GetByIdAsync(id);
                if (c != null) 
                {
                     c.Id = id;
                    c.Name = ct.Name;
                    _repoCategory.Update(c);
                    return NoContent();
                }
                return NotFound();
       
        }
        [Authorize]
        [HttpDelete("{id}:int")]
        public async Task<IActionResult> DeleteCategory([FromRoute]int id)
        {
            Category ct =await _repoCategory.GetByIdAsync(id);
            if(ct != null)
            {
                _repoCategory.Delete(ct);
                return NoContent();
            }
            return NotFound();
        }
    }
}
