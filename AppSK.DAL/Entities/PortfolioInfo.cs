using AppSK.DAL.Entities.Base;

namespace AppSK.DAL.Entities
{
    public class PortfolioInfo : BaseEntity
    {
        public double GeneralNPV { get; set; }

        public double GeneralInvestments { get; set; }

        public double AvgRisk { get; set; }

        public double AvgPriority { get; set; }
    }
}
