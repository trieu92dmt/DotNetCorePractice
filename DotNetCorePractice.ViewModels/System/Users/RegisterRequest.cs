using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCorePractice.ViewModels.System.Users
{
    public class RegisterRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime Dob { get; set; }
        public string Email { get; set; }
    }
}
