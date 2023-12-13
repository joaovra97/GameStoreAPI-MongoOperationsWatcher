using Domain.Entities;

namespace Infra.Data.Repositories.Interfaces
{
    public interface IGameRepository
    {
        Task<List<Game>> GetDescListAsync(int count);
        Task InsertAsync(Game game);
        Task UpdateAsync(Game game);
    }
}
