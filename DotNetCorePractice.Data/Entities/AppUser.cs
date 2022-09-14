﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCorePractice.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime Dob { get; set; }
        public List<Cart> Carts { get; set; }
        public List<Order> Orders { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
