using Domain.Entities;
using Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Infra.MongoDbDriver.Repositories
{
	public interface IUserMongoDbDriverRepository : IUserRepository { }

	public class UserRepository : BaseRepository<User>, IUserMongoDbDriverRepository
	{
		public UserRepository(IConfiguration configuration) : base(configuration) { }

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
