using SocialMedya.Models;
using TwitterClone.Models;
using static System.Net.Mime.MediaTypeNames;

namespace SocialMedya.Infrastructures.Repositories.Interfaces
{
    public interface ITweetRepository
    {
        Task<IEnumerable<Tweet>> TweetGetAll();
        Task<Tweet> TweetGetById(int id);
        Task TweetAddAsync(Tweet tweet);
        Task TweetDeleteAsync(Tweet tweet);

        

        



    }
}
