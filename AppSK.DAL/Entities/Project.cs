﻿using AppSK.DAL.Entities.Base;
using AppSK.DAL.Entities.Enums;
using System;

namespace AppSK.DAL.Entities
{
    public class Project : BaseEntity
    {
        public int ManagerId { get; set; }

        public ProjectTypes Type { get; set; }

        public Manager Manager { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }

        public int Investments { get; set; }
    }
}
