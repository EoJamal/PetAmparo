using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetAmparo.Entities;

namespace PetAmparo.Infra.Data.Configurations
{
    public class PublicacaoConfigurations : IEntityTypeConfiguration<Publicacao>
    {
        public void Configure(EntityTypeBuilder<Publicacao> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Titulo)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Descricao)
               .HasMaxLength(150)
               .IsRequired();

            builder.Property(p => p.Descricao)
               .HasMaxLength(200)
               .IsRequired();

            builder.Property(p => p.UsuarioId)
               .IsRequired();

            builder.Property(p => p.Imagem)
               .IsRequired();

            builder.ToTable("TB_Publicacao");
        }
    }
}
