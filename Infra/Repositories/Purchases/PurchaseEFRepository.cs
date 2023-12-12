using Infra.Repositories.Games;

namespace Infra.Repositories.Purchases
{
	public interface IPurchaseEFRepository : IPurchaseRepository { }

	public class PurchaseEFRepository : IPurchaseEFRepository
	{
	}
}
