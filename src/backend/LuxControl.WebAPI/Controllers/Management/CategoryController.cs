using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


using LuxControl.Core.Models.Management;
using LuxControl.Infrastructure.Data;

namespace LuxControl.WebAPI.Controllers.Management
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly LuxControlContext _context;
        public CategoryController(LuxControlContext context)
        {
            _context = context;
        }

        // GET api/category
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategorys()
        {
            return await _context.Categorys.ToListAsync();
        }

        // GET api/category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            var CategoryId = await _context.Categorys.FindAsync(id);
            if (CategoryId == null) return NotFound();
            return CategoryId;
        }

        // POST api/category
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            try
            {
                _context.Categorys.Add(category);
                await _context.SaveChangesAsync();
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/category/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            try
            {
                if (id != category.Id) return BadRequest();
     
                _context.Entry(category).State = EntityState.Modified;
                _context.Update(category);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryById(int id)
        {
            var CategoryId = await _context.Categorys.FindAsync(id);

            if (CategoryId == null) NotFound();

            _context.Categorys.Remove(CategoryId);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}