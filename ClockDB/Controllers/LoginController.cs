using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClockDB.Data;
using ClockDB.Models;
using ClockDB.Validator;
using ClockDB_Service;
using Microsoft.AspNetCore.Identity.Data;
using ClockDB.Manager;

namespace ClockDB.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginValidator _validator;
        private readonly ClockDBContext _context;
        private readonly LoginManager _loginManager;


        public LoginController(ClockDBContext context)
        {
            _context = context;
            _validator = new LoginValidator();
            _loginManager = new LoginManager(context);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] userLogin request)
        {
            if (_validator.isValid(request)  == false)
            {
                return BadRequest("Invalid credentials");
            }

            User user = _loginManager.getUser(request.UserName, request.Password);

            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            return Ok(user);
        }
    }
}
