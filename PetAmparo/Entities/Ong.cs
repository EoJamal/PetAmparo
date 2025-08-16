namespace PetAmparo.Entities
{
    public class Ong
    {
        public Guid Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Senha { get; set; } = string.Empty;

        public string Telefone { get; set; } = string.Empty;

        public string Pix { get; set; } = string.Empty;

        public string Descricao { get; set; } = string.Empty;

        public string Cidade { get; set; } = string.Empty;

        public string Endereco { get; set; } = string.Empty;

        public DateTime DataCadastro { get; set; }

        public string Imagem { get; set; } = string.Empty;
    }
}
