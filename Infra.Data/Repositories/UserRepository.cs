using Domain.Entities;
using Infra.Data.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Infra.Data.Repositories
{
	public class UserRepository : BaseRepository<User>, IUserRepository
	{
		public UserRepository(IConfiguration configuration) : base(configuration, "Users") { }

		public async Task<List<User>> GetDescListAsync(int maxUsersToProcess)
		{
			var filter = Builders<User>.Filter.Empty;
			var findOptions = new FindOptions<User>()
			{
				Sort = Builders<User>.Sort.Descending("_id"),
				Limit = maxUsersToProcess
			};

			return await base.GetDescListAsync(filter, findOptions);
		}
	}
}
