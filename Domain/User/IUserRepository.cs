
using System.Threading.Tasks;
using Domain.Base;

namespace Domain.User;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetByNameAsync(string name);
}