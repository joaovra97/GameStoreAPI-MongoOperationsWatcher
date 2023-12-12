using Domain.Entities;

namespace Infra.Repositories.CData
{
    public interface IPurchaseCDataRepository : IPurchaseRepository { }

    public class PurchaseCDataRepository : IPurchaseCDataRepository
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
