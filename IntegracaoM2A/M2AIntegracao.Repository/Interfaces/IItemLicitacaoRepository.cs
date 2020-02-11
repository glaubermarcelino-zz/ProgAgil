namespace M2AIntegracao.Repository.Interfaces
{
    public interface IItemLicitacaoRepository
    {
         
         void Add<T>(T entity): Where<T>;
         void Remove<T>(T entity): Where<T>;
         void Update<T>(T entity): Where<T>;
         void Delete<T>(T entity): Where<T>;
         void SaveChanges<T>(T entity): Where<T>;

         Task<ItemLicitacao>GetItemLicitacaoById(int LicitacaoId);
    }
}