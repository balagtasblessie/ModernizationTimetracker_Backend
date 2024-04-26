using ClockDB.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace ClockDB.Repository
{
    public class LoginRepository
    {
        private readonly ClockDBContext _context;
        public LoginRepository(ClockDBContext context) {
            
            _context = context;
        }
        public User getUser(string username, string password)
        {
            User user = _context.UserTable
            .Where(u => u.UserName == username && u.Password == password)
                .Join(_context.Role, u => u.id, r => r.id, (u, r) => new { u.FullName, r.roleName })
                .FirstOrDefault();

            return user;
        }
    }


}
