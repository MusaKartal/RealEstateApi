using Microsoft.EntityFrameworkCore;
using SocialMedya.DataAccess;
using SocialMedya.Infrastructures.Repositories.Interfaces;
using SocialMedya.Models;

namespace SocialMedya.Infrastructures.Repositories.Classes
{
    public class TweetRepository : ITweetRepository
    {
        private readonly ApplicationDbContext _context;

        public TweetRepository(ApplicationDbContext context) 
        { 
           _context = context;
        
        
        }

        public async Task TweetAddAsync(Tweet tweet)
        {
             await _context.Tweets.AddAsync(tweet);
             await _context.SaveChangesAsync();
        }

        public async Task TweetDeleteAsync(Tweet tweet)
        {
                  _context.Tweets.Remove(tweet);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Tweet>> TweetGetAll()
        {
            return await _context.Tweets.ToListAsync();
        }

        public async Task<Tweet> TweetGetById(int id)
        {
            return await _context.Tweets.FirstOrDefaultAsync(x=>x.Id == id);
        }
    }
}
