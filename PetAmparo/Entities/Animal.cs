using PetAmparo.Enumerators;

namespace PetAmparo.Entities
{
    public class Animal
    {
        public Guid Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public EnumEspecie Especie { get; set; }

        public string Raca { get; set; } = string.Empty;

        public int Idade { get; set; }

        public string Descricao { get; set; } = string.Empty;

        public DateTime DataCadastro { get; set; }

        public EnumStatusAnimal Status { get; set; }

        public Guid UsuarioId { get; set; }

        public string Imagem { get; set; } = string.Empty;

    }
}
