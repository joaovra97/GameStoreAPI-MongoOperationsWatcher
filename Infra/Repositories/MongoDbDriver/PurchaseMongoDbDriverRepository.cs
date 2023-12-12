using Domain.Entities;

namespace Infra.Repositories.MongoDbDriver
{
    public interface IPurchaseMongoDbDriverRepository : IPurchaseRepository { }

    public class PurchaseMongoDbDriverRepository : IPurchaseMongoDbDriverRepository
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
