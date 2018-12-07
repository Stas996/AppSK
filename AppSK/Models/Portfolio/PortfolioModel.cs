using System;

namespace AppSK.Models.Portfolio
{
    public class PortfolioModel
    {
        public int Id { get; set; }

        public double Resources { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }

        public double Factor1 { get; set; }

        public double Factor2 { get; set; }

        public double Factor3 { get; set; }
    }
}