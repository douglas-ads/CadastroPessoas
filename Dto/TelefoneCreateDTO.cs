using CadastroPessoas.Entities;

namespace CadastroPessoas.Dto
{
    public record struct TelefoneCreateDTO(TipoTelefone Tipo, string Numero);
}
