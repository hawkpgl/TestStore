using TestStore.Core.DomainObjects;
using TestStore.Core.Interfaces.Data;

namespace TestStore.EntityFramework.Repositories
{
    public class Repository<T> : RepositoryBase<T>, IRepository<T> where T : Entity, IAggregateRoot
    {
        public Repository(TestStoreDbContext context)
        : base(context)
        {
        }
    }
}
