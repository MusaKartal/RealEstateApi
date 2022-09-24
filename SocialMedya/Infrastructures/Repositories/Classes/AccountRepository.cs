using Microsoft.EntityFrameworkCore;
using SocialMedya.DataAccess;
using SocialMedya.Infrastructures.Repositories.Interfaces;
using SocialMedya.Models;
using TwitterClone.Models;

namespace SocialMedya.Infrastructures
{
    public class AccountRepository : IAccountRepository
    {
        public readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Account user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            return  await _context.Accounts.ToListAsync();
        }

        public async Task<Account> GetByEmail(Account user)
        {
            return await _context.Accounts.FirstOrDefaultAsync(x => x.Email == user.Email);
        }

        public async Task<Account> GetByEmailAndPassword(Account user)
        {
            return await _context.Accounts.FirstOrDefaultAsync(u => u.Email == user.Email && u.Password == user.Password);
        }

        public async Task<Account> GetById(int id)
        {
            return await _context.Accounts.FirstOrDefaultAsync(x => x.Id == id);
        }

       
    }
}
