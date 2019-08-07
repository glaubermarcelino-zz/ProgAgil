using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using ProgAgil.Domain.Entities;

namespace ProgAgil.Repository
{
    public class ProAgilContext :DbContext
    {
        public ProAgilContext(DbContextOptions<ProAgilContext> options):base(options){}

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<PalestranteEvento> PalestranteEventos { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
                modelbuilder.Entity<PalestranteEvento>()
                //Chave composta para a tabela auxiliar(fluentApi)
                .HasKey(pe => new { pe.PalestranteId,pe.EventoId });
        }
    }

}