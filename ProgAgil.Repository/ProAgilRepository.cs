using System.Threading.Tasks;
using ProgAgil.Domain.Entities;

namespace ProgAgil.Repository
{
    public class ProAgilRepository : IProAgilRepository
    {
        private readonly ProAgilContext _context;

        public ProAgilRepository(ProAgilContext context)
        {
            _context = context;
        }

        #region GERAL
        public void Adicionar<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Atualizar<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Deletar<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
        #endregion
        #region EVENTO
        public Task<Evento> ObterEventoAsyncPorId(int id, bool palestrante = false)
        {
            throw new System.NotImplementedException();
        }
        public Task<Evento[]> ObterTodosEventosAsync(bool palestrante = false)
        {
            throw new System.NotImplementedException();
        }

        public Task<Evento[]> ObterTodosEventosAsyncPorTema(string tema, bool palestrante = false)
        {
            throw new System.NotImplementedException();
        }
        #endregion
        #region PALESTRANTE
        public Task<Palestrante> ObterPalestranteAsyncPorId(int PalestranteId)
        {
            throw new System.NotImplementedException();
        }
        public Task<Palestrante[]> ObterTodosPalestrantesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Palestrante[]> ObterTodosPalestrantesAsyncPorNome(string nome)
        {
            throw new System.NotImplementedException();
        }
        #endregion
        #region REDES SOCIAIS
        public Task<RedeSocial> ObterRedesSociaisAsyncPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<RedeSocial[]> ObterRedesSociaisPorNome(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task<RedeSocial[]> ObterTodasRedesSociaisAsync()
        {
            throw new System.NotImplementedException();
        }
        #endregion
        #region LOTES

        public Task<Lote[]> ObterTodosLotesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Lote> ObterTodosLotesAsyncPorId(int LoteId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Lote[]> ObterTodosLotesAsyncPorNome(string Nome)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}