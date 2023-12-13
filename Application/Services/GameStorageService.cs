using Application.Response;
using Application.Services.Interfaces;
using Domain.Entities;
using Infra.Data.Repositories.Interfaces;
using System.Collections.Concurrent;

namespace Application.Services
{
    public class GameStorageService : IGameStorageService
	{
		private readonly IAutoFakerFacadeService _fakerService;
		private readonly IGameRepository _gameRepository;
		private readonly IPurchaseRepository _purchaseRepository;
		private readonly IUserRepository _userRepository;

		public GameStorageService(IAutoFakerFacadeService fakerService,
			IGameRepository gameRepository,
			IPurchaseRepository purchaseRepository,
			IUserRepository userRepository)
		{
			_fakerService = fakerService;
			_gameRepository = gameRepository;
			_purchaseRepository = purchaseRepository;
			_userRepository = userRepository;
		}

		public async Task GameBatchInsertAsync(int totalItems, int maxParallel)
		{
			var range = Enumerable.Range(0, totalItems);
			var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = maxParallel };

			await Parallel.ForEachAsync(range, parallelOptions, async (i, ct) =>
			{
				var newGame = _fakerService.GenerateGame();
				await _gameRepository.InsertAsync(newGame);
			});
		}

		public async Task UserBatchInsertAsync(int totalItems, int maxParallel)
		{
			var range = Enumerable.Range(0, totalItems);
			var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = maxParallel };

			await Parallel.ForEachAsync(range, parallelOptions, async (i, ct) =>
			{
				var newUser = _fakerService.GenerateUser();
				await _userRepository.InsertAsync(newUser);
			});
		}

		public async Task PurchaseBatchInsertAsync(int totalItems, int maxParallel, int gamesRange, int usersRange)
		{
			var range = Enumerable.Range(0, totalItems);
			var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = maxParallel };

			var random = new Random();
			var users = await _userRepository.GetDescListAsync(usersRange);
			var games = await _gameRepository.GetDescListAsync(gamesRange);

			if (!users.Any() || !games.Any())
				throw new NullReferenceException("Games or users collection empty!");

			await Parallel.ForEachAsync(range, parallelOptions, async (i, ct) =>
			{
				var user = users[random.Next(users.Count)];
				var gamesCount = random.Next(2) + 1;
				var purchaseGames = new List<Game>();

				for (int j = 0; j < gamesCount; j++)
					purchaseGames.Add(games[random.Next(games.Count)]);

				purchaseGames = purchaseGames.Distinct().ToList();

				var newPurchase = _fakerService.GeneratePurchase(user, purchaseGames);
				await _purchaseRepository.InsertAsync(newPurchase);
			});
		}

		public async Task GamePriceBatchUpdateAsync(int totalItems, int maxParallel)
		{
			var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = maxParallel };
			var games = await _gameRepository.GetDescListAsync(totalItems);

			await Parallel.ForEachAsync(games, parallelOptions, async (game, ct) =>
			{
				game = _fakerService.UpdateGamePrice(game);
				await _gameRepository.UpdateAsync(game);
			});
		}

		public async Task<List<GamesByUsersItem>> GamesByUsersAsync(int totalItems, int maxParallel)
		{
			var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = maxParallel };
			var users = await _userRepository.GetDescListAsync(totalItems);
			var results = new ConcurrentBag<GamesByUsersItem>();

			await Parallel.ForEachAsync(users, parallelOptions, async (user, ct) =>
			{
				List<Purchase> purchases = await _purchaseRepository.GetDescListByUserIdAsync(user.Id);

				decimal totalPrice = 0;
				List<string> gamesNames = new();

				purchases.ForEach(purchase =>
				{
					totalPrice += purchase.TotalPrice;
					purchase.Games.ForEach(x => gamesNames.Add(x.Title));
				});

				results.Add(new GamesByUsersItem
				{
					UserName = user.Name,
					TotalPurchases = purchases.Count,
					TotalPrice = purchases.Sum(x => x.TotalPrice),
					GamesPurchased = gamesNames.Distinct().ToList()
				});
			});

			return results.ToList();
		}
	}
}
