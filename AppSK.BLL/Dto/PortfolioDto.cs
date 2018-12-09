using System;

namespace AppSK.BLL.Dto
{
    public class PortfolioDto
    {
        public decimal Resources { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }

        public double Factor1 { get; set; }

        public double Factor2 { get; set; }

        public double Factor3 { get; set; }
    }
}
