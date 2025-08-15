using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetAmparo.Entities;
using System.Reflection.Emit;

namespace PetAmparo.Infra.Data.Configurations
{
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Raca)
               .HasMaxLength(50)
               .IsRequired();

            builder.Property(p => p.Descricao)
               .HasMaxLength(200)
               .IsRequired();

            builder.Property(p => p.UsuarioId)
               .IsRequired();

            builder.Property(p => p.DataCadastro)
               .IsRequired();

            builder.Property(p => p.Imagem)
               .IsRequired();

            builder.ToTable("TB_Animal");
        }
    }
}
