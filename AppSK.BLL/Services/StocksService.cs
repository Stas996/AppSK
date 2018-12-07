using AppSK.BLL.Core;
using AppSK.DAL.Entities;
using AppSK.DAL.Repositories;
using System.Linq;

namespace AppSK.BLL.Services
{
    public class StocksService : IStocksService
    {
        private readonly IRepository<Stock> _stocksRepository;

        public StocksService(IRepository<Stock> stocksRepository)
        {
            _stocksRepository = stocksRepository;
        }

        public IQueryable<Stock> GetStocks()
        {
            var stocks = _stocksRepository.GetAll();
            return stocks;
        }

        public void Delete(int id)
        {
            _stocksRepository.Delete(id);
            _stocksRepository.Save();
        }

        public Stock GetStock(int id)
        {
            return _stocksRepository.GetById(id);
        }

        public int Save(Stock stock)
        {
            if (stock.IsNew)
            {
                _stocksRepository.Create(stock);
            }
            else
            {
                _stocksRepository.Update(stock);
            }
            _stocksRepository.Save();
            return stock.Id;
        }
    }
}
