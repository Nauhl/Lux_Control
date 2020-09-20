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
    public class ClientSalesController : ControllerBase
    {
        private readonly LuxControlContext _context;
        public ClientSalesController(LuxControlContext context)
        {
            _context = context;
        }

        // GET api/clientsales
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ClientSale>>> GetClientSales()
        {
            return await _context.ClientSales.ToListAsync();
        }

        // GET api/clientsales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientSale>> GetClientSalesById(int id)
        {
            var ClientSaleId = await _context.ClientSales.FindAsync(id);
            if (ClientSaleId == null) return NotFound();
            return ClientSaleId;
        }

        // POST api/clientsales
        [HttpPost]
        public async Task<ActionResult> PostClientSale([FromBody] ClientSale clientSale)
        {
            try
            {
                _context.ClientSales.Add(clientSale);
                await _context.SaveChangesAsync();
                return Ok(clientSale);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/clientsales/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutClientSale(int id, [FromBody] ClientSale clientSale)
        {
            try
            {
                if (id != clientSale.Id) return BadRequest();

                _context.Entry(clientSale).State = EntityState.Modified;
                _context.Update(clientSale);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/clientsales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientSaleById(int id)
        {
            var ClientSaleId = await _context.ClientSales.FindAsync(id);

            if (ClientSaleId == null) NotFound();

            _context.ClientSales.Remove(ClientSaleId);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}