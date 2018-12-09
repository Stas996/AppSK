using AppSK.DAL.Entities;
using System.Collections.Generic;

namespace AppSK.BLL.Dto
{
    public class GeneratedPortfolioDto
    {
        public double GeneralNPVStocks { get; set; }

        public double GeneralNPVExternalProjects { get; set; }

        public double GeneralNPVInternalProjects { get; set; }

        public decimal GeneralInvestmentsStocks { get; set; }

        public decimal GeneralInvestmentsExternalProjects { get; set; }

        public decimal GeneralInvestmentsInternalProjects { get; set; }

        public double AvgStocksRisk { get; set; }

        public double AvgInternalProjectsRisk { get; set; }

        public double AvgExternalProjectsRisk { get; set; }

        public double AvgStocksPriority { get; set; }

        public double AvgExternalProjectsPriority { get; set; }

        public double AvgInternalProjectsPriority { get; set; }

        public List<Project> InternalProjects { get; set; }

        public List<Project> ExternalProjects { get; set; }

        public List<Stock> Stocks { get; set; }
    }
}
