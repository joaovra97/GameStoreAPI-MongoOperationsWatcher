using Infra.MongoDbDriver.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.MongoDbDriver
{
	public static class ServicesExtension
	{
		public static IServiceCollection RegisterMongoDbDriverDependencies(this IServiceCollection services)
		{
			services.AddScoped<IGameMongoDbDriverRepository, GameRepository>();
			services.AddScoped<IPurchaseMongoDbDriverRepository, PurchaseRepository>();
			services.AddScoped<IUserMongoDbDriverRepository, UserRepository>();

			return services;
		}
	}
}
