using AppSK.Models.Managers;
using System;

namespace AppSK.Models.Stocks
{
    public class StockModel
    {
        public StockModel()
        {
            PurchaseDate = DateTime.Now;
            SaleDate = DateTime.Now.AddMonths(1);
        }

        public int Id { get; set; }

        public string Code { get; set; }

        public int ManagerId { get; set; }

        public ManagerItemModel Manager { get; set; }

        public DateTime PurchaseDate { get; set; }

        public DateTime SaleDate { get; set; }
    }
}