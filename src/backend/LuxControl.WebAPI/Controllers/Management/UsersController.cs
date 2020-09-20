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
    public class UsersController : ControllerBase
    {
        private readonly LuxControlContext _context;
        public UsersController(LuxControlContext context)
        {
            _context = context;
        }

        // GET api/users
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var UserId = await _context.Users.FindAsync(id);
            if (UserId == null) return NotFound();
            return UserId;
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromBody] User user)
        {
            // _context.Users.Add(user);
            // await _context.SaveChangesAsync();
            // return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);

            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutUser(int id, [FromBody] User user)
        {
            // if (id != user.Id) return BadRequest();
            // _context.Entry(user).State = EntityState.Modified;
            // await _context.SaveChangesAsync();
            // return NoContent();
            try
            {
                if (id != user.Id) return BadRequest();
                _context.Entry(user).State = EntityState.Modified;
                _context.Update(user);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/users/5
        [HttpPut("putusername/{id}")]
        public async Task<ActionResult> PutUsername(int id, [FromBody] User user)
        {
            try
            {
                if (id != user.Id) return BadRequest();
                _context.Entry(user).State = EntityState.Modified;
                _context.Update(user);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            // return NoContent();
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserById(int id)
        {
            var UserId = await _context.Users.FindAsync(id);

            if (UserId == null) return NotFound();

            _context.Users.Remove(UserId);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}