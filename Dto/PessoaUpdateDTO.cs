using CadastroPessoas.Entities;

namespace CadastroPessoas.Dto
{
    public record struct PessoaUpdateDTO(string Nome, string Cpf, DateOnly DataNascimento, bool Ativo);
}
