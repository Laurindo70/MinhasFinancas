using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MinhasFinancas.Domain;
using MinhasFinancas.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace MinhasFinancas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Context _dbContext;
        private readonly IConfiguration _configuration;
        private readonly ILogger<UserController> _logger;

        public UserController(IConfiguration configuration, Context dbContext, ILogger<UserController> logger)
        {
            _configuration = configuration;
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpGet("{id}"), Authorize]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            Console.WriteLine(id);
            var user = await _dbContext.Usuarios.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet, Authorize]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _dbContext.Usuarios
                .Select(
                    Usuarios => new { Id = Usuarios.Id, Name = Usuarios.Name, Email = Usuarios.Email, ActivateEmail = Usuarios.Activated_by_email, Activate = Usuarios.Account_activated })
                .ToListAsync();

            return Ok(users);

    //        var blogs = context.Blogs
    //                  .FromSql($"SELECT * FROM dbo.Blogs")
    //                  .ToList();
        }

        [HttpPost]
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
                return NotFound("Usuario não cadastrado.");
            }

            if(!VerifyPasswordHash(request.Password, user.Password, user.PasswordSalt))
            {
                return BadRequest("Wrong password.");
            }

            string token = CreateToken(user);

            return Ok(token);
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

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("Name", user.Name),
                new Claim("Id", user.Id.ToString())
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
