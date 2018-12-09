using AppSK.BLL.Core;
using AppSK.BLL.Dto;
using AppSK.DAL.Entities;
using AppSK.Models.Portfolio;
using AutoMapper;
using System.Web.Mvc;

namespace AppSK.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public FileStreamResult Generate(PortfolioModel portfolioModel)
        {
            var portfolio = Mapper.Map<PortfolioDto>(portfolioModel);
            var generatedPortfolio = _portfolioService.Calculate(portfolio);
            var pdf = _portfolioService.GeneratePdf(generatedPortfolio);
            return new FileStreamResult(pdf, "application/pdf");
        }
    }
}