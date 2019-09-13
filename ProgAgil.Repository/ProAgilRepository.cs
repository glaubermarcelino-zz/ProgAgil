using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        public async Task<Evento> ObterEventoPorIdAsync(int EventoId, bool palestrante = false)
        {
              IQueryable<Evento> query = _context.Eventos
                                                .Include(c=>c.Lotes)
                                                .Include(c=>c.RedesSociais);
            if(palestrante){
                query = query
                            
                            .Include(pe=>pe.PalestrantesEventos)
                            .ThenInclude(p=>p.Palestrante);
            }
            query = query
                        .AsNoTracking()
                        .OrderBy(d=>d.Id)
                        .Where(e=>e.Id == EventoId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Evento[]> ObterTodosEventosAsync(bool palestrante = false)
        {
            IQueryable<Evento> query = _context.Eventos
                                                .Include(c=>c.Lotes)
                                                .Include(c=>c.RedesSociais);
              if(palestrante){
                query = query
                            .Include(pe=>pe.PalestrantesEventos)
                            .ThenInclude(p=>p.Palestrante);
            }
            query = query.AsNoTracking()
                        .OrderBy(d=>d.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> ObterTodosEventosPorTemaAsync(string tema, bool palestrante = false)
        {
             IQueryable<Evento> query = _context.Eventos
                                                .Include(c=>c.Lotes)
                                                .Include(c=>c.RedesSociais);
            if(palestrante){
                query = query
                            .Include(pe=>pe.PalestrantesEventos)
                            .ThenInclude(p=>p.Palestrante);
            }
            query = query
                        .OrderByDescending(d=>d.Tema)
                        .Where(e=>e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }
        #endregion
        #region PALESTRANTE
        public async Task<Palestrante> ObterPalestrantePorIdAsync(int PalestranteId,bool includeEventos=false)
        {
             IQueryable<Palestrante> query = _context.Palestrantes
                                                     .Include(r=>r.RedesSociais);
              if(includeEventos){
                  query = query.Include(pe=>pe.PalestrantesEventos)
                                .ThenInclude(p=>p.Evento);

              }
            query = query
                        .OrderBy(d=>d.Id)
                        .Where(p=>p.Id == PalestranteId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Palestrante[]> ObterTodosPalestrantesAsync(bool includeEventos=false)
        {
             IQueryable<Palestrante> query = _context.Palestrantes
                                                     .Include(r=>r.RedesSociais);
              if(includeEventos){
                  query = query.Include(pe=>pe.PalestrantesEventos)
                                .ThenInclude(p=>p.Evento);

              }
            query = query
                        .OrderBy(d=>d.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> ObterTodosPalestrantesPorNomeAsync(string nome,bool includeEventos=false)
        {
             IQueryable<Palestrante> query = _context.Palestrantes
                                                     .Include(r=>r.RedesSociais);
              if(includeEventos){
                  query = query.Include(pe=>pe.PalestrantesEventos)
                                .ThenInclude(p=>p.Evento);
              }
            query = query
                        .OrderBy(d=>d.Nome)
                        .Where(p=>p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }
        #endregion
        #region REDES SOCIAIS
        public Task<RedeSocial> ObterRedesSociaisPorIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<RedeSocial[]> ObterRedesSociaisPorNomeAsync(string name)
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

        public Task<Lote> ObterTodosLotesPorIdAsync(int LoteId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Lote[]> ObterTodosLotesPorNomeAsync(string Nome)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}