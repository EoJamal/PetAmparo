using PetAmparo.Enumerators;

namespace PetAmparo.Entities
{
    public class Adocao
    {
        public Guid Id { get; set; }

        public Guid UsuarioId { get; set; }

        public Guid AnimalId { get; set; }

        public EnumStatusAdocao Status { get; set; }
    }
}
