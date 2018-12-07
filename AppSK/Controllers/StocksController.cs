using AppSK.BLL.Core;
using AppSK.DAL.Entities;
using AppSK.Models.Marks;
using AppSK.Models.Stocks;
using AutoMapper;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AppSK.Controllers
{
    [Authorize]
    public class StocksController : Controller
    {
        private readonly IStocksService _stocksService;
        private readonly IManagersService _managersService;
        private readonly IMarksService _marksService;

        public StocksController(IStocksService stocksService,
            IMarksService marksService,
            IManagersService managersService)
        {
            _stocksService = stocksService;
            _managersService = managersService;
            _marksService = marksService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var stocks = _stocksService.GetStocks().ToList();
            var viewStocks = Mapper.Map<List<StockModel>>(stocks);
            return View(viewStocks);
        }

        [HttpGet]
        public ActionResult Details(int stockId)
        {
            var stock = _stocksService.GetStock(stockId);
            var viewStock = Mapper.Map<StockModel>(stock);
            viewStock.Mark = Mapper.Map<MarkModel>(_marksService.GetMarkByStock(stockId));
            return View(viewStock);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int stockId)
        {
            var stock = _stocksService.GetStock(stockId);
            var viewStock = Mapper.Map<StockModel>(stock);
            return View(viewStock);
        }

        [HttpGet]
        public ActionResult Delete(int stockId)
        {
            _stocksService.Delete(stockId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(StockModel stockModel)
        {
            var stock = Mapper.Map<Stock>(stockModel);
            var stocks = _stocksService.Save(stock);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(StockModel stockModel)
        {
            var manager = GetCurrentManager();
            stockModel.ManagerId = manager.Id;

            var stock = Mapper.Map<Stock>(stockModel);
            var stocks = _stocksService.Save(stock);
            return RedirectToAction("Index");
        }

        private Manager GetCurrentManager()
        {
            var userId = User.Identity.GetUserId<string>();
            if (userId == null)
            {
                return null;
            }
            var manager = _managersService.GetManagerByUserId(userId);
            return manager;
        }
    }
}