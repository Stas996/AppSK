using AppSK.BLL.Dto;
using System.IO;

namespace AppSK.BLL.Core
{
    public interface IPortfolioService
    {
        MemoryStream GeneratePdf(GeneratedPortfolioDto portfolio);

        GeneratedPortfolioDto Calculate(PortfolioDto portfolio);
    }
}
