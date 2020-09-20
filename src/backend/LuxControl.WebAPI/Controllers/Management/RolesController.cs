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
    public class RolesController : ControllerBase
    {
        private readonly LuxControlContext _context;
        public RolesController(LuxControlContext context)
        {
            _context = context;
        }

        // GET api/roles
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        // GET api/roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRolesById(int id)
        {
            var RoleId = await _context.Roles.FindAsync(id);
            if (RoleId == null)
            {
                return NotFound();
            }
            return RoleId;
        }

        // POST api/roles
        [HttpPost]
        public async Task<ActionResult<Role>> PostRole([FromBody] Role role)
        {           

            try
            {
                _context.Roles.Add(role);
                await _context.SaveChangesAsync();
                return Ok(role);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }





        // PUT api/roles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, Role role)
        {
            if (id != role.Id)
            {
                return BadRequest();
            }

            _context.Entry(role).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRolesById(int id)
        {
            var RoleId = await _context.Roles.FindAsync(id);

            if (RoleId == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(RoleId);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
