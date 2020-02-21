namespace M2AIntegracao.Repository.Interfaces
{
    public interface IUnidadeMedidaRepository
    {
         Task<T> GetUnidadeMedidaById(int UnidadeMedidaId);
         Task<IEnumerable<T>> GetAllUnidadeMedida();
    }
}