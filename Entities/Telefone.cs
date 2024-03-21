using System.Text.Json.Serialization;

namespace CadastroPessoas.Entities
{
    public enum TipoTelefone
    {
        Celular = 0,
        Residencial = 1,
        Comercial = 2
    }
    public class Telefone
    {
        public int Id { get; set; }
        public TipoTelefone Tipo {  get; set; }
        public string Numero { get; set; }
        public int PessoaId { get; set; }
        [JsonIgnore]
        public Pessoa Pessoa { get; set; }
    }
}
