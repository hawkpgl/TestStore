using Microsoft.EntityFrameworkCore;
using TestStore.Core.Entities;
using TestStore.Core.Interfaces.Data;

namespace TestStore.EntityFramework.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbSet<Product> _dbSet;

        public ProductRepository(TestStoreDbContext context)
        {
            _dbSet = context.Set<Product>();

            //Seed database with test data
            context.Database.EnsureCreated();
        }

        public IQueryable<Product> GetAll()
        {
            return _dbSet;
        }

        public Product GetById(int id)
        {
            return _dbSet.First(x => x.Id == id);
        }
    }
}
