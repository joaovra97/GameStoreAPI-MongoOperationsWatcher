using Domain.Entities;
using Infra.Data.Repositories;

namespace Infra.CData.Repositories
{
    public interface IGameCDataRepository : IGameRepository { }

    public class GameCDataRepository : IGameCDataRepository
    {
        public List<Game> GetDescList(int count)
        {
            throw new NotImplementedException();
        }

        public void Insert(Game game)
        {
            throw new NotImplementedException();
        }

        public void Update(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
