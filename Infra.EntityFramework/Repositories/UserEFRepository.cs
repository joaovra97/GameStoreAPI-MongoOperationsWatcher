using Domain.Entities;
using Infra.Data.Repositories;

namespace Infra.EntityFramework.Repositories
{
    public interface IUserEFRepository : IUserRepository { }

	public class UserEFRepository : IUserEFRepository
	{
		public Task<List<User>> GetDescListAsync(int maxUsersToProcess)
		{
			throw new NotImplementedException();
		}

		public Task InsertAsync(User newUser)
		{
			throw new NotImplementedException();
		}
	}
}
