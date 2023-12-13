using Application.Response;

namespace Application.Services.Interfaces
{
    public interface IGameStorageService
    {
        Task GameBatchInsertAsync(int totalItems, int maxParallel);
        Task UserBatchInsertAsync(int totalItems, int maxParallel);
        Task PurchaseBatchInsertAsync(int totalItems, int maxParallel, int gamesRange, int usersRange);
        Task GamePriceBatchUpdateAsync(int totalItems, int maxParallel);
        Task<List<GamesByUsersItem>> GamesByUsersAsync(int totalItems, int maxParallel);
    }
}
