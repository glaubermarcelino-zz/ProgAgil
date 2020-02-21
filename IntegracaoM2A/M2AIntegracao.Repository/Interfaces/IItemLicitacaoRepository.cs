namespace M2AIntegracao.Repository.Interfaces
{
    public interface IItemLicitacaoRepository
    {
         Task<T> GetItemLicitacaoById(int LicitacaoId);
    }
}