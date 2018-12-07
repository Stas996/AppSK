namespace AppSK.Models.Marks
{
    public class MarkModel
    {
        public int ExpertId { get; set; }

        public int? ProjectId { get; set; }

        public int? StockId { get; set; }

        public double Risk { get; set; }

        public double NPV { get; set; }

        public double Factor1 { get; set; }

        public double Factor2 { get; set; }

        public double Factor3 { get; set; }
    }
}