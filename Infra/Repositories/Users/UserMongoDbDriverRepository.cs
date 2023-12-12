using Infra.Repositories.Games;

namespace Infra.Repositories.Users
{
	public interface IUserMongoDbDriverRepository : IUserRepository { }

	public class UserMongoDbDriverRepository : IUserMongoDbDriverRepository
	{
	}
}
