using System;

namespace AppSK.DAL.Entities.Base
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Fullname {
            get => $"{FirstName} {LastName}";
        }
    }
}
