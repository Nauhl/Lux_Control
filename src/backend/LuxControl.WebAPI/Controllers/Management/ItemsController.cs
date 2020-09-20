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
    public class ItemsController : ControllerBase
    {
        private readonly LuxControlContext _context;
        public ItemsController(LuxControlContext context)
        {
            _context = context;
        }

        // GET api/items
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            return await _context.Items.ToListAsync();
        }

        // GET api/items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItemsById(int id)
        {
            var ItemId = await _context.Items.FindAsync(id);
            if (ItemId == null) return NotFound();
            return ItemId;
        }

        // POST api/items
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem([FromBody] Item item)
        {
            try
            {
                _context.Items.Add(item);
                await _context.SaveChangesAsync();
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/items/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutItem(int id, Item item)
        {
            try
            {
                if (id != item.Id) return BadRequest();
                _context.Entry(item).State = EntityState.Modified;
                _context.Update(item);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemById(int id)
        {
            var ItemId = await _context.Items.FindAsync(id);

            if (ItemId == null) return NotFound();

            _context.Items.Remove(ItemId);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}