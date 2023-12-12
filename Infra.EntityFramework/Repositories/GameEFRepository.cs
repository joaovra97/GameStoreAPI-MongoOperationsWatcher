using Domain.Entities;
using Infra.Data.Repositories;

namespace Infra.EntityFramework.Repositories
{
    public interface IGameEFRepository : IGameRepository { }

    public class GameEFRepository : IGameEFRepository
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
