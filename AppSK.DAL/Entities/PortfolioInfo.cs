﻿using AppSK.DAL.Entities.Base;

namespace AppSK.DAL.Entities
{
    public class PortfolioInfo : BaseEntity
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
    }
}
