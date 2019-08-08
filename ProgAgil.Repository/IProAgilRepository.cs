using ProgAgil.Domain.Entities;
using System.Threading.Tasks;

namespace ProgAgil.Repository
{
    public interface IProAgilRepository
    {
        #region Geral
         void Adicionar<T>(T entity) where T :class;
         void Atualizar<T>(T entity) where T :class;
         void Deletar<T>(T entity) where T :class;

         Task<bool> SaveChangesAsync(); 
         #endregion

         #region Eventos
            Task<Evento[]> ObterTodosEventosAsyncPorTema(string tema,bool palestrante=false);
            Task<Evento[]> ObterTodosEventosAsync(bool palestrante=false);
            Task<Evento> ObterEventoAsyncPorId(int id,bool palestrante=false);
         #endregion

         #region Palestrantes
            Task<Palestrante[]> ObterTodosPalestrantesAsyncPorNome(string nome,bool includeEventos=false);
            Task<Palestrante[]> ObterTodosPalestrantesAsync(bool includeEventos=false);
            Task<Palestrante> ObterPalestranteAsyncPorId(int PalestranteId,bool includeEventos=false);
         #endregion

         #region Lotes
            Task<Lote[]> ObterTodosLotesAsyncPorNome(string Nome);
            Task<Lote[]> ObterTodosLotesAsync();
            Task<Lote> ObterTodosLotesAsyncPorId(int LoteId);
         #endregion

         #region Redes Sociais
            Task<RedeSocial[]> ObterRedesSociaisPorNome(string name);
            Task<RedeSocial[]> ObterTodasRedesSociaisAsync();
            Task<RedeSocial> ObterRedesSociaisAsyncPorId(int id);
         #endregion
    }
}