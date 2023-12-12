using Domain.Entities;

namespace Infra.Repositories.EntityFramework
{
    public interface IPurchaseEFRepository : IPurchaseRepository { }

    public class PurchaseEFRepository : IPurchaseEFRepository
    {
        public List<Purchase> GetDescListByUserId(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Purchase newPurchase)
        {
            throw new NotImplementedException();
        }
    }
}
