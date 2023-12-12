using Domain.Entities;

namespace Infra.Repositories
{
    public interface IUserRepository
    {
        List<User> GetDescList(int maxUsersToProcess);
        void Insert(User newUser);
    }
}
