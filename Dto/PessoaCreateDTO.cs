using CadastroPessoas.Entities;

namespace CadastroPessoas.Dto
{
    public record struct PessoaCreateDTO(string Nome, string Cpf, DateOnly DataNascimento, bool Ativo, List<TelefoneCreateDTO>? Telefones);
}
