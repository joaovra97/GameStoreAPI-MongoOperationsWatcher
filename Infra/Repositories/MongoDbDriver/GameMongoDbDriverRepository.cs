using Domain.Entities;
using Infra.Repositories;

namespace Infra.Repositories.MongoDbDriver
{
    public interface IGameMongoDbDriverRepository : IGameRepository { }

    public class GameMongoDbDriverRepository : IGameMongoDbDriverRepository
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
