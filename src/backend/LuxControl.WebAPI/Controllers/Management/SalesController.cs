using System.Threading;
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
    public class SalesController : ControllerBase
    {
        private readonly LuxControlContext _context;
        public SalesController(LuxControlContext context)
        {
            _context = context;
        }

        // GET api/sales
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Sale>>> GetSales()
        {
            return await _context.Sales.ToListAsync();
        }

        // GET api/sales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetSaleById(int id)
        {
            var SaleId = await _context.Sales.FindAsync(id);
            if (SaleId == null) return NotFound();
            return SaleId;
        }

        // POST api/sales
        [HttpPost]
        public async Task<IActionResult> PostSales(Sale sale)
        {
            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSaleById), new { id = sale.Id }, sale);
        }

        // PUT api/sales/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSale(int id, Sale sale)
        {
           
            if (id != sale.Id) return BadRequest();
            _context.Entry(sale).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();

        }

        // DELETE api/sales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSaleById(int id)
        {
            var SaleId = await _context.Items.FindAsync(id);

            if (SaleId == null) return NotFound();

            _context.Items.Remove(SaleId);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}