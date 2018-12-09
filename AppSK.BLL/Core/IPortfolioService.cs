using AppSK.BLL.Dto;
using AppSK.DAL.Entities;
using System.Collections.Generic;

namespace AppSK.BLL.Core
{
    public interface IPortfolioService
    {
        byte[] GeneratePdf(PortfolioDto portfolio);

        List<Project> Calculate(PortfolioDto portfolio);
    }
}
