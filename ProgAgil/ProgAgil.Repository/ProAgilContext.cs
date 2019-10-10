using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using ProgAgil.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ProgAgil.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace ProgAgil.Repository
{
    public class ProAgilContext : IdentityDbContext<User, Role,int,
                                                    IdentityUserClaim<int>,UserRole, IdentityUserLogin<int>,
                                                    IdentityRoleClaim<int>,IdentityUserToken<int>>
    {
        public ProAgilContext(DbContextOptions<ProAgilContext> options):base(options){}

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<PalestranteEvento> PalestranteEventos { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<UserRole>(userRole => {
                userRole.HasKey(ur=> new {ur.UserId, ur.RoleId});

                userRole.HasOne(ur => ur.Role)
                        .WithMany(r => r.UserRoles)
                        .HasForeignKey(ur => ur.RoleId)
                        .IsRequired();

                userRole.HasOne(ur => ur.User)
                        .WithMany(u => u.UserRoles)
                        .HasForeignKey(ur => ur.UserId)
                        .IsRequired();
            });
                modelbuilder.Entity<PalestranteEvento>()
                //Chave composta para a tabela auxiliar(fluentApi)
                .HasKey(pe => new { pe.PalestranteId,pe.EventoId });
        }
    }

}