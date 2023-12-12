using Domain.Entities;
using Infra.Data.Repositories;

namespace Infra.CData.Repositories
{
    public interface IUserCDataRepository : IUserRepository { }

    public class UserCDataRepository : IUserCDataRepository
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
