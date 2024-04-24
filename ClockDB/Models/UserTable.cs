using Azure.Identity;
using Microsoft.Build.Framework;

namespace ClockDB.Models
{
    public class UserTable
    {
        public int id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

    }

    public class userLogin
    {
        [Required]
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
