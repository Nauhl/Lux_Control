using System;
using System.ComponentModel.Design;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using LuxControl.Core.Models.HybridApp;
using LuxControl.Infrastructure.Data;

namespace LuxControl.WebAPI.Controllers.HybridApp
{
    [Route("api/[controller]")]
    [ApiController]

    public class ClientsController : ControllerBase
    {
        private readonly LuxControlContext _context;
        public ClientsController(LuxControlContext context)
        {
            _context = context;
        }

        // GET api/clients
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }

        // GET api/clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClientsById(int id)
        {
            var ClientId = await _context.Clients.FindAsync(id);
            if (ClientId == null)
            {
                return NotFound();
            }
            return ClientId;
        }

        // POST api/clients
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(
            [FromBody] Client client)
        {
            try
            {
                _context.Clients.Add(client);
                await _context.SaveChangesAsync();
                return Ok(client);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/clients/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutClient(int id,
        [FromBody] Client client)
        {
            try
            {
                if (id != client.Id)
                {
                    return BadRequest();
                }

                _context.Entry(client).State = EntityState.Modified;
                _context.Update(client);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE api/clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientById(int id)
        {
            var ClientId = await _context.Clients.FindAsync(id);

            if (ClientId == null) NotFound();

            _context.Clients.Remove(ClientId);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}