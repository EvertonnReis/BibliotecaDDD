using DDD.Domain.SecretariaContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibliotecariaController : ControllerBase
    {
        readonly IBibliotecariaRepository _BibliotecariaRepository;

        public BibliotecariaController(IBibliotecariaRepository BibliotecariaRepository)
        {
            _BibliotecariaRepository = BibliotecariaRepository;
        }

        // GET: api/<BibliotecariasController>
        [HttpGet]
        public ActionResult<List<Bibliotecaria>> Get()
        {
            return Ok(_BibliotecariaRepository.GetBibliotecarias());
        }

        [HttpGet("{id}")]
        public ActionResult<Bibliotecaria> GetById(int id)
        {
            return Ok(_BibliotecariaRepository.GetBibliotecariaById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Bibliotecaria> CreateBibliotecaria(Bibliotecaria Bibliotecaria)
        {
            if (Bibliotecaria.Nome.Length < 3 || Bibliotecaria.Nome.Length > 30)
            {
                return BadRequest("Nome deve ser maior que 3 e menor que 30 caracteres.");
            }
            _BibliotecariaRepository.InsertBibliotecaria(Bibliotecaria);
            return CreatedAtAction(nameof(GetById), new { id = Bibliotecaria.UserId }, Bibliotecaria);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Bibliotecaria Bibliotecaria)
        {
            try
            {
                if (Bibliotecaria == null)
                    return NotFound();

                _BibliotecariaRepository.UpdateBibliotecaria(Bibliotecaria);
                return Ok("Cliente Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] Bibliotecaria Bibliotecaria)
        {
            try
            {
                if (Bibliotecaria == null)
                    return NotFound();

                _BibliotecariaRepository.DeleteBibliotecaria(Bibliotecaria);
                return Ok("Bibliotecaria Removida com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
