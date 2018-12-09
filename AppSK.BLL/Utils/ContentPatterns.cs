using AppSK.DAL.Entities;
using System.Collections.Generic;
using System.IO;

namespace AppSK.BLL.Utils
{
    public static class ContentPatterns
    {
        public static void GetTextPortfolioReportContent(PortfolioInfo portfolio, List<Project> projects)
        {
            using (var writer = new StreamWriter("Report.txt"))
            {
                for (var i = 0; i < projects.Count; i++)
                {
                    writer.WriteLine($"{i + 1}. Проект: {projects[i].Title}, Инвестиции: {projects[i].Investments}");
                }
                writer.WriteLine($"Общая стоимость: {portfolio.GeneralInvestments}");
                writer.WriteLine($"Общий доход: {portfolio.GeneralNPV}");
                writer.WriteLine($"Средний риск: {portfolio.AvgRisk}");
                writer.WriteLine($"Средняя важность: {portfolio.AvgPriority}");
            }
        }
    }
}
