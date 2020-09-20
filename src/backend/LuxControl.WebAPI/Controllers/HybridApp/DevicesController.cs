using System;
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
    public class DevicesController : ControllerBase
    {
        private readonly LuxControlContext _context;
        public DevicesController(LuxControlContext context)
        {
            _context = context;
        }

        // GET api/devices
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Device>>> GetDevices()
        {
            return await _context.Devices.ToListAsync();
        }

        // GET api/devices/5
        [HttpGet("{id}")]
        public async  Task<ActionResult<Device>> GetDevicesById(int id)
        {
            var DeviceId = await _context.Devices.FindAsync(id);
            if (DeviceId == null)
            {
                return NotFound();
            }
            return DeviceId;
        }

        // POST api/devices
        [HttpPost]
        public async Task<ActionResult<Device>> PostRole(Device device)
        {
            _context.Devices.Add(device);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDevicesById), new { id = device.Id }, device);
        }

        // PUT api/devices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDevice(int id, Device device)
        {
            if (id != device.Id)
            {
                return BadRequest();
            }

            _context.Entry(device).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // DELETE api/devices/5
       [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevicesById(int id)
        {
            var DeviceId = await _context.Devices.FindAsync(id);

            if (DeviceId == null)
            {
                return NotFound();
            }

            _context.Devices.Remove(DeviceId);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}