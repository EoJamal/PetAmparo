namespace PetAmparo.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Senha { get; set; } = string.Empty;

        public string Telefone { get; set; } = string.Empty;

        public string Descricao { get; set; } = string.Empty;

        public string Cidade { get; set; }

        public DateTime DataCadastro { get; set; }

        public string Endereco { get; set; } = string.Empty;

        public string Imagem { get; set; } = string.Empty;
    }
}
