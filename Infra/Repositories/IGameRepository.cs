using Domain.Entities;

namespace Infra.Repositories
{
    public interface IGameRepository
    {
        List<Game> GetDescList(int count);
        void Insert(Game game);
        void Update(Game game);
    }
}
