using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetAmparo.Entities;

namespace PetAmparo.Infra.Data.Configurations
{
    public class AdocaoConfigurations : IEntityTypeConfiguration<Adocao>
    {
        public void Configure(EntityTypeBuilder<Adocao> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.UsuarioId)
                .IsRequired();

            builder.Property(p => p.AnimalId)
               .IsRequired();

            builder.ToTable("TB_Adocao");
        }
    }
}
