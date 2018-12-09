using System.Collections.Generic;
using AppSK.BLL.Core;
using AppSK.BLL.Dto;
using AppSK.DAL.Entities;
using AppSK.DAL.Entities.Enums;
using AppSK.DAL.Repositories;

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

        public List<Project> Calculate(PortfolioDto portfolio)
        {
            var availableExternalProjects = _projectsRepository
                .GetBy(x => x.Type == ProjectTypes.External
                && x.StartDate >= portfolio.StartDate
                && x.FinishDate <= portfolio.FinishDate
                && x.Investments <= portfolio.Resources / ResourcesParts);

            var availableInternalProjects = _projectsRepository
                .GetBy(x => x.Type == ProjectTypes.Internal 
                && x.StartDate >= portfolio.StartDate
                && x.FinishDate <= portfolio.FinishDate
                && x.Investments <= portfolio.Resources / ResourcesParts);

            var availableStocks = _stocksRepository
                .GetBy(x => x.StartDate >= portfolio.StartDate
                && x.FinishDate <= portfolio.FinishDate
                && x.Investments <= portfolio.Resources / ResourcesParts);

            throw new System.NotImplementedException();
        }

        public byte[] GeneratePdf(PortfolioDto portfolio)
        {
            
            throw new System.NotImplementedException();
        }
    }
}
