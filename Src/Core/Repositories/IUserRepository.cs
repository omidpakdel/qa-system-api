using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories.Base;

namespace Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByPhoneNumber(string phoneNumber);
    }
}