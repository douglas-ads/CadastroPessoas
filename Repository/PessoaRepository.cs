using CadastroPessoas.Data;
using CadastroPessoas.Dto;
using CadastroPessoas.Entities;
using CadastroPessoas.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoas.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly DatabaseContext _context;

        public PessoaRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Pessoa Create(PessoaCreateDTO request)
        {
            var pessoa = new Pessoa
            {
                Nome = request.Nome,
                Cpf = request.Cpf,
                DataNascimento = request.DataNascimento,
                Ativo = true,
            };

            var telefone = request.Telefones.Select(telefone => new Telefone { Tipo = telefone.Tipo, Numero = telefone.Numero, Pessoa = pessoa }).ToList();
            pessoa.Telefones = telefone;

            _context.Pessoas.Add(pessoa);
            _context.SaveChangesAsync();

            return pessoa;
        }

       public bool Delete(Pessoa pessoa)
        {

            _context.Pessoas.Remove(pessoa);
            var deletado = _context.SaveChanges();
            return deletado > 0 ? true : false;
        }

        public bool ExistePessoa(int id)
        {
            return _context.Pessoas.Any(pessoa => pessoa.Id == id);
        }

        public List<Pessoa> GetAll()
        {
            var pessoas = _context.Pessoas.Where(p => p.Ativo).Include(p => p.Telefones).ToList();
            return pessoas;            
        }

        public Pessoa GetOne(int id)
        {
            return _context.Pessoas.Include(pessoa => pessoa.Telefones).Where(pessoa => pessoa.Ativo).Where(pessoa => pessoa.Id == id).FirstOrDefault();
        }

        public Pessoa Update(PessoaUpdateDTO pessoa, int id)
        {
            var p = _context.Pessoas.Where(p => p.Id == id).FirstOrDefault();
            if (p != null)
            {
                p.Nome = pessoa.Nome;
                p.Cpf = pessoa.Cpf;
                p.DataNascimento = pessoa.DataNascimento;
                p.Ativo = pessoa.Ativo;
                _context.Pessoas.Update(p);
                _context.SaveChanges();
                return p;
            }
            return null;
        }
    }
}
