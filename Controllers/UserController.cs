using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Domain;
using MinhasFinancas.Models;
using System.Security.Cryptography;

namespace MinhasFinancas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Context _dbContext;

        public UserController(Context dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            var user = await _dbContext.Usuarios.FindAsync(id);

            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Post(RegisterUser request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var userRes = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = passwordHash,
                PasswordSalt = passwordSalt
            };
            _dbContext.Usuarios.Add(userRes);
            await _dbContext.SaveChangesAsync();

            return Created("Cadastrado com sucesso.", userRes);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> login(LoginsUser request)
        {
            var user = await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Email == request.Email);

            if (user == null)
            {
                return NotFound();
            }

            if(!VerifyPasswordHash(request.Password, user.Password, user.PasswordSalt))
            {
                return BadRequest("Wrong password.");
            }

            return Ok("Encontrado");
        }


        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
