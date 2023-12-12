using Domain.Entities;
using Infra.Data.Repositories;

namespace Infra.MongoDbDriver.Repositories
{
    public interface IUserMongoDbDriverRepository : IUserRepository { }

    public class UserMongoDbDriverRepository : IUserMongoDbDriverRepository
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
