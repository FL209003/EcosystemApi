using AppLogic.UCInterfaces;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        /// <summary>
        /// Retorna la lista de paises.
        /// </summary>        
        /// <returns>200 Lista de paises obtenida con éxito</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        /// <summary>
        /// Retorna un país según su id.
        /// </summary>    
        /// <param name="id">Id del país</param>
        /// <returns>200 País obtenido con éxito</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
            string url = "https://restcountries.com/v3.1/all?fields=name,cca3";

            var response = Global.GetResponse(url);

            var content = Global.GetContent(response);

            if (response.IsSuccessStatusCode)
            {
                List<RestApiCountryDTO> countries = JsonConvert.DeserializeObject<List<RestApiCountryDTO>>(content);

                foreach (var c in countries)
                {
                    Country country = c.TransformToObj();
                    AddUC.Add(country);
                }

                return Ok("Paises guardados en la base de datos");
            }   
            else return BadRequest("No se enviaron paises.");
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
