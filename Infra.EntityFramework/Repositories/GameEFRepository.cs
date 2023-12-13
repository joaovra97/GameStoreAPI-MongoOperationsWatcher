using Domain.Entities;
using Infra.Data.Repositories;

namespace Infra.EntityFramework.Repositories
{
    public interface IGameEFRepository : IGameRepository { }

	public class GameEFRepository : IGameEFRepository
	{
		public Task<List<Game>> GetDescListAsync(int count)
		{
			throw new NotImplementedException();
		}

		public Task InsertAsync(Game game)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(Game game)
		{
			throw new NotImplementedException();
		}
	}
}
