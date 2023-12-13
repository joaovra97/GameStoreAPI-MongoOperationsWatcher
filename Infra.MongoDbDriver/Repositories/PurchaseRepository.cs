using Domain.Entities;
using Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Infra.MongoDbDriver.Repositories
{
	public interface IPurchaseMongoDbDriverRepository : IPurchaseRepository { }

	public class PurchaseRepository : BaseRepository<Purchase>, IPurchaseMongoDbDriverRepository
	{
		public PurchaseRepository(IConfiguration configuration) : base(configuration) { }

		public async Task<List<Purchase>> GetDescListByUserIdAsync(string id)
		{
			var filter = Builders<Purchase>.Filter.Eq(purchase => purchase.Id, id);
			var findOptions = new FindOptions<Purchase>()
			{
				Sort = Builders<Purchase>.Sort.Descending("_id"),
			};

			return await base.GetDescListAsync(filter, findOptions);
		}
	}
}
