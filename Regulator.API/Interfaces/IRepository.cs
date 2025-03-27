namespace Regulator.API.Interfaces
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        void Add(T entity);
        IQueryable<T> GetAll();
    }
}
