using AppSK.DAL.Entities;
using System.Linq;

namespace AppSK.BLL.Core
{
    public interface IStocksService
    {
        IQueryable<Stock> GetStocks();

        Stock GetStock(int id);

        int Save(Stock stock);

        void Delete(int id);
    }
}
