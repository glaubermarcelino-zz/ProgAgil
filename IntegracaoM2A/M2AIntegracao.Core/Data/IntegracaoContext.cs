namespace M2AIntegracao.Core.Data
{
    public class IntegracaoContext :DbContext
    {
        public DbSet<UnidadeMedida> UnidadeMedida { get; set; }
        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<ItemLicitacao> ItemLicitacao { get; set; }
        public DbSet<Licitacao> Licitacao { get; set; }
        public IntegracaoContext(DbContextOptions<IntegracaoContext> options):base(options){}
        protected override OnModelCreating(ModelBuilder builder){
            //FluentApi
        }
    }
}