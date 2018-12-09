using System.ComponentModel.DataAnnotations;

namespace AppSK.Models.Marks
{
    public class MarkModel
    {
        public int Id { get; set; }

        public int ExpertId { get; set; }

        public int? ProjectId { get; set; }

        public int? StockId { get; set; }

        [Required]
        [Display(Name = "Риск")]
        public double Risk { get; set; }

        [Required]
        [Display(Name = "Доход")]
        public double NPV { get; set; }

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