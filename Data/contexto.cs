using Locadora.Models;
using Microsoft.EntityFrameworkCore;


namespace Locadora.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Produtora> Produtoras { get; set; }
        public DbSet<Genero> Generos { get; set; }
    }
}
