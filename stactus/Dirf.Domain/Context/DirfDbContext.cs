using Dirf.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dirf.Domain.Context
{
    public class DirfDbContext :DbContext
    {
        public DirfDbContext(DbContextOptions options):base(options){}
        public DbSet<Arquivo> Arquivo { get; set; }
    }
}