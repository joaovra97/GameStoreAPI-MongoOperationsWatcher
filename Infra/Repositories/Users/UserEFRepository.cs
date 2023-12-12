using Infra.Repositories.Games;

namespace Infra.Repositories.Users
{
	public interface IUserEFRepository : IUserRepository { }

	public class UserEFRepository : IUserEFRepository
	{
	}
}
