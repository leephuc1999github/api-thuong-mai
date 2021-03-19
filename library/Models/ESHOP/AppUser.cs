using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace library.Models.ESHOP
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Dob { get; set; }

    }
}
