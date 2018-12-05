using AppSK.DAL.Entities;
using System.Linq;

namespace AppSK.BLL.Core
{
    public interface IManagersService
    {
        IQueryable<Manager> GetManagers();

        Manager GetManager(int id);

        Manager GetManagerByUserId(string id);

        int Save(Manager manager);

        void Delete(int id);
    }
}
