using Domain.Entities;

namespace Infra.Repositories.EntityFramework
{
    public interface IUserEFRepository : IUserRepository { }

    public class UserEFRepository : IUserEFRepository
    {
        public List<User> GetDescList(int maxUsersToProcess)
        {
            throw new NotImplementedException();
        }

        public void Insert(User newUser)
        {
            throw new NotImplementedException();
        }
    }
}
