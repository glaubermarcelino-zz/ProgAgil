using apiTrello.Domain;
using Microsoft.EntityFrameworkCore;

namespace apiTrello.Repository.Data
{
    public class apiTrelloContext : DbContext
    {
        public apiTrelloContext(DbContextOptions<apiTrelloContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(apiTrelloContext).Assembly);
        }

    }
}
