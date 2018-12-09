using System;
using System.ComponentModel.DataAnnotations;

namespace AppSK.Models.Portfolio
{
    public class PortfolioModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Ресурсы")]
        public decimal Resources { get; set; }

        [Required]
        [Display(Name = "Дата старта")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Дата окончания")]
        public DateTime FinishDate { get; set; }

        [Required]
        [Display(Name = "Фактор 1")]
        public double Factor1 { get; set; }

        [Required]
        [Display(Name = "Фактор 2")]
        public double Factor2 { get; set; }

        [Required]
        [Display(Name = "Фактор 3")]
        public double Factor3 { get; set; }
    }
}