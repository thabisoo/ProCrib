using Microsoft.AspNetCore.Identity;
using System;

namespace ProCrib.Domain.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ProfileImagePath { get; set; }
    }
}
