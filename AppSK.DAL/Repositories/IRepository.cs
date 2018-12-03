using System;
using System.Linq;

namespace AppSK.DAL.Repositories
{
    public interface IRepository<T>
        where T : class
    {
        void Create(T item);

        T GetById(object id);

        IQueryable<T> GetAll();

        IQueryable<T> GetBy(Func<T, bool> predicate);

        void Delete(object id);

        void Delete(T item);

        void Update(T item);

        void Save();
    }
}
