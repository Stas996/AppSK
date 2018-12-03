using AppSK.DAL.Entities.Base;

namespace AppSK.DAL.Entities
{
    public class Mark : BaseEntity
    {
        public int ExpertId { get; set; }

        public Expert Expert { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }

        public double Risk { get; set; }

        public double NPV { get; set; }
    }
}
