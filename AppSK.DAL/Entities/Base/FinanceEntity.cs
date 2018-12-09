using System;
using System.Collections.Generic;

namespace AppSK.DAL.Entities.Base
{
    public class FinanceEntity : BaseEntity
    {
        public int ManagerId { get; set; }

        public Manager Manager { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }

        public decimal Investments { get; set; }

        public virtual List<Mark> Marks { get; set; }
    }
}
