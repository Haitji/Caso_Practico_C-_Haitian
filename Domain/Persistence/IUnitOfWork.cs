namespace Bootcamp_store_backend.Domain.Persistence
{
    public interface IUnitOfWork
    {
        IWork Init();
    }
}