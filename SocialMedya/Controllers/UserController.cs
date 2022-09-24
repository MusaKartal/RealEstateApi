using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedya.DataAccess;
using SocialMedya.Infrastructures.Repositories.Interfaces;
using SocialMedya.Models;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using TwitterClone.Models;

namespace SocialMedya.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
             _context = context;
        }


        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            var userId = _context.Users.FirstOrDefault(I => I.Id == id);
            if (userId == null)
            {
                return NotFound();
            }

            return Ok(userId);

        }



        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] User user)
        {
            if (user == null)
            {
                return NoContent();
            }
            else
            {
                var userClaimEmail = User.Claims.FirstOrDefault(c =>c.Type == ClaimTypes.Email)?.Value;
                var account = _context.Accounts.FirstOrDefault(u => u.Email == userClaimEmail);
                var deneme = _context.Users.FirstOrDefault(u => u.AccountId == account.Id);
                if (account == null) return NotFound();
                if (deneme != null)
                {
                    return Ok("Bir kez kayıt alınmıştır");
                }
                else
                {
                    user.AccountId = account.Id;
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    return StatusCode(StatusCodes.Status201Created);
                }
                  
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id,[FromBody] User user)
        {

            var userResult = _context.Users.FirstOrDefault(u => u.Id == id);
            if (userResult == null)
            {
                return NoContent();
            }
            else
            {
                var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                var account = _context.Accounts.FirstOrDefault(u => u.Email == userEmail);
                if (account == null) return NotFound();
                if (userResult.AccountId == account.Id)
                {
                    userResult.Name = user.Name;
                    userResult.Surname = user.Surname;
                    userResult.ProfilePhoto = user.ProfilePhoto;
                    userResult.BirthDay = user.BirthDay;
                    userResult.About = user.About;
                    userResult.TweetId = user.TweetId;

                    _context.SaveChanges();
                    return Ok("Record Updated Successfully");
                }
                return BadRequest();
               
            }
        }
    }
}
