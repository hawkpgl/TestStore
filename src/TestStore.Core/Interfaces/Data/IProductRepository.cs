using TestStore.Core.Entities;

namespace TestStore.Core.Interfaces.Data
{
    public interface IProductRepository
    {
        IQueryable<Product> GetAll();

        Product GetById(int id);
    }
}
