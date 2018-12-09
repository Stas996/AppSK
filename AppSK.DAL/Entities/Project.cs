using AppSK.DAL.Entities.Base;
using AppSK.DAL.Entities.Enums;
using System.Collections.Generic;

namespace AppSK.DAL.Entities
{
    public class Project : FinanceEntity
    {
        public ProjectTypes Type { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<Mark> Marks { get; set; }
    }
}
