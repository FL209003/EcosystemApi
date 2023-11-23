using AppLogic.UCInterfaces;
using DTOs;
using Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecosystem_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeciesController : ControllerBase
    {
        public IAddSpecies AddUC { get; set; }
        public IListSpecies ListUC { get; set; }
        public IFindSpecies FindUC { get; set; }
        public IRemoveSpecies RemoveUC { get; set; }
        public IUpdateSpecies UpdateUC { get; set; }

        public SpeciesController(IAddSpecies addUC, IListSpecies listUC, IFindSpecies findUC,
            IRemoveSpecies removeUC, IUpdateSpecies updateUC)
        {
            AddUC = addUC;
            ListUC = listUC;
            FindUC = findUC;
            RemoveUC = removeUC;
            UpdateUC = updateUC;
        }

        /// <summary>
        /// Retorna la lista de especies.
        /// </summary>        
        /// <returns>200 Lista de especies obtenida con éxito</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // GET: api/<SpeciesController>
        [HttpGet(Name = "GetAllSpecies")]
        public IActionResult Get()
        {
            IEnumerable<SpeciesDTO> s = null;

            try
            {
                s = ListUC.List();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrión un error inesperado");
            }

            return Ok(s);
        }

        /// <summary>
        /// Retorna una lista de especies ordenada por el nombre científico.
        /// </summary>        
        /// <returns>200 Lista de especies obtenida con éxito</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("OrderByScientific", Name = "OrderScientific")]
        public IActionResult GetOrderByScientific()
        {
            IEnumerable<SpeciesDTO> s = null;

            try
            {
                s = ListUC.ListByCientificName();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrión un error inesperado");
            }

            return Ok(s);
        }

        /// <summary>
        /// Retorna una lista de especies ordenada según su peligrosidad.
        /// </summary>        
        /// <returns>200 Lista de especies obtenida con éxito</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("Endangered", Name = "Endangered")]
        public IActionResult GetEndangered()
        {
            IEnumerable<SpeciesDTO> s = null;

            try
            {
                s = ListUC.ListByDangerOfExtinction();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrión un error inesperado");
            }

            return Ok(s);
        }

        /// <summary>
        /// Retorna una lista de especies ordenada según su peso.
        /// </summary>   
        /// <param name="min">Peso mínimo</param>
        /// <param name="max">Peso máximo</param>
        /// <returns>200 Lista de especies obtenida con éxito</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("Weight/{min}/{max}", Name = "Weight")]
        public IActionResult GetByWeight(int min, int max)
        {
            IEnumerable<SpeciesDTO> s = null;
            try
            {
                s = ListUC.ListByWeight(min, max);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrión un error inesperado");
            }

            return Ok(s);
        }

        /// <summary>
        /// Retorna una lista de especies según su ecosistema.
        /// </summary>        
        /// <param name="id">Id del ecosistema</param>
        /// <returns>200 Lista de especies obtenida con éxito</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("byEco/{id}", Name = "ByEco")]
        public IActionResult GetByEcosystem(int id)
        {
            IEnumerable<SpeciesDTO> s = null;

            try
            {
                s = ListUC.ListByEco(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrión un error inesperado");
            }

            return Ok(s);
        }

        /// <summary>
        /// Retorna una especie según su id.
        /// </summary>       
        /// <param name="id">Id de la especie</param>
        /// <returns>200 Lista de especies obtenida con éxito</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // GET: api/<SpeciesCOntroller>
        [HttpGet("{id}", Name = "GetSpeciesById")]
        public IActionResult Get(int id)
        {
            SpeciesDTO s = FindUC.Find(id);
            if (s == null) return NotFound("No se encontró la especie.");
            else return Ok(s);
        }

        /// <summary>
        /// Crea una especie.
        /// </summary>
        /// <param name="e">Especie a ser creada</param>
        /// <returns>201 Especie creado con éxito</returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // POST api/<SpeciesController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] SpeciesDTO s)
        {
            if (s == null)
            {
                return BadRequest("No se envió información para el alta.");
            }
            try
            {
                AddUC.Add(s);
                return CreatedAtRoute("GetSpeciesById", new { id = s.Id }, s);
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
        /// Actualiza especie.
        /// </summary>        
        /// <returns>200 Especie actualizada con éxito</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // PUT api/<SpeciesController>/5
        [Authorize]
        [HttpPut]
        public IActionResult Put(SpeciesDTO s)
        {
            if (s == null)
            {
                return BadRequest("No se envió información para actualizar.");
            }

            try
            {
                UpdateUC.Update(s);
                return Ok(s);
            }
            catch (SpeciesException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrión un error inesperado");
            }
        }

        /// <summary>
        /// Elimina una especie según su id.
        /// </summary>
        /// <param name="id">Id de la especie</param>
        /// <returns>200 Especie eliminada con éxito</returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // DELETE api/<SpeciesController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest("El id debe ser un número positivo mayor a cero");

            try
            {
                SpeciesDTO s = FindUC.Find(id);
                if (s == null) return NotFound("La especie con el id " + id + " no existe");

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
