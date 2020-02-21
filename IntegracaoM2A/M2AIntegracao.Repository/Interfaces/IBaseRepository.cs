namespace M2AIntegracao.Repository.Interfaces
{
    public interface IBaseRepository
    {
         void Add<T>(T entity);
         void Remove<T>(T entity);
         void Update<T>(T entity);
         void Delete<T>(T entity);
         void SaveChanges<T>(T entity);
    }
}