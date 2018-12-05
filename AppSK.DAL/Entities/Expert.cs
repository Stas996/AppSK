using AppSK.DAL.Entities.Base;
using System.Collections.Generic;

namespace AppSK.DAL.Entities
{
    public class Expert : BaseEntity
    {
        public User User { get; set; }

        public List<Mark> Marks { get; set; }

        public string UserId { get; set; }

        public int Activity { get; set; }
    }
}
