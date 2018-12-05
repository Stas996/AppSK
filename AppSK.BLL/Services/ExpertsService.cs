using System.Linq;
using AppSK.BLL.Core;
using AppSK.DAL.Entities;
using AppSK.DAL.Repositories;

namespace AppSK.BLL.Services
{
    public class ExpertsService : IExpertsService
    {
        private readonly IRepository<Expert> _expertsRepository;

        public ExpertsService(IRepository<Expert> expertsRepository)
        {
            _expertsRepository = expertsRepository;
        }

        public void Delete(int id)
        {
            _expertsRepository.Delete(id);
        }

        public Expert GetExpert(int id)
        {
            return _expertsRepository.GetById(id);
        }

        public IQueryable<Expert> GetExperts()
        {
            return _expertsRepository.GetAll();
        }

        public int Save(Expert expert)
        {
            if (expert.IsNew)
            {
                _expertsRepository.Create(expert);
            }
            else
            {
                _expertsRepository.Update(expert);
            }
            _expertsRepository.Save();
            return expert.Id;
        }
    }
}
