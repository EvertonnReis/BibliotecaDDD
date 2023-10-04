using DDD.Domain.SecretariaContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmprestimoController : ControllerBase
    {
        readonly IEmprestimoRepository _EmprestimoRepository;

        public EmprestimoController(IEmprestimoRepository EmprestimoRepository)
        {
            _EmprestimoRepository = EmprestimoRepository; 
        }

        [HttpGet]
        public ActionResult<List<Emprestimo>> Get()
        {
            return Ok(_EmprestimoRepository.GetEmprestimos());
        }

        [HttpGet("{id}")]
        public ActionResult<Aluno> GetById(int id)
        {
            return Ok(_EmprestimoRepository.GetEmprestimoById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Emprestimo> CreateEmprestimo(int idAluno, int idLivro, int idBibliotecaria)
        {
            Emprestimo EmprestimoIdSaved = _EmprestimoRepository.InsertEmprestimo(idAluno, idLivro, idBibliotecaria);
            return CreatedAtAction(nameof(GetById), new { id = EmprestimoIdSaved.EmprestimoId }, EmprestimoIdSaved);
        }

        //[HttpPut]
        //public ActionResult Put([FromBody] Aluno aluno)
        //{
        //    try
        //    {
        //        if (aluno == null)
        //            return NotFound();

        //        _alunoRepository.UpdateAluno(aluno);
        //        return Ok("Cliente Atualizado com sucesso!");
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //// DELETE api/values/5
        //[HttpDelete()]
        //public ActionResult Delete([FromBody] Aluno aluno)
        //{
        //    try
        //    {
        //        if (aluno == null)
        //            return NotFound();

        //        _alunoRepository.DeleteAluno(aluno);
        //        return Ok("Cliente Removido com sucesso!");
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }

        //}

    }
}
