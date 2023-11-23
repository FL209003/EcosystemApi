using AppLogic.UCInterfaces;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecosystem_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConservationController : ControllerBase
    {
        public IFindConservation FindUC { get; set; }        

        public ConservationController(IFindConservation findUC)
        {
            FindUC = findUC;            
        }

        /// <summary>
        /// Retorna una conservación según su rango de seguridad.
        /// </summary>
        /// <param name="sec">Seguridad de la conservación</param>
        /// <returns>200 Conservación</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        // GET api/<ConservationController>/5
        [HttpGet(Name = "GetBySecurity")]
        public IActionResult Get(int sec)
        {
            ConservationDTO con = FindUC.FindBySecurity(sec);
            if (con == null) return NotFound("No se encontró la conservación.");
            else return Ok(con);
        }        
    }
}
