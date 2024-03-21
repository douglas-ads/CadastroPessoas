using CadastroPessoas.Dto;
using CadastroPessoas.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPessoas.Interfaces
{
    public interface IPessoaRepository
    {
        Pessoa Create(PessoaCreateDTO pessoa);
        List<Pessoa> GetAll();
        Pessoa GetOne(int id);
        Pessoa Update(PessoaUpdateDTO entity, int id);
        bool Delete(Pessoa pessoa);        
        Boolean ExistePessoa(int id);

    }
}
