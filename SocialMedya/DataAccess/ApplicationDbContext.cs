using Microsoft.EntityFrameworkCore;
using SocialMedya.Models;
using TwitterClone.Models;

namespace SocialMedya.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Tweet> Tweets { get; set; }

        public DbSet<Account> Accounts { get; set; }

    }
}
