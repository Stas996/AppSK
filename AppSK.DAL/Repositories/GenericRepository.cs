using System;
using System.Data.Entity;
using System.Linq;

namespace AppSK.DAL.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        DbContext _context;
        DbSet<TEntity> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public IQueryable<TEntity> GetBy(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).AsQueryable();
        }

        public TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public void Create(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
                _dbSet.Remove(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
