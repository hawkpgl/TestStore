using Microsoft.EntityFrameworkCore;
using TestStore.Core.DomainObjects;
using TestStore.Core.Interfaces.Data;

namespace TestStore.EntityFramework.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : Entity, IAggregateRoot
    {
        private readonly TestStoreDbContext _context;
        private readonly DbSet<T> _dbSet;

        public IUnitOfWork UnitOfWork => _context;

        public RepositoryBase(TestStoreDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();

            //Seed database with test data
            context.Database.EnsureCreated();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public virtual T GetById(Guid id)
        {
            return _dbSet.First(x => x.Id == id);
        }

        public virtual T InsertOrUpdate(T entity)
        {
            if (_dbSet.Any(x => x.Id == entity.Id))
            {
                _dbSet.Update(entity);
            }
            else
            {
                _dbSet.Add(entity);
            }

            return entity;
        }

        public virtual void Delete(Guid id)
        {
            var entity = GetById(id);

            _dbSet.Remove(entity);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
