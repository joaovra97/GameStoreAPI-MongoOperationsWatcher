using Domain.Entities;

namespace Infra.Repositories
{
    public interface IPurchaseRepository
    {
        List<Purchase> GetDescListByUserId(string id);
        void Insert(Purchase newPurchase);
    }
}
