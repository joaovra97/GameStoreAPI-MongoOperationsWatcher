using Domain.Entities;

namespace Infra.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetDescListAsync(int maxUsersToProcess);
        Task InsertAsync(User newUser);
    }
}
