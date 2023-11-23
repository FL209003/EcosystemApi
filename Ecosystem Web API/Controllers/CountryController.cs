using AppLogic.UCInterfaces;
using Azure;
using Domain.Entities;
using DTOs;
using EcosystemApp.Globals;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Net.Http;
using Utility;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecosystem_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        public IListCountries ListUC { get; set; }
        public IFindCountry FindUC { get; set; }
        public IAddCountry AddUC { get; set; }

        public CountryController(IListCountries listUC, IFindCountry findUC, IAddCountry addUC)
        {
            ListUC = listUC;
            FindUC = findUC;
            AddUC = addUC;
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
    }
}
