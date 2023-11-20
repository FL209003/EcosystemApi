using AppLogic.UCInterfaces;
using Domain.Entities;
using DTOs;
using Exceptions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Ecosystem_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcosystemController : ControllerBase
    {
        public IAddEcosystem AddUC { get; set; }
        public IRemoveEcosystem RemoveUC { get; set; }
        public IListEcosystem ListUC { get; set; }
        public IFindEcosystem FindUC { get; set; }        

        public EcosystemController(IAddEcosystem addUC, IRemoveEcosystem removeUC, IListEcosystem listUC, IFindEcosystem findUC)
        {
            AddUC = addUC;
            RemoveUC = removeUC;
            ListUC = listUC;
            FindUC = findUC;
        }

        [SwaggerOperation(Summary = "Retorna la lista de ecosistemas")]
        [SwaggerResponse(200, "Lista de ecosistemas obtenida exitosamente", typeof(IEnumerable<Ecosystem>))]
        // GET: api/<EcosystemController>
        [HttpGet(Name = "GetAllEcosystems")]
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

        [SwaggerOperation(Summary = "Retorna ecosistema según su id")]
        [SwaggerResponse(200, "Ecosistema obtenido con éxito", typeof(Ecosystem))]
        // GET: api/<EcosystemController>
        [HttpGet("{id}", Name = "GetEcoById")]
        public IActionResult Get(int id)
        {
            EcosystemDTO eco = FindUC.Find(id);
            if (eco == null) return NotFound("No se encontró el ecosistema");
            else return Ok(eco);
        }

        [SwaggerOperation(Summary = "Retorna la lista de ecosistemas en los que la especie no puede habitar")]
        [SwaggerResponse(200, "Lista de ecosistemas obtenida exitosamente", typeof(IEnumerable<Ecosystem>))]
        [HttpGet("nonhabitables/species/{idSpecies}", Name = "GetUninhabitableEcos")]
        public IActionResult GetUninhabitableEcos(int idSpecies)
        {
            IEnumerable<EcosystemDTO> ecos = null;
            try
            {
                ecos = ListUC.ListUninhabitableEcos(idSpecies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrión un error inesperado");
            }
            return Ok(ecos);
        }

        [SwaggerOperation(Summary = "Crea un nuevo ecosistema")]
        [SwaggerResponse(200, "Ecosistema creado con éxito", typeof(Ecosystem))]
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
                AddUC.Add(e);
                return CreatedAtRoute("GetById", new { id = e.Id }, e);
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

        [SwaggerOperation(Summary = "Actualiza el ecosistema según su id")]
        [SwaggerResponse(200, "Ecosistema actualizado con éxito", typeof(Ecosystem))]
        // PUT api/<EcosystemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [SwaggerOperation(Summary = "Elimina ecosistema según su id")]
        [SwaggerResponse(200, "Ecosistema eliminado con éxito", typeof(Ecosystem))]
        // DELETE api/<EcosystemController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest("El id debe ser un número positivo mayor a cero");

            try
            {
                EcosystemDTO eco = FindUC.Find(id);
                if (eco == null) return NotFound("El país con el id " + id + " no existe");

                RemoveUC.Remove(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado");
            }
        }
    }
}
