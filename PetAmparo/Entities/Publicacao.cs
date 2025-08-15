namespace PetAmparo.Entities
{
    public class Publicacao
    {
        public Guid Id { get; set; }

        public string Titulo { get; set; }

        public Guid UsuarioId { get; set; }

        public string Descricao { get; set; }

        public string Imagem { get; set; }
    }
}
