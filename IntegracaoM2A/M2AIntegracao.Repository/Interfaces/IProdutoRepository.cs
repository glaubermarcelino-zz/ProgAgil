namespace M2AIntegracao.Repository.Interfaces
{
    public interface IProdutoRepository
    {
         Task<T> GetProdutoById(int ProdutoId);
         Task<IEnumerable<T>> GetAllProduto();
    }
}