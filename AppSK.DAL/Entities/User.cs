using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace AppSK.DAL.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Fullname
        {
            get => $"{FirstName} {LastName}";
        }
    }
}
