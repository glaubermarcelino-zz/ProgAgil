using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Licenciamento.domain.Identity;
using Microsoft.AspNetCore.Identity;
using Licenciamento.domain.Entities;

namespace Licenciamento.repository.Data
{
    public class LicenciamentoContext : IdentityDbContext<User, Role, int,
                                                    IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
                                                    IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public LicenciamentoContext(DbContextOptions<LicenciamentoContext> options) : base(options) { }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<CliPayment> CliPayment { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Setando schema padrão para a conexão
            //modelBuilder.HasDefaultSchema("public");
            //nomeando a tabela para que o entityframework a reconheça
            modelBuilder.Entity<Machine>(mac => mac.ToTable("machine"));
            modelBuilder.Entity<CliPayment>(mac => mac.ToTable("clipayment"));
            // Definindo a chave primaria da tabela
            modelBuilder.Entity<Machine>(mac => mac.HasKey(mc => mc.id_mach));
            modelBuilder.Entity<CliPayment>(mac => mac.HasKey(mc => mc.CliPaymentId));

            modelBuilder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                        .WithMany(r => r.UserRoles)
                        .HasForeignKey(ur => ur.RoleId)
                        .IsRequired();

                userRole.HasOne(ur => ur.User)
                        .WithMany(u => u.UserRoles)
                        .HasForeignKey(ur => ur.UserId)
                        .IsRequired();
            });

        }
    }
}
