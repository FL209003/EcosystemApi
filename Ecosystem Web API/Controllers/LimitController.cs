using AppLogic.UCInterfaces;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Ecosystem_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LimitController : ControllerBase
    {
        public IModifyLengthParam ModifyUc { get; set; }

        public LimitController(IModifyLengthParam modifyUc)
        {
            ModifyUc = modifyUc;
        }

        [HttpPut("{param}")]
        public IActionResult Put(string param, [FromBody] LimitDTO values)
        {
            try
            {
                if (param == "name")
                {
                    ModifyUc.ModifyNameParams(values.Min, values.Max);
                    return Ok();
                }
                else if (param == "desc")
                {
                    ModifyUc.ModifyDescParams(values.Min, values.Max);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex) {
                return StatusCode(500, "Ocurrión un error inesperado");
            }
            
        }
    }
}
