using Domain.Entities;

namespace Infra.Repositories.CData
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
