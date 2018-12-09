using AppSK.Models.Managers;
using AppSK.Models.Marks;
using System;
using System.ComponentModel.DataAnnotations;

namespace AppSK.Models.Stocks
{
    public class StockModel
    {
        public StockModel()
        {
            StartDate = DateTime.Now;
            FinishDate = DateTime.Now.AddMonths(1);
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Необходим номер акции")]
        [Display(Name = "Номер акции")]
        public string Code { get; set; }

        public int ManagerId { get; set; }

        public ManagerItemModel Manager { get; set; }

        [Required(ErrorMessage = "Необходима дата покупки")]
        [Display(Name = "Дата покупки")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Необходима дата продажи")]
        [Display(Name = "Дата продажи")]
        public DateTime FinishDate { get; set; }

        [Required]
        [Display(Name = "Инвестиции (грн)")]
        public decimal Investments { get; set; }

        public MarkModel Mark { get; set; }
    }
}