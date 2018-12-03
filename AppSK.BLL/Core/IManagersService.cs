using AppSK.DAL.Entities;
using System.Linq;

namespace AppSK.BLL.Core
{
    public interface IManagersService
    {
        IQueryable<Manager> GetManagers();

        Manager GetManager(int id);

        int Save(Manager mark);

        void Delete(int id);
    }
}
