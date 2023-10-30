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
        public ActionResult<Emprestimo> GetById(int id)
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

        [HttpPut]
        public ActionResult Put([FromBody] Emprestimo emprestimo)
        {
            try
            {
                if (emprestimo == null)
                    return NotFound();

                _EmprestimoRepository.UpdateEmprestimo(emprestimo);
                return Ok("Emprestimo Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] Emprestimo emprestimo)
        {
            try
            {
                if (emprestimo == null)
                    return NotFound();

                _EmprestimoRepository.UpdateEmprestimo(emprestimo);
                return Ok("Empr�stimo Exclu�do com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
