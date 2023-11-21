using AppLogic.UCInterfaces;
using DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecosystem_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IFindUser UserUC { get; set; }

        public UserController(IFindUser userUC) {
            UserUC = userUC;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Loguea un usuario.
        /// </summary>
        /// <param name="user">Datos del usuario</param>
        /// <returns>200 Usuario logueado con éxito</returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]        
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDTO user)
        {
            UserDTO logged = UserUC.Login(user.Username, user.Password);
            if (logged == null)
            {
                return BadRequest("El usuario y contrase;a ingresados no son correctos");
            }
            else
            {
                return Ok(new { logged.Role, TokenJWT = JWTHandler.GenerateToken(logged) });
            }
        }

        /// <summary>
        /// Crea un usuario.
        /// </summary>
        /// <param name="u">Usuario a ser creado</param>
        /// <returns>201 Ecosistema creado con éxito</returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
