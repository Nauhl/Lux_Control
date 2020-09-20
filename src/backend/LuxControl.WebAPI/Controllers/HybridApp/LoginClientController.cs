using System.Net.Http;
using System.ComponentModel.Design;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using LuxControl.Core.Models.HybridApp;
using LuxControl.Infrastructure.Data;


using Microsoft.AspNetCore.Identity;

namespace LuxControl.WebAPI.Controllers.HybridApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginClientController : ControllerBase
    {
        private readonly LuxControlContext _context;
        public LoginClientController(LuxControlContext context)
        {
            _context = context;
        }

        [HttpGet("login")]
        // [HttpGet("login")]
        public async Task<IActionResult> Login(Client client)
        {

            if (ModelState.IsValid)
            {
                var userLogin = await _context.Clients.SingleOrDefaultAsync(u => u.Email == client.Email && u.Password == client.Password);

                if (userLogin != null)
                    return Ok();
            }

            return NotFound(client);

            // try
            // {
            //     if (ModelState.IsValid)
            //     {
            //         var userLogin = await _context.Clients.SingleOrDefaultAsync(u => u.Email == client.Email && u.Password == client.Password);

            //         if (userLogin != null)
            //             return Ok();
            //     }
            // }
            // catch(Exception ex)
            // {
            //     // return NotFound();
            //     return BadRequest(ex.Message);
            // }  
            // return NotFound(client);
        }

        [HttpPost]
        public async Task<ActionResult> LoginDOS([FromBody] Client client)
        {
            if (ModelState.IsValid)
            {
                var userLogin = await _context.Clients.SingleOrDefaultAsync(u => u.Email == client.Email && u.Password == client.Password);

                if (userLogin != null)
                    return Ok(client);
            }

            return NotFound(client);
            // try
            // {
            //     if (ModelState.IsValid)
            //     {
            //         var userLogin = await _context.Clients.SingleOrDefaultAsync(u => u.Password == password);

            //         if (userLogin != null)
            //             return Ok();
            //     }
            // }
            // catch(Exception ex)
            // {
            //     // return NotFound();
            //     return BadRequest(ex.Message);
            // }   
            // return NotFound();   
        }

        // GET api/loginclient/password/  EL BUENO EL CHIDO x2
        [HttpGet("{password}")]
        public async Task<IActionResult> GetIdByPasswordAction(String password)
        {
            string userID = "";
            var query = (from us in _context.Clients where us.Password == password select us.Id).SingleOrDefault();

            if (query <= 0)
                return NotFound();
            else
                userID = query.ToString();

            return Ok(userID);
        }
        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetIdByEmailAction(String email)
        {
            string userID = "";
            var query = (from us in _context.Clients where us.Email == email select us.Id).SingleOrDefault();

            if (query <= 0)
                return NotFound();
            else
                userID = query.ToString();

            return Ok(userID);
        }

        // GET api/loginusers/username   EL BUENO EL CHIDO 
        // // [HttpGet("{username}")]
        // public string GetUserIdbyUsername(String username)
        // {
        //     string usrID = "";
        //     var query = (from us in _context.Users where us.Username == username select us.Id).SingleOrDefault();

        //     if (query <= 0)
        //         return "Result not found =>" + username;
        //     else
        //         usrID = query.ToString();

        //     return usrID;
        // }

        // GET api/loginusers/name/username
        [HttpGet("name/{id}")]
        public async Task<ActionResult> GetNamebyUsernameAction(int id)
        {
            string name = "";
            var query = (from us in _context.Clients where us.Id == id select us.Name);

            if (query == null)
                return NotFound();
            else
                name = query.ToString();

            return Ok(name);
        }

        // [HttpGet("role/{username}")]
        // public string GetRoleIdbyUsername(String username)
        // {
        //     string roleID = "";
        //     var query = (from us in _context.Users where us.Username == username select us.RoleId).SingleOrDefault();

        //     if (query <= 0)
        //         return "Result not found =>" + username;
        //     else
        //         roleID = query.ToString();

        //     return roleID;
        // }


    }
}
