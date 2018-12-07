using AppSK.DAL.Entities.Base;
using System;

namespace AppSK.DAL.Entities
{
    public class Stock : BaseEntity
    {
        public int ManagerId { get; set; }

        public Manager Manager { get; set; }

        public string Code { get; set; }

        public DateTime PurchaseDate { get; set; }

        public DateTime SaleDate { get; set; }
    }
}
