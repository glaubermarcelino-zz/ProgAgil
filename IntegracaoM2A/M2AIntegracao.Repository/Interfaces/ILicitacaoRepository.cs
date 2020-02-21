namespace M2AIntegracao.Repository.Interfaces
{
    public interface ILicitacaoRepository
    {
         Task<T> GetLicitacaoById(int LicitacaoId);
         Task<IEnumerable<T>> GetAllLicitacao();
    }
}