using Microsoft.EntityFrameworkCore;
using PetAmparo.Entities;
using PetAmparo.Infra.Data.Configurations;

namespace PetAmparo.Infra.Data.Context
{
    public class PetAmparoContext : DbContext
    {
        public DbSet<Animal> AnimalSet { get; set; }

        public DbSet<Usuario> UsuarioSet { get; set; }

        public DbSet<Ong> OngSet { get; set; }

        public DbSet<Publicacao> PublicacaoSet { get; set; }

        public DbSet<Adocao> AdocaoSet { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new AnimalConfiguration());
            modelBuilder.ApplyConfiguration(new AdocaoConfigurations());
            modelBuilder.ApplyConfiguration(new OngConfigurations());
            modelBuilder.ApplyConfiguration(new PublicacaoConfigurations());
               
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string conexao = "server=localhost;database=PetAmparo;port=3306;uid=root";
            optionsBuilder.UseMySql(conexao, ServerVersion.AutoDetect(conexao));

            base.OnConfiguring(optionsBuilder);
        }

    }
}
