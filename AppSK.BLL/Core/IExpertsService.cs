using AppSK.DAL.Entities;
using System.Linq;

namespace AppSK.BLL.Core
{
    public interface IExpertsService
    {
        IQueryable<Expert> GetExperts();

        Expert GetExpert(int id);

        Expert GetExpertByUserId(string id);

        int Save(Expert expert);

        void Delete(int id);
    }
}
