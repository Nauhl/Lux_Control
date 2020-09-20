using System.ComponentModel.Design;
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
    public class ServicesController : ControllerBase
    {
        private readonly LuxControlContext _context;
        public ServicesController(LuxControlContext context)
        {
            _context = context;
        }

        // GET api/services
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Service>>> GetServices()
        {
            return await _context.Services.ToListAsync();
        }

        // GET api/services/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetServiceById(int id)
        {
            var ServiceId = await _context.Services.FindAsync(id);
            if (ServiceId == null) return NotFound();
            return ServiceId;
        }

        // POST api/services
        [HttpPost]
        public async Task<ActionResult<Service>> PostService([FromBody] Service service)
        {
            try
            {
                _context.Services.Add(service);
                await _context.SaveChangesAsync();
                return Ok(service);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/services/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutService(int id, Service service)
        {
            try
            {
                if (id != service.Id) return BadRequest();

                _context.Entry(service).State = EntityState.Modified;
                _context.Update(service);
                await _context.SaveChangesAsync();


                return Ok();
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/services/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceById(int id)
        {
            var ServiceId = await _context.Services.FindAsync(id);

            if (ServiceId == null) return NotFound();

            _context.Services.Remove(ServiceId);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}