using Infra;
using Infra.Repositories.Games;
using Infra.Repositories.Purchases;
using Infra.Repositories.Users;

namespace Application.Services
{
	public class GameStorageService : IGameStorageService
	{
		private readonly IServiceProvider _serviceProvider;

		private IGameRepository _gameRepository;
		private IPurchaseRepository _purchaseRepository;
		private IUserRepository _userRepository;

		public GameStorageService(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public void SetProvider(Provider provider)
		{
			switch (provider)
			{
				case Provider.MongoDbDriver:
					_gameRepository = _serviceProvider.GetService(typeof(IGameMongoDbDriverRepository)) as IGameRepository;
					_purchaseRepository = _serviceProvider.GetService(typeof(IPurchaseMongoDbDriverRepository)) as IPurchaseRepository;
					_userRepository = _serviceProvider.GetService(typeof(IUserMongoDbDriverRepository)) as IUserRepository;
					break;
				case Provider.EntityFramework:
					_gameRepository = _serviceProvider.GetService(typeof(IGameEFRepository)) as IGameRepository;
					_purchaseRepository = _serviceProvider.GetService(typeof(IPurchaseEFRepository)) as IPurchaseRepository;
					_userRepository = _serviceProvider.GetService(typeof(IUserEFRepository)) as IUserRepository;
					break;
				case Provider.CData:
					_gameRepository = _serviceProvider.GetService(typeof(IGameCDataRepository)) as IGameRepository;
					_purchaseRepository = _serviceProvider.GetService(typeof(IPurchaseCDataRepository)) as IPurchaseRepository;
					_userRepository = _serviceProvider.GetService(typeof(IUserCDataRepository)) as IUserRepository;
					break;
			}
		}

		private void ValidateRepositories()
		{
			if (_gameRepository is null || _purchaseRepository is null || _userRepository is null)
				throw new NullReferenceException("Undefined repositories");
		}
	}
}
