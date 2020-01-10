namespace licenciamento.repository.Data
{
    public class LicenciamentoContext: DbContext
    {
        public DbSet<Machine> Machines { get; set; }
        public LicenciamentoContext(DbContextOptions<LicenciamentoContext> options):base(options){}
        protected override onModelCreating(ModelBuilder builder){
        
        }
    }
}