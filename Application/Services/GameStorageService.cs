using Application.Request;
using Application.Response;
using Domain.Entities;
using Infra;
using Infra.Repositories;
using Infra.Repositories.CData;
using Infra.Repositories.EntityFramework;
using Infra.Repositories.MongoDbDriver;
using System.Collections.Concurrent;

namespace Application.Services
{
    public class GameStorageService : IGameStorageService
	{
		private readonly IServiceProvider _serviceProvider;
		private readonly IAutoFakerFacadeService _fakerService;

		private IGameRepository _gameRepository;
		private IPurchaseRepository _purchaseRepository;
		private IUserRepository _userRepository;

		public GameStorageService(IServiceProvider serviceProvider, IAutoFakerFacadeService fakerService)
		{			
			_serviceProvider = serviceProvider;
			_fakerService = fakerService;
		}

		public void GameBatchInsert(GameBatchInsertRequest request)
		{
			ValidateRepositories();

			var range = Enumerable.Range(0, request.TotalItems);
			var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = request.MaxParallel };

			Parallel.ForEach(range, parallelOptions, i =>
			{
				var newGame = _fakerService.GenerateGame();
				_gameRepository.Insert(newGame);
			});
		}

		public void UserBatchInsert(UserBatchInsertRequest request)
		{
			ValidateRepositories();

			var range = Enumerable.Range(0, request.TotalItems);
			var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = request.MaxParallel };

			Parallel.ForEach(range, parallelOptions, i =>
			{
				var newUser = _fakerService.GenerateUser();
				_userRepository.Insert(newUser);
			});
		}

		public void PurchaseBatchInsert(PurchaseBatchInsertRequest request)
		{
			ValidateRepositories();

			var range = Enumerable.Range(0, request.TotalItems);
			var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = request.MaxParallel };

			var random = new Random();
			var users = _userRepository.GetDescList(request.UsersRange);
			var games = _gameRepository.GetDescList(request.GamesRange);

			if (!users.Any() || !games.Any())
				throw new NullReferenceException("Games or users collection empty!");

			Parallel.ForEach(range, parallelOptions, i =>
			{
				var user = users[random.Next(users.Count)];
				var gamesCount = random.Next(3);
				var purchaseGames = new List<Game>();

				for(int j = 0; j < gamesCount; i++)				
					purchaseGames.Add(games[random.Next(games.Count)]);								

				var newPurchase = _fakerService.GeneratePurchase(user, purchaseGames);
				_purchaseRepository.Insert(newPurchase);
			});
		}

		public void GamePriceBatchUpdate(GamePriceBatchUpdateRequest request)
		{
			ValidateRepositories();

			var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = request.MaxParallel };
			var games = _gameRepository.GetDescList(request.TotalItems);

			Parallel.ForEach(games, parallelOptions, game =>
			{
				game = _fakerService.UpdateGamePrice(game);
				_gameRepository.Update(game);
			});
		}

		public List<GamesByUsersResponse> GamesByUsers(GamesByUserRequest request)
		{
			ValidateRepositories();

			var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = request.MaxParallel };
			var users = _userRepository.GetDescList(request.TotalItems);
			var results = new ConcurrentBag<GamesByUsersResponse>();

			Parallel.ForEach(users, parallelOptions, user =>
			{
				List<Purchase> purchases = _purchaseRepository.GetDescListByUserId(user.Id);

				float totalPrice = 0;
				List<string> gamesNames = new();

				purchases.ForEach(purchase =>
				{
					totalPrice += purchase.TotalPrice;
					purchase.Games.ForEach(x => gamesNames.Add(x.Title));
				});

				results.Add(new GamesByUsersResponse
				{
					UserName = user.Name,
					TotalPurchases = purchases.Count,
					TotalPrice = purchases.Sum(x => x.TotalPrice),
					GamesPurchased = gamesNames.Distinct().ToList()
				});
			});

			return results.ToList();
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
