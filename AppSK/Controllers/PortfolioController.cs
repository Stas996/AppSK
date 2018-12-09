using AppSK.DAL.Entities;
using AppSK.Models.Portfolio;
using AutoMapper;
using System.Web.Mvc;

namespace AppSK.Controllers
{
    public class PortfolioController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Generate(PortfolioModel portfolioModel)
        {
            var portfolio = Mapper.Map<PortfolioInfo>(portfolioModel);
            return View();
        }
    }
}