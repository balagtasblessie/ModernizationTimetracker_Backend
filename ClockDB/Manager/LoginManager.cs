using Azure.Core;
using ClockDB.Data;
using ClockDB.Repository;
using Microsoft.EntityFrameworkCore;

namespace ClockDB.Manager
{
    public class LoginManager
    {
        private readonly LoginRepository _loginRepository;
        public LoginManager(ClockDBContext context) {

            _loginRepository = new LoginRepository(context);  
        }

        public User getUser(string username, string password)
        {
            User user = _loginRepository.getUser(username, password);

            return user;
        }

    }
}
