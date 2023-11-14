using AppLogic.UCInterfaces;
using DTOs;
using Exceptions;
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

        // GET: api/<SpeciesCOntroller>
        [HttpGet("{id}", Name = "GetSpeciesById")]
        public IActionResult Get(int id)
        {
            SpeciesDTO s = FindUC.Find(id);
            if (s == null) return NotFound("No se encontró la especie.");
            else return Ok(s);
        }        

        // POST api/<SpeciesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SpeciesController>/5
        [HttpPut("{id}")]
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

        // DELETE api/<SpeciesController>/5
        [HttpDelete("{id}")]
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
