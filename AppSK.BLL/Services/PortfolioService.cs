using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AppSK.BLL.Core;
using AppSK.BLL.Dto;
using AppSK.DAL.Entities;
using AppSK.DAL.Entities.Base;
using AppSK.DAL.Entities.Enums;
using AppSK.DAL.Repositories;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace AppSK.BLL.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IRepository<Project> _projectsRepository;
        private readonly IRepository<Stock> _stocksRepository;
        private const int ResourcesParts = 3;

        public PortfolioService(
            IRepository<Project> projectsRepository,
            IRepository<Stock> stocksRepository)
        {
            _projectsRepository = projectsRepository;
            _stocksRepository = stocksRepository;
        }

        public GeneratedPortfolioDto Calculate(PortfolioDto portfolio)
        {
            var availableExternalProjects = GetAvailableExternalProjects(portfolio);
            var availableInternalProjects = GetAvailableInternalProjects(portfolio);
            var availableStocks = GetAvailableStocks(portfolio);

            var info = new GeneratedPortfolioDto();

            info.GeneralNPVStocks = availableStocks.Sum(x => x.Marks.Average(m => m.NPV));
            info.GeneralNPVInternalProjects = availableInternalProjects.Sum(x => x.Marks.Average(m => m.NPV));
            info.GeneralNPVExternalProjects = availableExternalProjects.Sum(x => x.Marks.Average(m => m.NPV));
            info.GeneralInvestmentsStocks = availableStocks.Sum(x => x.Investments);
            info.GeneralInvestmentsInternalProjects = availableInternalProjects.Sum(x => x.Investments);
            info.GeneralInvestmentsExternalProjects = availableExternalProjects.Sum(x => x.Investments);
            info.AvgStocksRisk = availableStocks.Count > 0 ? availableStocks.Average(x => x.Marks.Average(m => m.Risk)) : 0;
            info.AvgInternalProjectsRisk = availableInternalProjects.Count > 0 ? availableInternalProjects.Average(x => x.Marks.Average(m => m.Risk)) : 0;
            info.AvgExternalProjectsRisk = availableExternalProjects.Count > 0 ? availableExternalProjects.Average(x => x.Marks.Average(m => m.Risk)) : 0;
            info.AvgStocksPriority = availableStocks.Count > 0 ? availableStocks.Average(x => GetPriority(portfolio, x)) : 0;
            info.AvgInternalProjectsPriority = availableInternalProjects.Count > 0 ? availableInternalProjects.Average(x => x.Marks.Average(m => m.Risk)) : 0;
            info.AvgExternalProjectsPriority = availableExternalProjects.Count > 0 ? availableExternalProjects.Average(x => x.Marks.Average(m => m.Risk)) : 0;
            info.ExternalProjects = availableExternalProjects;
            info.InternalProjects = availableInternalProjects;
            info.Stocks = availableStocks;
            

            return info;
        }

        public MemoryStream GeneratePdf(GeneratedPortfolioDto portfolio)
        {
            MemoryStream workStream = new MemoryStream();
            Document document = new Document();
            PdfWriter.GetInstance(document, workStream).CloseStream = false;

            document.Open();
            document.Add(new Paragraph("Report"));
            document.Add(new Paragraph("-----------------------------------------------------"));
            var i = 1;
            if (portfolio.ExternalProjects.Count > 0)
            {
                document.Add(new Paragraph("External projects:"));
                foreach (var p in portfolio.ExternalProjects)
                {
                    document.Add(new Paragraph($"{i}) Name: {p.Title}, Investments: {p.Investments}"));
                    i++;
                }
                document.Add(new Paragraph("-----------------"));
                document.Add(new Paragraph($"General investments: {portfolio.GeneralInvestmentsExternalProjects}"));
                document.Add(new Paragraph($"General NPV: {portfolio.GeneralNPVExternalProjects}"));
                document.Add(new Paragraph($"Average risk: {portfolio.AvgExternalProjectsRisk}"));
                document.Add(new Paragraph($"Average priority: {portfolio.AvgExternalProjectsPriority}"));
            }

            if (portfolio.InternalProjects.Count > 0)
            {
                document.Add(new Paragraph("----------------"));
                i = 1;
                document.Add(new Paragraph("Internal projects:"));
                foreach (var p in portfolio.InternalProjects)
                {
                    document.Add(new Paragraph($"{i}) Name: {p.Title}, Investments: {p.Investments}"));
                    i++;
                }
                document.Add(new Paragraph("----------------"));
                document.Add(new Paragraph($"General investments: {portfolio.GeneralInvestmentsInternalProjects}"));
                document.Add(new Paragraph($"General NPV: {portfolio.GeneralNPVInternalProjects}"));
                document.Add(new Paragraph($"Average risk: {portfolio.AvgInternalProjectsRisk}"));
                document.Add(new Paragraph($"Average priority: {portfolio.AvgInternalProjectsPriority}"));
            }

            if (portfolio.ExternalProjects.Count > 0)
            {
                document.Add(new Paragraph("----------------"));
                document.Add(new Paragraph("Stocks:"));
                i = 1;
                foreach (var s in portfolio.Stocks)
                {
                    document.Add(new Paragraph($"{i}) Stock code: {s.Code}, Investments: {s.Investments}"));
                    i++;
                }
                document.Add(new Paragraph("----------------"));
                document.Add(new Paragraph($"General investments: {portfolio.GeneralInvestmentsStocks}"));
                document.Add(new Paragraph($"General NPV: {portfolio.GeneralNPVStocks}"));
                document.Add(new Paragraph($"Average risk: {portfolio.AvgStocksRisk}"));
                document.Add(new Paragraph($"Average priority: {portfolio.AvgStocksPriority}"));
            }
            document.Close();

            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;

            return workStream;
        }

        private double GetPriority(PortfolioDto portfolio, FinanceEntity finance)
        {
            return portfolio.Factor1 * finance.Marks.Average(x => x.Factor1)
                + portfolio.Factor2 * finance.Marks.Average(x => x.Factor2)
                + portfolio.Factor3 * finance.Marks.Average(x => x.Factor3);
        }

        private List<Project> GetAvailableExternalProjects(PortfolioDto portfolio)
        {
            var availableExternalProjects = _projectsRepository
                .GetBy(x => x.Type == ProjectTypes.External
                && x.StartDate >= portfolio.StartDate
                && x.FinishDate <= portfolio.FinishDate
                && x.Investments <= portfolio.Resources / ResourcesParts).ToList();

            return availableExternalProjects.Where(x => x.Marks.Any()).ToList();
        }

        private List<Project> GetAvailableInternalProjects(PortfolioDto portfolio)
        {
            var availableInternalProjects = _projectsRepository
                .GetBy(x => x.Type == ProjectTypes.Internal
                && x.StartDate >= portfolio.StartDate
                && x.FinishDate <= portfolio.FinishDate
                && x.Investments <= portfolio.Resources / ResourcesParts).ToList();

            return availableInternalProjects.Where(x => x.Marks.Any()).ToList();
        }

        private List<Stock> GetAvailableStocks(PortfolioDto portfolio)
        {
            var availableStocks = _stocksRepository
                .GetBy(x => x.StartDate >= portfolio.StartDate
                && x.FinishDate <= portfolio.FinishDate
                && x.Investments <= portfolio.Resources / ResourcesParts).ToList();

            return availableStocks.Where(x => x.Marks.Any()).ToList();
        }
    }
}
