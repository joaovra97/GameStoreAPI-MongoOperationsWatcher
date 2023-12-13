using Domain.Entities;

namespace Infra.Data.Repositories.Interfaces
{
    public interface IPurchaseRepository
    {
        Task<List<Purchase>> GetDescListByUserIdAsync(string userId);
        Task InsertAsync(Purchase newPurchase);
    }
}
