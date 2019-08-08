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
        public async Task<Evento> ObterEventoAsyncPorId(int id, bool palestrante = false)
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
                        .OrderByDescending(d=>d.DataEvento)
                        .Where(e=>e.Id == id);

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
            query = query
                        .OrderByDescending(d=>d.DataEvento);

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> ObterTodosEventosAsyncPorTema(string tema, bool palestrante = false)
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
                        .OrderByDescending(d=>d.DataEvento)
                        .Where(e=>e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }
        #endregion
        #region PALESTRANTE
        public async Task<Palestrante> ObterPalestranteAsyncPorId(int PalestranteId,bool includeEventos=false)
        {
             IQueryable<Palestrante> query = _context.Palestrantes
                                                     .Include(r=>r.RedesSociais);
              if(includeEventos){
                  query = query.Include(pe=>pe.PalestrantesEventos)
                                .ThenInclude(p=>p.Evento);

              }
            query = query
                        .OrderBy(d=>d.Nome)
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
                        .OrderBy(d=>d.Nome);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> ObterTodosPalestrantesAsyncPorNome(string nome,bool includeEventos=false)
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