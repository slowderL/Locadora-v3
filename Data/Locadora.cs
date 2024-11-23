using Locadora.Models;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Data
{
    public class LocadoraContext : DbContext
    {
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Produtora> Produtoras { get; set; }

        public LocadoraContext(DbContextOptions<LocadoraContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração do relacionamento muitos-para-muitos
            modelBuilder.Entity<Filme>()
                .HasMany(f => f.Generos)
                .WithMany(g => g.Filmes)
                .UsingEntity<Dictionary<string, object>>(
                    "FilmeGenero",
                    j => j.HasOne<Genero>().WithMany().HasForeignKey("GenId"),
                    j => j.HasOne<Filme>().WithMany().HasForeignKey("FilmeId"),
                    j =>
                    {
                        j.HasKey("FilmeId", "GenId");
                        j.ToTable("FilmeGenero");
                    });

            base.OnModelCreating(modelBuilder);

            // Relacionamento Um-para-Muitos entre Produtora e Filme
            modelBuilder.Entity<Filme>()
                .HasOne(f => f.Produtora)  // Cada filme tem uma produtora
                .WithMany(p => p.Filmes)   // Uma produtora tem muitos filmes
                .HasForeignKey(f => f.ProdId);  // A chave estrangeira para Produtora
        }
    }
}
