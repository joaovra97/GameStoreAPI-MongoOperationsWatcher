using Domain.Entities;
using Infra.Data.Repositories;

namespace Infra.MongoDbDriver.Repositories
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
