using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;
using Shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<User>> Post([FromBody] User user, [FromServices] DataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar o usuário" });
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Auhenticate([FromBody] User user, [FromServices] DataContext context)
        {
            var newUser = await context.Users
                .AsNoTracking()
                .Where(x => x.Username == user.Username && x.Password == user.Password)
                .FirstOrDefaultAsync();

            if (newUser == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(newUser);
            return new
            {
                token = token,
                newUser = newUser,
            };
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
