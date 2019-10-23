using ProgAgil.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProgAgil.Repository
{
    public interface IProAgilRepository
    {
        #region Geral
         void Adicionar<T>(T entity) where T :class;
         void Atualizar<T>(T entity) where T :class;
         void Deletar<T>(T entity) where T :class;
         void DeletarLista<T>(List<T> entity) where T :class;

         Task<bool> SaveChangesAsync(); 
         #endregion

         #region Eventos
            Task<Evento[]> ObterTodosEventosPorTemaAsync(string tema,bool palestrante=false);
            Task<Evento[]> ObterTodosEventosAsync(bool palestrante=false);
            Task<Evento> ObterEventoPorIdAsync(int id,bool palestrante=false);
         #endregion

         #region Palestrantes
            Task<Palestrante[]> ObterTodosPalestrantesPorNomeAsync(string nome,bool includeEventos=false);
            Task<Palestrante[]> ObterTodosPalestrantesAsync(bool includeEventos=false);
            Task<Palestrante> ObterPalestrantePorIdAsync(int PalestranteId,bool includeEventos=false);
         #endregion

         #region Lotes
            Task<Lote[]> ObterTodosLotesPorNomeAsync(string Nome);
            Task<Lote[]> ObterTodosLotesAsync();
            Task<Lote> ObterTodosLotesPorIdAsync(int LoteId);
         #endregion

         #region Redes Sociais
            Task<RedeSocial[]> ObterRedesSociaisPorNomeAsync(string name);
            Task<RedeSocial[]> ObterTodasRedesSociaisAsync();
            Task<RedeSocial> ObterRedesSociaisPorIdAsync(int id);
         #endregion
    }
}