using AppLogic.UCInterfaces;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Annotations;
using Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecosystem_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        public IListCountries ListUC { get; set; }
        public IFindCountry FindUC { get; set; }

        public CountryController(IListCountries listUC, IFindCountry findUC) 
        { 
            ListUC = listUC;
            FindUC = findUC;
        }

        [SwaggerOperation(Summary = "Retorna la lista de paises")]
        [SwaggerResponse(200, "Lista de paises obtenida exitosamente", typeof(IEnumerable<Country>))]
        // GET: api/<CountryController>
        [HttpGet(Name = "GetAllCountries")]
        public IActionResult Get()
        {
            IEnumerable<CountryDTO> country;
            try
            {
                country = ListUC.List();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrión un error inesperado");
            }
            return Ok(country);
        }

        [SwaggerOperation(Summary = "Retorna un país por id")]
        [SwaggerResponse(200, "País obtenido con éxito", typeof(Country))]
        // GET: api/<EcosystemController>
        [HttpGet("{id}", Name = "GetCountryById")]
        public IActionResult Get(int id)
        {
            CountryDTO country = FindUC.Find(id);
            if (country == null) return NotFound("No se encontró el ecosistema");
            else return Ok(country);
        }

        // POST api/<CountryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CountryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
