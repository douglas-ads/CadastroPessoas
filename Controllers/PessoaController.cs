using CadastroPessoas.Data;
using CadastroPessoas.Dto;
using CadastroPessoas.Entities;
using CadastroPessoas.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoas.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepository _pessoaRepository;
        public PessoaController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }
        [HttpPost]
        public ActionResult Criar(PessoaCreateDTO pessoa)
        {
            var pessoaCriada = _pessoaRepository.Create(pessoa);
            return Ok(pessoaCriada);
        }
        [HttpGet]
        public ActionResult RecuperarTudo()
        {
            var pessoas = _pessoaRepository.GetAll();
            return Ok(pessoas);
        }
        [HttpGet("{id}")]
        public ActionResult RecuperaUm(int id)
        {
            var pessoa = _pessoaRepository.GetOne(id);
            if (pessoa == null)
                return NotFound();

            return Ok(pessoa);
        }
        [HttpDelete("{id}")]
        public ActionResult ApagarUm(int id)
        {
            var pessoa = _pessoaRepository.GetOne(id);
            if (pessoa == null)
                return NotFound();

            return Ok(_pessoaRepository.Delete(pessoa));
        }
        [HttpPut("{id}")]
        public ActionResult Atualizar(PessoaUpdateDTO pessoa, int id)
        {
            var pessoaAtualizada = _pessoaRepository.Update(pessoa, id);
            if (pessoaAtualizada == null)
                return NotFound();
            return Ok(pessoaAtualizada);
        }


    }
}
