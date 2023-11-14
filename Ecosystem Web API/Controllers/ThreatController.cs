﻿using AppLogic.UCInterfaces;
using DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecosystem_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThreatController : ControllerBase
    {
        public IListThreats ListUC { get; set; }
        public IFindThreat FindUC { get; set; }

        public ThreatController(IListThreats listUC, IFindThreat findUC)
        {
            ListUC = listUC;
            FindUC = findUC;
        }

        // GET: api/<ThreatController>
        [HttpGet(Name = "GetAllThreats")]
        public IActionResult Get()
        {
            IEnumerable<ThreatDTO> threat = null;
            try
            {
                threat = ListUC.List();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrión un error inesperado.");
            }
            return Ok(threat);
        }

        // GET api/<ThreatController>/5
        [HttpGet("{id}", Name = "GetThreatById")]
        public IActionResult Get(int id)
        {
            ThreatDTO threat = FindUC.Find(id);
            if (threat == null) return NotFound("No se encontró la amenaza.");
            else return Ok(threat);
        }

        // POST api/<ThreatController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ThreatController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ThreatController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
