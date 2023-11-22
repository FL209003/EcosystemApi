using AppLogic.UCInterfaces;
using AppLogic.UseCases;
using Domain.Entities;
using DTOs;
using Exceptions;
using Microsoft.AspNetCore.Mvc;

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
        public IUpdateEcosystem UpdateUC { get; set; }

        public EcosystemController(IAddEcosystem addUC, IRemoveEcosystem removeUC, IListEcosystem listUC, IFindEcosystem findUC, IUpdateEcosystem updateUC)
        {
            AddUC = addUC;
            RemoveUC = removeUC;
            ListUC = listUC;
            FindUC = findUC;
            UpdateUC = updateUC;
        }

        /// <summary>
        /// Retorna la lista de ecosistemas.
        /// </summary>  
        /// <returns>200 Lista de ecosistemas obtenida con éxito</returns>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
                return StatusCode(500, "Ocurrión un error inesperado.");
            }
            return Ok(ecos);
        }

        /// <summary>
        /// Retorna un ecosistema según su id.
        /// </summary>
        /// <param name="id">Id del ecosistema</param>
        /// <returns>200 Ecosistema obtenido con éxito</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // GET: api/<EcosystemController>
        [HttpGet("{id}", Name = "GetEcoById")]
        public IActionResult Get(int id)
        {
            EcosystemDTO eco;
            try
            {
                eco = FindUC.Find(id);
            }
            catch (EcosystemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado.");
            }
            return Ok(eco);
        }

        /// <summary>
        /// Retorna una lista de ecosistemas inhabitables para determinada especie.
        /// </summary>
        /// <param name="idSpecies">Id de la especie</param>
        /// <returns>200 Lista de ecosistemas inhabitables obtenidos con éxito</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("nonhabitables/species/{idSpecies}", Name = "GetUninhabitableEcos")]
        public IActionResult GetUninhabitableEcos(int idSpecies)
        {
            IEnumerable<EcosystemDTO> ecos = null;
            try
            {
                ecos = ListUC.ListUninhabitableEcos(idSpecies);
            }
            catch (SpeciesException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrión un error inesperado.");
            }
            return Ok(ecos);
        }

        /// <summary>
        /// Crea un ecosistema.
        /// </summary>
        /// <param name="e">Ecosistema a ser creado</param>
        /// <returns>201 Ecosistema creado con éxito</returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // POST api/<EcosystemController>
        [HttpPost]
        public IActionResult Post(EcosystemDTO e)
        {

            if (e == null)
            {
                return BadRequest("No se envió información para el alta.");
            }

            try
            {
                AddUC.Add(e);
                return CreatedAtRoute("GetEcoById", new { id = e.Id }, e);
            }
            catch (EcosystemException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrión un error inesperado.");
            }
        }

        // PUT api/<EcosystemController>/5
        [HttpPut]
        public IActionResult Put(EcosystemDTO e)
        {
            if (e == null)
            {
                return BadRequest("No se envió información para el alta.");
            }
            try
            {
                UpdateUC.Update(e);
                return CreatedAtRoute("GetEcoById", new { id = e.Id }, e);
            }
            catch (EcosystemException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrión un error inesperado.");
            }
        }

        /// <summary>
        /// Elimina un ecosistema según su id.
        /// </summary>
        /// <param name="id">Id del ecosistema</param>
        /// <returns>200 Ecosistema eliminado con éxito</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // DELETE api/<EcosystemController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest("El id debe ser un número positivo mayor a cero.");

            try
            {
                EcosystemDTO eco = FindUC.Find(id);
                RemoveUC.Remove(id);
                return NoContent();
            }
            catch (EcosystemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado.");
            }
        }
    }
}
