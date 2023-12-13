using Domain.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Infra.MongoDbDriver.Repositories
{
	public abstract class BaseRepository<T> where T : class
	{
		protected IMongoCollection<T> _collection;

        public BaseRepository(IConfiguration configuration)
        {
			var mongoClient = new MongoClient(configuration[""]);
			var database = mongoClient.GetDatabase("GameStore");
			_collection = database.GetCollection<T>(typeof(T).ToString());
		}

		public async Task InsertAsync(T document) => await _collection.InsertOneAsync(document);

		public async Task UpdateAsync(FilterDefinition<T> filter, UpdateDefinition<T> update) => 
			await _collection.UpdateOneAsync(filter, update);

		public async Task<List<T>> GetDescListAsync(FilterDefinition<T> filter, FindOptions<T> findOptions)
		{
			var results = new List<T>();

			using var cursor = await _collection.FindAsync(filter, findOptions);
			while (await cursor.MoveNextAsync())
			{
				foreach (var document in cursor.Current)
					results.Add(document);
			}

			return results;
		}
	}
}
