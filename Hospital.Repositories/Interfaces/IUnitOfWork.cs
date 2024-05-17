namespace Hospital.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> Repository<T>() where T : class;

        void Save();

        Task SaveAsync();
    }
}