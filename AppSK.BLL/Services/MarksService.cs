using AppSK.BLL.Core;
using AppSK.DAL.Entities;
using AppSK.DAL.Repositories;
using System.Linq;

namespace AppSK.BLL.Services
{
    public class MarksService : IMarksService
    {
        private readonly IRepository<Mark> _marksRepository;

        public MarksService(IRepository<Mark> marksRepository)
        {
            _marksRepository = marksRepository;
        }

        public IQueryable<Mark> GetMarks()
        {
            return _marksRepository.GetAll();
        }

        public void Delete(int id)
        {
            _marksRepository.Delete(id);
        }

        public Mark GetMark(int id)
        {
            return _marksRepository.GetById(id);
        }

        public int Save(Mark mark)
        {
            if (mark.IsNew)
            {
                _marksRepository.Create(mark);
            }
            else
            {
                _marksRepository.Update(mark);
            }
            _marksRepository.Save();
            return mark.Id;
        }
    }
}
