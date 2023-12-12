using AutoBogus;
using Bogus;
using Domain.Entities;

namespace Application.Services
{
	public class AutoFakerFacadeService : IAutoFakerFacadeService
	{
		public Game GenerateGame()
		{
			return new AutoFaker<FakeGame>()
				.RuleFor(x => x.Id, c => null)
				.RuleFor(x => x.Title, c => $"{c.Music.GetType()} {c.Commerce.ProductName()}")
				.RuleFor(x => x.Developer, c => c.Company.CompanyName())
				.RuleFor(x => x.Price, c => c.Random.Float(20, 100))
				.Generate();
		}

		public User GenerateUser()
		{
			return new AutoFaker<FakeUser>()
				.RuleFor(x => x.Id, c => null)
				.RuleFor(x => x.Name, c => c.Person.FullName)
				.RuleFor(x => x.Address, c => c.Address.FullAddress())
				.Generate();
		}

		public Purchase GeneratePurchase(User user, List<Game> games)
		{
			var purchasedGames = new List<PurchaseGame>();
			games.ForEach(game =>
			{
				new AutoFaker<FakePurchaseGame>()
					.RuleFor(x => x.Id, c => game.Id)
					.RuleFor(x => x.Title, c => game.Title)
					.RuleFor(x => x.PriceAtPurchase, c => game.Price)
					.Generate();
			});

			return new AutoFaker<FakePurchase>()
				.RuleFor(x => x.Id, c => null)
				.RuleFor(x => x.UserId, c => user.Id)
				.RuleFor(x => x.UserName, c => user.Name)
				.RuleFor(x => x.Games, c => purchasedGames)
				.RuleFor(x => x.PurchaseDate, c => c.Date.PastOffset(1))
				.RuleFor(x => x.TotalPrice, c => games.Sum(v => v.Price))
				.Generate();
		}

		public Game UpdateGamePrice(Game game)
		{
			game.Price = new Faker().Random.Float(20, 100);
			return game;
		}
	}

	public class FakeGame : Game { }
	public class FakeUser : User { }
	public class FakePurchase : Purchase { }
	public class FakePurchaseGame : PurchaseGame { }
}
