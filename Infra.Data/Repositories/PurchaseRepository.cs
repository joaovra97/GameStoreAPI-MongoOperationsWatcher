using Domain.Entities;
using Infra.Data.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Infra.Data.Repositories
{
	public class PurchaseRepository : BaseRepository<Purchase>, IPurchaseRepository
	{
		public PurchaseRepository(IConfiguration configuration) : base(configuration, "Purchases") { }

		public async Task<List<Purchase>> GetDescListByUserIdAsync(string userId)
		{			
			var filter = Builders<Purchase>.Filter.Eq(purchase => purchase.UserId, userId);			
			var findOptions = new FindOptions<Purchase>();

			return await base.GetDescListAsync(filter, findOptions);
		}
	}
}
