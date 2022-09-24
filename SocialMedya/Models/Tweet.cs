using System.ComponentModel.DataAnnotations;
using TwitterClone.Models;

namespace SocialMedya.Models
{
    public class Tweet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [StringLength(255)]
        public string TweetMessage { get; set; }

        public int TweetCount { get; set; }

       public ICollection<User> Users { get; set; }

    }
}
