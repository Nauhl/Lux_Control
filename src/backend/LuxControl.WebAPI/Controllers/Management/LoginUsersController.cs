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


using Microsoft.AspNetCore.Identity;

namespace LuxControl.WebAPI.Controllers.Management
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginUsersController : ControllerBase
    {
        private readonly LuxControlContext _context;
        public LoginUsersController(LuxControlContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        // [HttpGet("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {

            if (ModelState.IsValid)
            {
                var userLogin = await _context.Users.SingleOrDefaultAsync(u => u.Username == user.Username && u.Password == user.Password && u.RoleId == user.RoleId);

                if (userLogin != null)
                    return Ok();
            }

            return NotFound(user);
        }

        // [HttpPost("login_")]
        // [HttpGet("login_")]
        // public async Task<String> Login_([FromBody] User user)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         var userLogin = await _context.Users.SingleOrDefaultAsync(u => u.Username == user.Username && u.Password == user.Password && u.RoleId == user.RoleId);

        //         if (userLogin != null)
        //             HttpContext.Session.SetString("userId", userLogin.Id.ToString());
        //     }
        //     return HttpContext.Session.GetString("userId");
        // }

        // GET api/users/username/  EL BUENO EL CHIDO x2
        [HttpGet("{username}")]
        public async Task<IActionResult> GetUserIdbyUsernameAction(String username)
        {
            string userID = "";
            var query = (from us in _context.Users where us.Username == username select us.Id).SingleOrDefault();

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

        // GET api/loginusers/role/username
        [HttpGet("role/{username}")]
        public async Task<ActionResult> GetRoleIdbyUsernameAction(String username)
        {
            string roleID = "";
            var query = (from us in _context.Users where us.Username == username select us.RoleId).SingleOrDefault();

            if (query <= 0)
                return NotFound();
            else
                roleID = query.ToString();

            return Ok(roleID);
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
