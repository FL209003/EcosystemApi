﻿using AppLogic.UCInterfaces;
using AppLogic.UseCases;
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

        public EcosystemController(IAddEcosystem addUC, IRemoveEcosystem removeUC, IListEcosystem listUC,
            IFindEcosystem findUC)
        {
            AddUC = addUC;
            RemoveUC = removeUC;
            ListUC = listUC;
            FindUC = findUC;
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
                AddUC.Add(e);
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
