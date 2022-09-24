using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedya.Infrastructures.Repositories.Interfaces;
using SocialMedya.Models;

namespace SocialMedya.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetController : ControllerBase
    {
        private readonly ITweetRepository _repo;

        public TweetController(ITweetRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult>Get()
        {

            var allGet = await _repo.TweetGetAll();

            return Ok(allGet);

        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult>Get(int id)
        {
            var userGet = await _repo.TweetGetById(id);
            if (userGet == null)
            {
                return BadRequest();
            }

            return Ok(userGet);

        }
        [HttpPost]
        [Authorize]       
        public async Task<IActionResult>Post([FromBody] Tweet tweet)
        {
            

            await _repo.TweetAddAsync(tweet);

            return Ok();

        }
    }
}

