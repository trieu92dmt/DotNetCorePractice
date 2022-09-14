using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCorePractice.Data.Entities
{
    public class AppRole : IdentityRole<Guid>
    {
        public String Description { get; set; }
    }
}
