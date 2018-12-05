using AppSK.BLL.Core;
using AppSK.DAL.Entities;
using AppSK.DAL.Repositories;
using System.Linq;

namespace AppSK.BLL.Services
{
    public class ManagersService : IManagersService
    {
        private readonly IRepository<Manager> _managersRepository;

        public ManagersService(IRepository<Manager> managersRepository)
        {
            _managersRepository = managersRepository;
        }

        public IQueryable<Manager> GetManagers()
        {
            return _managersRepository.GetAll();
        }

        public Manager GetManagerByUserId(string id)
        {
            return _managersRepository.GetBy(x => x.UserId == id).FirstOrDefault();
        }

        public void Delete(int id)
        {
            _managersRepository.Delete(id);
        }

        public Manager GetManager(int id)
        {
            return _managersRepository.GetById(id);
        }

        public int Save(Manager manager)
        {
            if (manager.IsNew)
            {
                _managersRepository.Create(manager);
            }
            else
            {
                _managersRepository.Update(manager);
            }
            _managersRepository.Save();
            return manager.Id;
        }
    }
}
