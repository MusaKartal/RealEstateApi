using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SocialMedya.DataAccess;
using SocialMedya.Infrastructures;
using SocialMedya.Infrastructures.Repositories.Interfaces;
using SocialMedya.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TwitterClone.Models;

namespace SocialMedya.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _repo;
        private  IConfiguration _configuration;
        public AccountController(IAccountRepository repo, IConfiguration configuration)
        {
            _repo = repo;
            _configuration = configuration;
        }

        [HttpPost("[action]")]
        public async Task <IActionResult> Register([FromBody] Account user)
        { 
            
            var userExists =  await _repo.GetByEmail(user);
            if (userExists != null)
            {
                return BadRequest("User with same email already exits");

            }
            await _repo.Add(user);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost("[action]")]
        public async Task <IActionResult> Login([FromBody] Account user)
        {

            var currentUser =  await _repo.GetByEmailAndPassword(user);
            if (currentUser == null)
            {
                return NotFound();

            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email , user.Email)
            };

            var token = new JwtSecurityToken(

                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials : credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            
            return Ok(jwt);             
        }


    }
}
