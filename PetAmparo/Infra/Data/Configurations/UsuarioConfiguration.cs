using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetAmparo.Entities;

namespace PetAmparo.Infra.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Email)
               .HasMaxLength(150)
               .IsRequired();

            builder.Property(p => p.Senha)
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(p => p.Telefone)
               .HasMaxLength(20)
               .IsRequired();

            builder.Property(p => p.Descricao)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.Cidade)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.DataCadastro)
               .IsRequired();

            builder.Property(p => p.Endereco)
               .HasMaxLength(200)
               .IsRequired();

            builder.Property(p => p.Imagem)
               .IsRequired();

            builder.ToTable("TB_Usuario");
        }
    }
}
