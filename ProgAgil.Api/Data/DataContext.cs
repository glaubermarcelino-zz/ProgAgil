using Microsoft.EntityFrameworkCore;
using ProgAgil.Domain.Entities;

namespace ProgAgil.Api.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options){}
        public DbSet<Evento> Eventos { get; set; }
    }

}