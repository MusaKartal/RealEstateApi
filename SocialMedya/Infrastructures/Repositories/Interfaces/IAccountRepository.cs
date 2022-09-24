using SocialMedya.Models;
using TwitterClone.Models;

namespace SocialMedya.Infrastructures.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAll();
        Task<Account> GetById(int id);
        Task<Account> GetByEmail(Account user);
        Task<Account> GetByEmailAndPassword(Account user);
        Task Add(Account user);


    }
}
