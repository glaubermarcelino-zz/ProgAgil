namespace M2AIntegracao.Repository.Interfaces
{
    public interface IGrupoRepository
    {
         Task<T> GetGrupoById(int GrupoId);
         Task<IEnumerable<T>> GetAllGrupo();
    }
}