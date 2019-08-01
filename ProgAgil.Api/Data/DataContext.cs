using Microsoft.EntityFrameworkCore;
using ProgAgil.Api.Models;

namespace ProgAgil.Api.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options){}
        public DbSet<Evento> Eventos { get; set; }
    }

}