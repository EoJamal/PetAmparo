namespace PetAmparo.Entities
{
    public class Publicacao
    {
        public Guid Id { get; set; }

        public string Titulo { get; set; } = string.Empty;

        public Guid UsuarioId { get; set; } 

        public string Descricao { get; set; } = string.Empty;

        public string Imagem { get; set; } = string.Empty;
    }
}
