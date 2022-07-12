using DevFreela.Core.Entities;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetById(int id);
        Task<User> GEtUserByEmailAndPassword(string email, string passwordHash);
        Task CreateUser(User user);
    }
}
