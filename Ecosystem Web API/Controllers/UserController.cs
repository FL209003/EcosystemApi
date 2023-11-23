using AppLogic.UCInterfaces;
using DTOs;
using Microsoft.AspNetCore.Authorization;
using Exceptions;
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
        public IAddUser AddUserUC { get; set; }

        public UserController(IFindUser userUC, IAddUser addUserUC = null)
        {
            UserUC = userUC;
            AddUserUC = addUserUC;
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
        [Authorize(Roles = "Admin")]
        public IActionResult Post([FromBody] UserDTO user)
        {
            if(user == null) return BadRequest("No se envió información para el alta.");
            try
            {
                AddUserUC.Add(user);
                return Ok("Usuario creado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrión un error inesperado.");
            }
        }
    }
}
