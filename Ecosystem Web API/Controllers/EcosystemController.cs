using AppLogic.UCInterfaces;
using DTOs;
using Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Ecosystem_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcosystemController : ControllerBase
    {
        public IListEcosystem ListUC { get; set; }
        public IAddEcosystem AddEcoUC { get; set; }

        public EcosystemController(IListEcosystem listUC, IAddEcosystem addEcoUC)
        {
            ListUC = listUC;
            AddEcoUC = addEcoUC;
        }

        // GET: api/<EcosystemController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<EcosystemDTO> ecos = null;

            try
            {
                ecos = ListUC.List();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrión un error inesperado");
            }

            return Ok(ecos);
        }

        // GET api/<EcosystemController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EcosystemController>
        [HttpPost]
        public IActionResult Post(EcosystemDTO e)
        {

            if (e == null)
            {
                return BadRequest("No se envió información para el alta");
            }

            try
            {
                AddEcoUC.Add(e);
                return CreatedAtRoute("BuscarPorId", new { id = e.Id }, e);
            }
            catch (EcosystemException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrión un error inesperado");
            }
        }

        // PUT api/<EcosystemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EcosystemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
