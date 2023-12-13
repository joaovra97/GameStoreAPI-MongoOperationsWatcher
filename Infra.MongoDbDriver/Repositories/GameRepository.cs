using Domain.Entities;
using Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Infra.MongoDbDriver.Repositories
{
	public interface IGameMongoDbDriverRepository : IGameRepository { }

	public class GameRepository : BaseRepository<Game>, IGameMongoDbDriverRepository
	{
		public GameRepository(IConfiguration configuration) : base(configuration) { }

		public async Task<List<Game>> GetDescListAsync(int count)
		{
			var filter = Builders<Game>.Filter.Empty;
			var findOptions = new FindOptions<Game>()
			{
				Sort = Builders<Game>.Sort.Descending("_id"),
				Limit = count
			};

			return await base.GetDescListAsync(filter, findOptions);
		}

		public async Task UpdateAsync(Game game)
		{
			var filter = Builders<Game>.Filter.Eq(game => game.Id, game.Id);
			var update = Builders<Game>.Update.Set(game => game.Price, game.Price);
			await base.UpdateAsync(filter, update);
		}
	}
}
