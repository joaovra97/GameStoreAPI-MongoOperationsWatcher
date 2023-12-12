using Infra.Repositories.Games;

namespace Infra.Repositories.Purchases
{
	public interface IPurchaseMongoDbDriverRepository : IPurchaseRepository { }

	public class PurchaseMongoDbDriverRepository : IPurchaseMongoDbDriverRepository
	{
	}
}
