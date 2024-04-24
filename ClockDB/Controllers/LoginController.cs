using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClockDB.Data;
using ClockDB.Models;
using Microsoft.AspNetCore.Identity.Data;

namespace ClockDB.Controllers
{
    public class LoginController : Controller
    {
        private readonly ClockDBContext _context;

        public LoginController(ClockDBContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] userLogin request)
        {
            if (request == null || string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Invalid credentials");
            }

            var user = _context.UserTable
                .Where(u => u.UserName == request.UserName && u.Password == request.Password)
                .Join(_context.Role, u => u.id, r => r.id, (u, r) => new { u.FullName, r.roleName })
                .FirstOrDefault();

            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            return Ok(user);
        }
    }
}
