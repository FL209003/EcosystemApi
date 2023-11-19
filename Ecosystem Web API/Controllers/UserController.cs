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
