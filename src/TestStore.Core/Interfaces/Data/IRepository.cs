using TestStore.Core.DomainObjects;

namespace TestStore.Core.Interfaces.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }

        IQueryable<T> GetAll();

        T GetById(Guid id);

        T InsertOrUpdate(T entity);

        void Delete(Guid id);
    }
}
