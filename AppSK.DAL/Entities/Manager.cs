﻿using AppSK.DAL.Entities.Base;
using System.Collections.Generic;

namespace AppSK.DAL.Entities
{
    public class Manager : BaseEntity
    {
        public User User { get; set; }

        public string UserId { get; set; }

        public string CompanyName { get; set; }

        public List<Project> Projects { get; set; }
    }
}
