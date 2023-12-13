using Domain.Entities;
using Infra.Data.Repositories;

namespace Infra.EntityFramework.Repositories
{
    public interface IPurchaseEFRepository : IPurchaseRepository { }

	public class PurchaseEFRepository : IPurchaseEFRepository
	{
		public Task<List<Purchase>> GetDescListByUserIdAsync(string id)
		{
			throw new NotImplementedException();
		}

		public Task InsertAsync(Purchase newPurchase)
		{
			throw new NotImplementedException();
		}
	}
}
