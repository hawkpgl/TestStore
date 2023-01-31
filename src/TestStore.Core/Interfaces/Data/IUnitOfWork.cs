namespace TestStore.Core.Interfaces.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
