namespace CadastroPessoas.Entities
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf {  get; set; }
        public DateOnly DataNascimento { get; set; }
        public bool Ativo {  get; set; }
        public List<Telefone> Telefones { get; set; }
    }
}
