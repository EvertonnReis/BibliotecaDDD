using DDD.Domain.SecretariaContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        readonly ILivroRepository _LivroRepository;

        public LivroController(ILivroRepository LivroRepository)
        {
            _LivroRepository = LivroRepository;
        }

        // GET: api/<AlunosController>
        [HttpGet]
        public ActionResult<List<Livro>> Get()
        {
            return Ok(_LivroRepository.GetLivros());
        }

        [HttpGet("{id}")]
        public ActionResult<Livro> GetById(int id)
        {
            return Ok(_LivroRepository.GetLivroById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Aluno> CreateLivro(Livro Livro)
        {
            _LivroRepository.InsertLivro(Livro);
            return CreatedAtAction(nameof(GetById), new { id = Livro.LivroId }, Livro);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Livro Livro)
        {
            try
            {
                if (Livro == null)
                    return NotFound();

                _LivroRepository.UpdateLivro(Livro);
                return Ok("Livro Atualizada com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] Livro Livro)
        {
            try
            {
                if (Livro == null)
                    return NotFound();

                _LivroRepository.DeleteLivro(Livro);
                return Ok("Livro Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
