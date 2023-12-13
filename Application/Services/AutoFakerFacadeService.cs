using Application.Services.Interfaces;
using AutoBogus;
using Bogus;
using Domain.Entities;

namespace Application.Services
{
	public class AutoFakerFacadeService : IAutoFakerFacadeService
	{
		public Game GenerateGame()
		{
			return new AutoFaker<Game>()
				.RuleFor(x => x.Id, c => null)
				.RuleFor(x => x.Title, c => $"{c.Music.Genre()} {c.Commerce.ProductName()}")
				.RuleFor(x => x.Developer, c => c.Company.CompanyName())
				.RuleFor(x => x.Price, c => Math.Round(c.Random.Decimal(20, 100), 2))
				.Generate();
		}

		public User GenerateUser()
		{
			return new AutoFaker<User>()
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
				purchasedGames.Add(new AutoFaker<PurchaseGame>()
					.RuleFor(x => x.Id, c => game.Id)
					.RuleFor(x => x.Title, c => game.Title)
					.RuleFor(x => x.PriceAtPurchase, c => Math.Round(game.Price, 2))
					.Generate());
			});

			return new AutoFaker<Purchase>()
				.RuleFor(x => x.Id, c => null)
				.RuleFor(x => x.UserId, c => user.Id)
				.RuleFor(x => x.UserName, c => user.Name)
				.RuleFor(x => x.Games, c => purchasedGames)
				.RuleFor(x => x.PurchaseDate, c => c.Date.PastOffset(1).DateTime)
				.RuleFor(x => x.TotalPrice, c => games.Sum(v => v.Price))
				.Generate();
		}

		public Game UpdateGamePrice(Game game)
		{
			game.Price = Math.Round(new Faker().Random.Decimal(20, 100), 2);
			return game;
		}
	}
}
